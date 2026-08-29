using Domain.Definition;

namespace Business.Query;

public class FilterBuilder
{
    public FilterResult Build(FilterDefinition filter)
    {
        string column = $"[{filter.ColumnName}]";

        return filter.Operator switch
        {
            ComparisonOperator.Equal =>
                BuildSingleValue(column, "=", filter),

            ComparisonOperator.NotEqual =>
                BuildSingleValue(column, "<>", filter),

            ComparisonOperator.GreaterThan =>
                BuildSingleValue(column, ">", filter),

            ComparisonOperator.LessThan =>
                BuildSingleValue(column, "<", filter),

            ComparisonOperator.GreaterThanOrEqual =>
                BuildSingleValue(column, ">=", filter),

            ComparisonOperator.LessThanOrEqual =>
                BuildSingleValue(column, "<=", filter),

            ComparisonOperator.Like =>
                BuildSingleValue(column, "LIKE", filter),

            ComparisonOperator.Between =>
                BuildBetween(column, filter),

            ComparisonOperator.In =>
                BuildIn(column, filter),

            ComparisonOperator.IsNull =>
                new FilterResult { Sql = $"{column} IS NULL" },

            ComparisonOperator.IsNotNull =>
                new FilterResult { Sql = $"{column} IS NOT NULL" },

            _ => throw new NotSupportedException(
                $"Operator {filter.Operator} is not supported.")
        };
    }

    private FilterResult BuildSingleValue(
    string column,
    string sqlOperator,
    FilterDefinition filter)
    {
        return new FilterResult
        {
            Sql = $"{column} {sqlOperator} {filter.Value ?? filter.Values[0] ?? DBNull.Value}",
        };
    }

    private FilterResult BuildBetween(
        string column,
        FilterDefinition filter)
    {
        return new FilterResult
        {
            Sql = $"{column} BETWEEN {filter.Values[0]} AND {filter.Values[1]}",
        };
    }

    private FilterResult BuildIn(
        string column,
        FilterDefinition filter)
    {
        var parameter = Enumerable
            .Range(0, filter.Values.Count)
            .Select(i => $"{filter.Values[i]}")
            .ToList();

        return new FilterResult
        {
            Sql = $"{column} IN ({string.Join(", ", parameter)})"
        };
    }

}


public class FilterResult
{
    public string Sql { get; set; } = string.Empty;

    public List<object?> Values { get; set; } = new();
}