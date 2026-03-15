namespace WpfApp1.Services;

public interface INavigationService
{
    void NavigateTo(string viewName, object? parameter = null);
}