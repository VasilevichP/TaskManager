using WpfApp1.Models;

namespace WpfApp1.Services;

public interface IDataService
{
    List<TodoItem> LoadTasks();
    void SaveTasks(IEnumerable<TodoItem> tasks);
}