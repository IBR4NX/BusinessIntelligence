using Domain;
using Domain.Definition;

namespace Business.Validation;

public class QueryValidator
{
    private readonly DatabaseMetadata _metadata;

    public QueryValidator(DatabaseMetadata metadata)
    {
        _metadata = metadata;
        foreach (var t in metadata.Tables)
        {
            Console.WriteLine(t);
        }
    }
    public bool IsValidTable(string tableName)
    {
        return _metadata.Tables.Contains(
            tableName,
            StringComparer.OrdinalIgnoreCase);
    }
    public bool IsValidColumn(string tableName, string columnName)
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
        int count = filter.Values.Count > 0
        ? filter.Values.Count
        : filter.Value != null
            ? 1
            : 0;

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

    public bool IsValidOrderBy(string? orderBy, string tableName)
    {
        if (string.IsNullOrWhiteSpace(orderBy)) return true;

        return IsValidColumn(tableName, orderBy);
    }

    public void Validate(QueryDefinition query)
    {
        if (!IsValidTable(query.TableName))
            throw new InvalidOperationException($"Table '{query.TableName}' does not exist.");

        foreach (string column in query.SelectedColumns)
        {
            if (!IsValidColumn(query.TableName, column))
                throw new InvalidOperationException($"Column '{column}' does not exist in table '{query.TableName}'.");
        }

        foreach (FilterDefinition filter in query.Filters)
        {
            if (!IsValidColumn(query.TableName, filter.ColumnName))
                throw new InvalidOperationException($"Filter column '{filter.ColumnName}' does not exist in table '{query.TableName}'.");

            if (!IsValidOperator(filter.Operator))
                throw new InvalidOperationException($"Operator '{filter.Operator}' is not supported.");

            if (!IsValidValueCount(filter))
                throw new InvalidOperationException($"Invalid number of values for operator '{filter.Operator}'.");
        }

        if (!IsValidOrderBy(query.OrderBy, query.TableName))
            throw new InvalidOperationException($"OrderBy column '{query.OrderBy}' does not exist in table '{query.TableName}'.");
    }
}