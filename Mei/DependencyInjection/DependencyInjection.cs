using Mei.Models;
using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Navigation;

namespace Mei.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            // STORES
            services.AddSingleton<RefreshStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<EditItemStore>();
            services.AddSingleton<CategoryStore>();

            // SERVICES
            services.AddSingleton<NavigationService>();
            services.AddTransient<AuthService>();
            services.AddTransient<SQLfunctions>();

            // FACTORY
            services.AddSingleton<VMFactory>();

            // VIEWMODELS
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<FormAddViewModel>();
            services.AddTransient<FormUpdateViewModel>();

            return services;
        }
    }

    //public static class DependencyInjection
    //{
    //    public static IServiceCollection AddAppServices(this IServiceCollection services)
    //    {
    //        services.AddSingleton<NavigationStore>();

    //        services.AddSingleton<NavigationService>();
    //        services.AddSingleton<EditItemStore>();
    //        services.AddTransient<AuthService>();
    //        services.AddTransient<SQLfunctions>();

    //        services.AddTransient<MainWindowViewModel>();
    //        services.AddTransient<MainViewModel>();
    //        services.AddTransient<LoginViewModel>();
    //        services.AddTransient<FormAddViewModel>();
    //        services.AddTransient<FormUpdateViewModel>();

    //        return services;

    //    }
    //}
}
