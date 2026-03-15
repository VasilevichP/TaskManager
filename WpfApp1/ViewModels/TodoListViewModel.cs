using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.Views;

namespace WpfApp1.ViewModels;

public partial class TodoListViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    public ObservableCollection<TodoItem> Tasks { get; } = new();
        
    public TodoListViewModel(INavigationService navigationService, IDataService dataService)
    {
        _navigationService = navigationService;
        _dataService = dataService;
        
        var loadedTasks = _dataService.LoadTasks();
        Tasks = new ObservableCollection<TodoItem>(loadedTasks);
    }

    [RelayCommand]
    private void ShowAddDialog()
    {
        var vm = App.ServiceProvider.GetRequiredService<AddTodoViewModel>();
        var view = new AddTodoView { DataContext = vm, Owner = App.Current.MainWindow };
        if (view.ShowDialog() == true && vm.ResultTask != null)
        {
            Tasks.Add(vm.ResultTask);
            _dataService.SaveTasks(Tasks);
        }
    }

    [RelayCommand]
    private void GoToDetails(TodoItem task)
    {
        if (task != null)
        {
            _navigationService.NavigateTo("TodoDetail", task);
        }
    }
}