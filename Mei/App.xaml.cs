using Mei.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Mei.Models;
using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace Mei
{

    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {

            var services = new ServiceCollection();
            services.AddAppServices();     // Regi DIs

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = _serviceProvider.GetRequiredService<NavigationStore>();

            // First screen
            navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();

            MainWindow = new MainWindow()
            {
                DataContext = _serviceProvider.GetRequiredService<LoginViewModel>()
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    //public partial class App : Application
    //{
    //    //public readonly MainViewModel _mainViewModel;

    //    //public App(MainViewModel mainViewModel)
    //    //{
    //    //    _mainViewModel = mainViewModel;
    //    //}

    //    //private readonly NavigationStore _navigationStore;
    //    //private readonly VMFactory _factory;
    //    private ServiceProvider _serviceProvider;


    //    public App()
    //    {
    //        //_navigationStore = new NavigationStore();
    //        var services = new ServiceCollection();

    //        services.AddAppServices();

    //        services.AddSingleton<NavigationStore>();
    //        services.AddSingleton<AuthService>();
    //        services.AddSingleton<AddItem>();           // dependency of VMFactory
    //        services.AddSingleton<VMFactory>();
    //        services.AddSingleton<EditItemStore>();// VMFactory depends on AddItem
    //        services.AddSingleton<LoginViewModel>();    // if using DI to resolve it
    //        services.AddSingleton<MainWindowViewModel>();

    //        _serviceProvider = services.BuildServiceProvider();
    //    }


    //    protected override void OnStartup(StartupEventArgs e)
    //    {
    //        //NavigationStore navigationStore = new NavigationStore();
    //        //FormAddNavStore formaddnavigatioStore = new FormAddNavStore();

    //        // Create repository or services needed by factory
    //        //ItemRepository itemRepo = new ItemRepository();


    //        // Create the factory correctly
    //        //var factory = new VMFactory(itemRepo);


    //        //navigationStore.CurrentViewModel = new MainWindowViewModel(_factory);
    //        //navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);

    //        var navigationStore = _serviceProvider.GetRequiredService<NavigationStore>();

    //        navigationStore.CurrentViewModel = _serviceProvider.GetRequiredService<LoginViewModel>();


    //        MainWindow = new MainWindow()
    //        {
    //            //DataContext = new MainViewModel(navigationStore, formaddnavigatioStore)
    //            DataContext = _serviceProvider.GetRequiredService<LoginViewModel>()
    //        };

    //        MainWindow.Show();
    //        base.OnStartup(e);
    //    }
    //}

}
