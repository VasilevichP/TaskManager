using System.IO;
using System.Text.Json;
using WpfApp1.Models;

namespace WpfApp1.Services;

public class FileService:IDataService
{
    private const string FilePath = "tasks.json";
    
    public List<TodoItem> LoadTasks()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TodoItem>();
        }

        try
        {
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
        }
        catch (JsonException)
        {
            return new List<TodoItem>();
        }
    }

    public void SaveTasks(IEnumerable<TodoItem> tasks)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(FilePath, json);
    }
    
}