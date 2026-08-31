namespace Domain.Settings;

public class ConnectionSettings
{
    public string Server { get; set; } = string.Empty;

    public string Database { get; set; } = string.Empty;

    public AuthenticationType Authentication { get; set; } = AuthenticationType.Windows;

    //public bool UseWindowsAuthentication { get; set; } = true;

    public string? Username { get; set; }
}

public enum AuthenticationType
{
    Windows,
    SqlServer
}