using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.Models;

public partial class TodoItem : ObservableObject
{
    [ObservableProperty] private string? title;

    [ObservableProperty] private DateTime? dueDate;

    [ObservableProperty] private TodoStatus status;
}