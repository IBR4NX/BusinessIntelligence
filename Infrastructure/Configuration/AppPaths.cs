namespace Infrastructure.Configuration;

public static class AppPaths
{
    public static string ApplicationFolder =>
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "BusinessIntelligence");

    public static string ConnectionsFile =>
        Path.Combine(
            ApplicationFolder,
            "connections.json");
}