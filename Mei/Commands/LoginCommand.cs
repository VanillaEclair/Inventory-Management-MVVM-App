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
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;



        //public LoginCommand(NavigationStore navigateStore, AuthService authService, VMFactory vMFactory)

        public LoginCommand(NavigationStore navigateStore, AuthService authService, VMFactory vmFactory, LoginViewModel loginViewModel, SQLfunctions sQLfunctions, EditItemStore editItemStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _navigateStore = navigateStore;
            _authService = authService;
            _vmFactory = vmFactory ?? throw new ArgumentNullException(nameof(vmFactory));
            _loginViewModel = loginViewModel;
            _sQLfunctions = sQLfunctions;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
        }

        public override void Execute(object? parameter)
        {

            var username = _loginViewModel.InputUsername;
            var password = _loginViewModel.InputPassword; 
 
            bool isUser = _authService.Authenticate(username, password);

            if (isUser)
            {
                _loginViewModel.StatusMessage = "Correct Pass";
                MessageBox.Show("User");
                _navigateStore.CurrentViewModel = new MainWindowViewModel(_vmFactory, _navigateStore, _sQLfunctions, _editItemStore, _refreshStore, _categoryStore);
            } 
            else
            {
                _loginViewModel.StatusMessage = "Correct Pass";
                MessageBox.Show("Not User");
                _navigateStore.CurrentViewModel = new MainWindowViewModel(_vmFactory, _navigateStore, _sQLfunctions, _editItemStore, _refreshStore, _categoryStore);
            }
        }
    }
}
