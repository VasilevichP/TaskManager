using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModels;

public partial class ApplicationViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;
}