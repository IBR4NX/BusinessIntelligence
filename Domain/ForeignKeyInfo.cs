namespace Domain;

public class ForeignKeyInfo
{
    public string Name { get; set; } = string.Empty;

    public string ColumnName { get; set; } = string.Empty;

    public string ReferencedTable { get; set; } = string.Empty;

    public string ReferencedColumn { get; set; } = string.Empty;
}