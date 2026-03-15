using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.Services;

public class NavigationService:ObservableObject, INavigationService
{
    private readonly Func<string, object?, ObservableObject> _viewModelFactory;

    private ObservableObject? _currentViewModel;
    public ObservableObject? CurrentViewModel
    {
        get => _currentViewModel;
        private set => SetProperty(ref _currentViewModel, value);
    }

    public NavigationService(Func<string, object?, ObservableObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo(string viewName, object? parameter = null)
    {
        CurrentViewModel = _viewModelFactory(viewName, parameter);
    }
}