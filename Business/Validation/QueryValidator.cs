using Domain;
using Domain.Definition;

namespace Business.Validation;

public class QueryValidator
{
    private readonly DatabaseMetadata _metadata;

    public QueryValidator(DatabaseMetadata metadata)
    {
        _metadata = metadata;
    }

    public bool IsValidTable(string tableName)
    {
        string normalized =
            NormalizeTableName(tableName);

        return _metadata.Tables.Contains(
            normalized,
            StringComparer.OrdinalIgnoreCase);
    }

    public bool IsValidColumn(
    string tableName,
    string columnName)
    {
        if (!_metadata.Columns.TryGetValue(
                tableName,
                out var columns))
        {
            return false;
        }

        return columns.Any(c =>
            string.Equals(
                c.Name,
                columnName,
                StringComparison.OrdinalIgnoreCase));
    }

    public bool IsValidOperator(ComparisonOperator op)
    {
        return Enum.IsDefined(op);
    }

    public bool IsValidValueCount(FilterDefinition filter)
    {
        int count =  (int)filter.Values.Count;

        return filter.Operator switch
        {
            ComparisonOperator.Equal
                or ComparisonOperator.NotEqual
                or ComparisonOperator.GreaterThan
                or ComparisonOperator.LessThan
                or ComparisonOperator.GreaterThanOrEqual
                or ComparisonOperator.LessThanOrEqual
                or ComparisonOperator.Like
                => count == 1,

            ComparisonOperator.Between
                => count == 2,

            ComparisonOperator.In
                => count > 0,

            ComparisonOperator.IsNull
                or ComparisonOperator.IsNotNull
                => count == 0,

            _ => false
        };
    }

    public bool IsValidFilter(FilterDefinition filter)
    {
        return IsValidOperator(filter.Operator)
               && IsValidValueCount(filter);
    }

    public bool IsValidOrderBy(
        string? orderBy,
        string tableName)
    {
        if (string.IsNullOrWhiteSpace(orderBy))
            return true;

        return IsValidColumn(tableName, orderBy);
    }

    public void Validate(QueryDefinition query)
    {
        ValidateTable(query);
        ValidateSelectedColumns(query);
        ValidateJoins(query);
        ValidateFilters(query);
        ValidateOrderBy(query);
    }

    private void ValidateTable(QueryDefinition query)
    {
        if (!IsValidTable(query.TableName))
        {
            throw new InvalidOperationException(
                $"Table '{query.TableName}' does not exist.");
        }
    }

    private void ValidateSelectedColumns(
        QueryDefinition query)
    {
        foreach (string column in query.SelectedColumns)
        {
            ValidateColumnReference(
                column,
                query,
                "Selected column");
        }
    }

    private void ValidateColumnReference(
    string column,
    QueryDefinition query,
    string context)
    {
        string tableName = query.TableName;
        string columnName = column;

        if (column.Contains('.'))
        {
            string[] parts = column.Split('.', 2);

            tableName = parts[0];
            columnName = parts[1];

            if (!IsValidTable(tableName))
            {
                throw new InvalidOperationException(
                    $"{context}: Table '{tableName}' does not exist.");
            }

            bool isMainTable = string.Equals(
                tableName,
                GetTableShortName(query.TableName),
                StringComparison.OrdinalIgnoreCase);

            bool isJoinedTable = query.Joins.Any(join =>
                string.Equals(
                    tableName,
                    GetTableShortName(join.TableName),
                    StringComparison.OrdinalIgnoreCase));

            if (!isMainTable && !isJoinedTable)
            {
                throw new InvalidOperationException(
                    $"{context}: Table '{tableName}' is not joined in the query.");
            }

            if (!IsValidColumn(
                    FindFullTableName(tableName),
                    columnName))
            {
                throw new InvalidOperationException(
                    $"{context}: Column '{columnName}' " +
                    $"does not exist in table '{tableName}'.");
            }
        }
        else
        {
            if (!IsValidColumn(query.TableName, columnName))
            {
                throw new InvalidOperationException(
                    $"{context}: Column '{columnName}' " +
                    $"does not exist in table '{query.TableName}'.");
            }
        }
    }

    private void ValidateJoins(QueryDefinition query)
    {
        foreach (var join in query.Joins)
        {
            if (!IsValidTable(join.TableName))
            {
                throw new InvalidOperationException(
                    $"Join table '{join.TableName}' does not exist.");
            }

            if (!IsValidColumn(
                    query.TableName,
                    join.LeftColumn))
            {
                throw new InvalidOperationException(
                    $"Join column '{join.LeftColumn}' " +
                    $"does not exist in table '{query.TableName}'.");
            }

            if (!IsValidColumn(
                    join.TableName,
                    join.RightColumn))
            {
                throw new InvalidOperationException(
                    $"Join column '{join.RightColumn}' " +
                    $"does not exist in table '{join.TableName}'.");
            }
        }
    }

    public void ValidateFilters(QueryDefinition query)
    {
        foreach (FilterDefinition filter in query.Filters)
        {
            ValidateColumnReference(
                filter.ColumnName,
                query,
                "Filter column");

            if (!IsValidOperator(filter.Operator))
            {
                throw new InvalidOperationException(
                    $"Operator '{filter.Operator}' is not supported.");
            }

            if (!IsValidValueCount(filter))
            {
                throw new InvalidOperationException(
                    $"Invalid number of values " +
                    $"for operator '{filter.Operator}'.");
            }
        }
    }

    private void ValidateOrderBy(QueryDefinition query)
    {
        if (string.IsNullOrWhiteSpace(query.OrderBy))
            return;

        ValidateColumnReference(
            query.OrderBy,
            query,
            "OrderBy column");
    }


    private string NormalizeTableName(string tableName)
    {
        if (tableName.Contains('.'))
            return tableName;

        var matches = _metadata.Tables
            .Where(t =>
                t.EndsWith(
                    "." + tableName,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (matches.Count == 1)
            return matches[0];

        return tableName;
    }
    private string GetTableShortName(string fullTableName)
    {
        int index = fullTableName.IndexOf('.');

        return index >= 0
            ? fullTableName[(index + 1)..]
            : fullTableName;
    }
    private string FindFullTableName(string tableName)
    {
        return _metadata.Tables.FirstOrDefault(t =>
            string.Equals(
                GetTableShortName(t),
                tableName,
                StringComparison.OrdinalIgnoreCase))
            ?? tableName;
    }
}
