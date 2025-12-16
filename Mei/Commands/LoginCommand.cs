using Mei.Models;
using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly NavigationStore _navigateStore;
        private readonly AuthService _authService;
        private readonly VMFactory _vmFactory;
        private readonly LoginViewModel _loginViewModel;
        private readonly SQLfunctions _sQLfunctions;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;



        //public LoginCommand(NavigationStore navigateStore, AuthService authService, VMFactory vMFactory)

        public LoginCommand(NavigationStore navigateStore, AuthService authService, VMFactory vmFactory, LoginViewModel loginViewModel, SQLfunctions sQLfunctions, MainWindowViewModel mainWindowViewModel, EditItemStore editItemStore, RefreshStore refreshStore)
        {
            _navigateStore = navigateStore;
            _authService = authService;
            _vmFactory = vmFactory ?? throw new ArgumentNullException(nameof(vmFactory));
            _loginViewModel = loginViewModel;
            _sQLfunctions = sQLfunctions;
            _mainWindowViewModel = mainWindowViewModel;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;
        }

        public override void Execute(object? parameter)
        {
            //Button Should not work when empty


            // Use the existing viewmodel values directly
            var username = _loginViewModel.InputUsername;
            var password = _loginViewModel.InputPassword; // <-- was incorrectly username
 
            bool isUser = _authService.Authenticate(username, password);

            if (isUser)
            {
                MessageBox.Show("User");
                // Navigate using a properly injected factory (adjust call to match your VMFactory API)
                _navigateStore.CurrentViewModel = new MainWindowViewModel(_vmFactory, _navigateStore, _sQLfunctions, _editItemStore, _refreshStore);
            } 
            else
            {
                MessageBox.Show("Not User");
                _navigateStore.CurrentViewModel = new MainWindowViewModel(_vmFactory, _navigateStore, _sQLfunctions, _editItemStore, _refreshStore);
                // keep on login screen or navigate appropriately
            }
        }
    }
}
