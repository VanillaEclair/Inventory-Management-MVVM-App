using Mei.Commands;
using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Stores
{
    public class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigateStore;
        private readonly AuthService _authService;

        public NavigateHomeCommand(AuthService authService)
        {
            _authService = authService;
        }

        public NavigateHomeCommand(NavigationStore navigateStore)
        {
            _navigateStore = navigateStore;
        }

        private SQLfunctions sQLfunctions;

        public override void Execute(object? parameter)
        {
            sQLfunctions = new SQLfunctions();
            //string query = "";
            //_navigateStore.CurrentViewModel = new MainWindowViewModel();
            //bool IsUser = _authService.Authenticate("admin", "1234"); ;//sQLfunctions.DBquery(query);

            //if (IsUser)
            //{
            //    _navigateStore.CurrentViewModel = new MainWindowViewModel();
            //}
            //else
            //{
            //    _navigateStore.CurrentViewModel = new MainWindowViewModel();
            //}
            
        }
    }
}
