namespace Domain;

public class ColumnInfo
{
    public string Name { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public bool IsNullable { get; set; }
    public int OrdinalPosition { get; set; }
    public int? MaxLength { get; set; }
    public byte? NumericPrecision { get; set; }
    public int? NumericScale { get; set; }
    public string? DefaultValue { get; set; }
    public bool IsPrimaryKey { get; set; }
    public bool IsForeignKey { get; set; }
    public string? ReferencedTable { get; set; }
    public string? ReferencedColumn { get; set; }
}