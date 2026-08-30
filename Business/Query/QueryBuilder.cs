using Domain.Definition;
using System.Data.SqlClient;
using System.Text;

namespace Business.Query;

public class QueryBuilder
{
    private readonly FilterBuilder _filterBuilder = new FilterBuilder();


    public string Build(QueryDefinition query)
    {
        string columns = query.SelectedColumns.Count > 0
            ? string.Join(", ",
                query.SelectedColumns.Select(c => $"[{c}]"))
            : "*";

        string sql = $"SELECT {columns} FROM [{query.TableName}]";

        if (query.Filters.Count > 0)
        {
            var conditions = new List<string>();

            for (int i = 0; i < query.Filters.Count; i++)
            {
                var filter = query.Filters[i];

                string condition = _filterBuilder.Build(filter).Sql;

                if (i > 0)
                {
                    string logicalOperator =
                        query.Filters[i - 1].LogicalOperator == LogicalOperator.And
                            ? "AND"
                            : "OR";

                    condition = $"{logicalOperator} {condition}";
                }

                conditions.Add(condition);
            }

            sql += " WHERE " + string.Join(" ", conditions);
        }

        if (!string.IsNullOrWhiteSpace(query.OrderBy))
        {
            string direction = query.Descending
                ? "DESC"
                : "ASC";

            sql += $" ORDER BY [{query.OrderBy}] {direction}";
        }

        return sql;
    }

    private string BuildJoins(QueryDefinition query)
    {
        if (query.Joins.Count == 0)
            return string.Empty;

        var sql = new StringBuilder();

        foreach (var join in query.Joins)
        {
            sql.Append(
                $"{GetJoinType(join.JoinType)} " +
                $"JOIN [{join.TableName}] " +
                $"ON [{query.TableName}].[{join.LeftColumn}] = " +
                $"[{join.TableName}].[{join.RightColumn}] ");
        }

        return sql.ToString();
    }


    private string GetJoinType(JoinType joinType)
    {
        return joinType switch
        {
            JoinType.Inner => "INNER",
            JoinType.Left => "LEFT",
            JoinType.Right => "RIGHT",
            JoinType.Full => "FULL",
            _ => throw new ArgumentOutOfRangeException(nameof(joinType))
        };
    }


}