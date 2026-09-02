namespace Domain.Definition;

public class QueryDefinition
{
    public string SchemaName { get; set; } = "dbo";

    public string TableName { get; set; } = string.Empty;

    public List<string> SelectedColumns { get; set; } = new();

    public List<FilterDefinition> Filters { get; set; } = new();

    public string? OrderBy { get; set; }

    public bool Descending { get; set; }

    public List<JoinDefinition> Joins { get; set; } = new();
}