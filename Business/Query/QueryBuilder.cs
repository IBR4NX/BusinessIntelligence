using Domain.Definition;
using System.Text;

namespace Business.Query;

public class QueryBuilder
{
    private readonly FilterBuilder _filterBuilder = new();

    public string Build(QueryDefinition query)
    {
        return Build(query, out _);
    }

    public string Build(
        QueryDefinition query,
        out IReadOnlyDictionary<string, object?> parameters)
    {
        var sql = new StringBuilder();
        var queryParameters = new Dictionary<string, object?>();

        sql.Append(BuildSelect(query));
        sql.Append(BuildFrom(query));
        sql.Append(BuildJoins(query));
        sql.Append(BuildWhere(query, queryParameters));
        sql.Append(BuildOrderBy(query));

        parameters = queryParameters;
        return sql.ToString();
    }

    private string BuildSelect(QueryDefinition query)
    {
        if (query.SelectedColumns.Count == 0)
            return "SELECT * ";

        string columns = string.Join(
            ", ",
            query.SelectedColumns.Select(BuildColumn));

        return $"SELECT {columns} ";
    }

    private string BuildFrom(QueryDefinition query)
    {
        return $"FROM [{query.TableName}] ";
    }

    private string BuildJoins(QueryDefinition query)
    {
        if (query.Joins.Count == 0)
            return string.Empty;

        var sql = new StringBuilder();

        foreach (var join in query.Joins)
        {
            string joinType = GetJoinType(join.JoinType);

            string condition = BuildJoinCondition(
                query.TableName,
                join.LeftColumn,
                join.TableName,
                join.RightColumn);

            sql.Append(
                $"{joinType} JOIN [{join.TableName}] " +
                $"ON {condition} ");
        }

        return sql.ToString();
    }

    private string BuildWhere(
        QueryDefinition query,
        Dictionary<string, object?> queryParameters)
    {
        if (query.Filters.Count == 0)
            return string.Empty;

        var conditions = new List<string>();

        int parameterIndex = 0;
        for (int i = 0; i < query.Filters.Count; i++)
        {
            var filter = query.Filters[i];

            FilterResult filterResult = _filterBuilder.Build(filter, ref parameterIndex);
            string condition = filterResult.Sql;

            foreach (var parameter in filterResult.Parameters)
                queryParameters.Add(parameter.Key, parameter.Value);

            if (i > 0)
            {
                string logicalOperator =
                    query.Filters[i - 1].LogicalOperator
                        == LogicalOperator.And
                            ? "AND"
                            : "OR";

                condition = $"{logicalOperator} {condition}";
            }

            conditions.Add(condition);
        }

        return $"WHERE {string.Join(" ", conditions)} ";
    }

    private string BuildOrderBy(QueryDefinition query)
    {
        if (string.IsNullOrWhiteSpace(query.OrderBy))
            return string.Empty;

        string direction = query.Descending
            ? "DESC"
            : "ASC";

        return $"ORDER BY {BuildColumn(query.OrderBy)} {direction}";
    }

    private string GetJoinType(JoinType joinType)
    {
        return joinType switch
        {
            JoinType.Inner => "INNER",
            JoinType.Left => "LEFT",
            JoinType.Right => "RIGHT",
            JoinType.Full => "FULL",
            _ => throw new ArgumentOutOfRangeException(
                nameof(joinType))
        };
    }
    private string BuildColumn(string column)
    {
        if (column.Contains('.'))
        {
            string[] parts = column.Split('.', 2);

            return $"[{parts[0]}].[{parts[1]}]";
        }

        return $"[{column}]";
    }

    private string BuildJoinCondition(
    string leftTable,
    string leftColumn,
    string rightTable,
    string rightColumn)
    {
        return $"[{leftTable}].[{leftColumn}] = " +
               $"[{rightTable}].[{rightColumn}]";
    }

}
