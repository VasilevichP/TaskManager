using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Models;
using WpfApp1.Services;
using TaskStatus = WpfApp1.Models.TaskStatus;

namespace WpfApp1.ViewModels;

public partial class TodoDetailViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService; 
    private readonly TodoListViewModel _todoListVM;
    
    private TodoItem? _originalTask;

    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty] private DateTime? _dueDate;
    [ObservableProperty] private TaskStatus _status;

    public TodoDetailViewModel(INavigationService navigationService, IDataService dataService, TodoListViewModel todoListVm)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        _todoListVM = todoListVm;
    }

    public void Initialize(TodoItem task)
    {
        _originalTask = task;
        Title = task.Title;
        DueDate = task.DueDate;
        Status = task.Status;
    }

    [RelayCommand]
    private void SaveChanges()
    {
        if (_originalTask != null)
        {
            _originalTask.Title = this.Title;
            _originalTask.DueDate = this.DueDate;
            _originalTask.Status = this.Status;
            
            _dataService.SaveTasks(_todoListVM.Tasks);
        }
        _navigationService.NavigateTo("TodoList");
    }

    [RelayCommand]
    private void Cancel()
    {
        _navigationService.NavigateTo("TodoList");
    }
}