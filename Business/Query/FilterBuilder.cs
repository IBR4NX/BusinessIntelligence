using Domain.Definition;

namespace Business.Query;

public class FilterBuilder
{
    public FilterResult Build(FilterDefinition filter, ref int parameterIndex)
    {
        string column = $"[{filter.ColumnName}]";

        return filter.Operator switch
        {
            ComparisonOperator.Equal =>
                BuildSingleValue(column, "=", filter, ref parameterIndex),

            ComparisonOperator.NotEqual =>
                BuildSingleValue(column, "<>", filter, ref parameterIndex),

            ComparisonOperator.GreaterThan =>
                BuildSingleValue(column, ">", filter, ref parameterIndex),

            ComparisonOperator.LessThan =>
                BuildSingleValue(column, "<", filter, ref parameterIndex),

            ComparisonOperator.GreaterThanOrEqual =>
                BuildSingleValue(column, ">=", filter, ref parameterIndex),

            ComparisonOperator.LessThanOrEqual =>
                BuildSingleValue(column, "<=", filter, ref parameterIndex),

            ComparisonOperator.Like =>
                BuildSingleValue(column, "LIKE", filter, ref parameterIndex),

            ComparisonOperator.Between =>
                BuildBetween(column, filter, ref parameterIndex),

            ComparisonOperator.In =>
                BuildIn(column, filter, ref parameterIndex),

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
    FilterDefinition filter,
    ref int parameterIndex)
    {
        object? value = filter.Values[0];
        string parameterName = $"@p{parameterIndex++}";

        return new FilterResult
        {
            Sql = $"{column} {sqlOperator} {value}",
            Parameters = { [parameterName] = value ?? DBNull.Value }
        };
    }

    private FilterResult BuildBetween(
        string column,
        FilterDefinition filter,
        ref int parameterIndex)
    {
        var values = filter.Values ?? throw new InvalidOperationException("Between requires two values.");
        //string firstParameter = $"@p{parameterIndex++}";
        //string secondParameter = $"@p{parameterIndex++}";

        return new FilterResult
        {
            Sql = $"{column} BETWEEN {values[0]} AND {values[1]}",
            //Parameters =
            //{
            //    [firstParameter] = values[0] ?? DBNull.Value,
            //    [secondParameter] = values[1] ?? DBNull.Value
            //}
        };
    }

    private FilterResult BuildIn(
        string column,
        FilterDefinition filter,
        ref int parameterIndex)
    {
        var values = filter.Values ?? throw new InvalidOperationException("In requires at least one value.");
        var result = new FilterResult();
        var parameters = new List<string>();

        //foreach (object value in values)
        //{
        //    string parameterName = $"@p{parameterIndex++}";
        //    parameters.Add(parameterName);
        //    result.Parameters[parameterName] = value ?? DBNull.Value;
        //}

        result.Sql = $"{column} IN ({string.Join(", ", values)})";
        return result;
    }

}


public class FilterResult
{
    public string Sql { get; set; } = string.Empty;

    public Dictionary<string, object?> Parameters { get; } = new();
}
