using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WpfApp1.Models;
using WpfApp1.Services;
using WpfApp1.ViewModels;

namespace WpfApp1;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // 1. Регистрация сервисов
            services.AddSingleton<INavigationService>(provider => {
                var viewModelFactory = new Func<string, object?, CommunityToolkit.Mvvm.ComponentModel.ObservableObject>((viewName, param) => {
                    switch (viewName)
                    {
                        case "TodoList":
                            return provider.GetRequiredService<TodoListViewModel>();
                        case "TodoDetail":
                            if (param is TodoItem task) {
                                var vm = provider.GetRequiredService<TodoDetailViewModel>();
                                vm.Initialize(task);
                                return vm;
                            }
                            throw new ArgumentException("Неверный параметр для TodoDetailViewModel");
                        default:
                            throw new ArgumentException($"Неизвестная ViewModel: {viewName}");
                    }
                });
                return new NavigationService(viewModelFactory);
            });

            // 2. Регистрация ViewModel
            services.AddSingleton<ApplicationViewModel>();
            services.AddSingleton<IDataService,FileService>();
            services.AddSingleton<TodoListViewModel>();
            services.AddTransient<TodoDetailViewModel>();
            services.AddTransient<AddTodoViewModel>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var navigationService = (NavigationService)ServiceProvider.GetRequiredService<INavigationService>();
            var appViewModel = ServiceProvider.GetRequiredService<ApplicationViewModel>();
            
            navigationService.PropertyChanged += (s, args) => {
                if (args.PropertyName == nameof(NavigationService.CurrentViewModel))
                {
                    appViewModel.CurrentViewModel = navigationService.CurrentViewModel;
                }
            };
            
            var mainWindow = new MainWindow { DataContext = appViewModel };
            mainWindow.Show();
            
            navigationService.NavigateTo("TodoList");
        }
    }