using Domain.Settings;
using System.Text.Json;

namespace Infrastructure.Settings;

public class ConnectionSettingsStore
{
    private readonly string _filePath;

    public ConnectionSettingsStore(string filePath)
    {
        _filePath = filePath;

        string? directory = Path.GetDirectoryName(_filePath);

        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);
    }

    public ConnectionSettingsCollection Load()
    {
        if (!File.Exists(_filePath))
            return new ConnectionSettingsCollection();

        string json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
            return new ConnectionSettingsCollection();

        return JsonSerializer.Deserialize<ConnectionSettingsCollection>(json)
               ?? new ConnectionSettingsCollection();
    }

    public void Save(ConnectionSettings settings)
    {
        var collection = Load();


        bool exists = checkEquals(settings, collection);

        if (!exists)
        {
            collection.Connections.Add(settings);
        }

        string json = JsonSerializer.Serialize(
            collection,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(_filePath, json);
    }
    private bool checkEquals(ConnectionSettings settings, ConnectionSettingsCollection collection)
    {
        return collection.Connections.Any(x =>
            string.Equals(x.Server, settings.Server,
                StringComparison.OrdinalIgnoreCase) &&
            string.Equals(x.Database, settings.Database,
                StringComparison.OrdinalIgnoreCase));
    }
}