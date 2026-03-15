using WpfApp1.Models;

namespace WpfApp1.Services;

public interface IDataService
{
    Task<List<TodoItem>> LoadTasksAsync();
    Task SaveTasksAsync(IEnumerable<TodoItem> tasks);
}