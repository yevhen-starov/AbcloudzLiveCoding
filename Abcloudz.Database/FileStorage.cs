using Abcloudz.Database.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Abcloudz.Database;

public interface IDataStorage<T>
{
    Task<List<T>> LoadAsync();
    Task AddAsync(T data);
}

public class FileStorage<T> : IDataStorage<T>
{
    private readonly string _filePath;

    public FileStorage(IOptions<StorageSettings> options)
    {
        _filePath = options.Value.FilePath;
        EnsureFileExists();
    }

    public async Task<List<T>> LoadAsync()
    {
        var lines = await File.ReadAllLinesAsync(_filePath);
        return lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => JsonConvert.DeserializeObject<T>(line)!)
            .ToList();
    }

    public async Task AddAsync(T data)
    {
        var json = JsonConvert.SerializeObject(data);
        await File.AppendAllTextAsync(_filePath, json + Environment.NewLine);
    }
    
    private void EnsureFileExists()
    {
        var dir = Path.GetDirectoryName(_filePath)!;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "");
        }
    }
}