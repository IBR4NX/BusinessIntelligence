namespace Domain.Definition;

public enum FilterValueType
{
    Value,
    Column
}

public class FilterDefinition
{
    public string ColumnName { get; set; } = string.Empty;

    public ComparisonOperator Operator { get; set; }

    public FilterValueType? ValueType { get; set; }

    public object? Value { get; set; }

    public string? ValueColumnName { get; set; }

    public List<object> Values { get; set; } = new();

    public LogicalOperator? LogicalOperator { get; set; }

}
