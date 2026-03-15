using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views;

public partial class AddTodoView : Window
{
    public AddTodoView()
    {
        InitializeComponent();
    }
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
    }
}