namespace Domain.Definition;

public class JoinDefinition
{
    public string TableName { get; set; } = string.Empty;

    public string LeftColumn { get; set; } = string.Empty;

    public string RightColumn { get; set; } = string.Empty;

    public JoinType JoinType { get; set; } = JoinType.Inner;
}