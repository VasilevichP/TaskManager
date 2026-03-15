using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using WpfApp1.Models;
using TaskStatus = System.Threading.Tasks.TaskStatus;

namespace WpfApp1.ViewModels;

public partial class AddTodoViewModel : ObservableObject
{
    public TodoItem? ResultTask { get; private set; }
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string _title = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private DateTime? _dueDate = DateTime.Now;
    
    [RelayCommand(CanExecute = nameof(CanSave))]
    private void Save()
    {
        ResultTask = new TodoItem
        {
            Title = this.Title,
            DueDate = this.DueDate,
            Status = Models.TaskStatus.New
        };
    }

    private bool CanSave()
    {
        return !string.IsNullOrWhiteSpace(Title) && DueDate.HasValue;
    }
}