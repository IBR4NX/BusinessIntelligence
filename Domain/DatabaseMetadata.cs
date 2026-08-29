namespace Domain;

public class DatabaseMetadata
{
    public List<string> Tables { get; set; } = new();

    public Dictionary<string, List<ColumnInfo>> Columns { get; set; }
        = new(StringComparer.OrdinalIgnoreCase);
}