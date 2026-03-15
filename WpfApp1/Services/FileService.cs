using System.IO;
using System.Text.Json;
using WpfApp1.Models;

namespace WpfApp1.Services;

public class FileService:IDataService
{
    private const string FilePath = "tasks.json";
    
    public async Task<List<TodoItem>> LoadTasksAsync()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TodoItem>();
        }

        try
        {
            using FileStream openStream = File.OpenRead(FilePath);
            return await JsonSerializer.DeserializeAsync<List<TodoItem>>(openStream) 
                   ?? new List<TodoItem>();
        }
        catch (JsonException)
        {
            return new List<TodoItem>();
        }
    }

    public async Task SaveTasksAsync(IEnumerable<TodoItem> tasks)
    {
        using FileStream createStream = File.Create(FilePath);
        await JsonSerializer.SerializeAsync(createStream, tasks);
    }
    
}