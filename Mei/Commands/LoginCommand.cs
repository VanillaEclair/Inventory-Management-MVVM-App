using Mei.Interfaces;
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
    public class LoginCommand : CommandBaseAsync
    {
        private readonly NavigationStore _navigateStore;
        private readonly AuthService _authService;
        private readonly VMFactory _vmFactory;
        private readonly LoginViewModel _loginViewModel;
        private readonly IItemRepository _itemRepository;
        //private readonly SQLfunctions _sQLfunctions;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;



        //public LoginCommand(NavigationStore navigateStore, AuthService authService, VMFactory vMFactory)

        public LoginCommand(NavigationStore navigateStore, AuthService authService, VMFactory vmFactory, LoginViewModel loginViewModel, IItemRepository itemRepository, EditItemStore editItemStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _navigateStore = navigateStore;
            _authService = authService;
            _vmFactory = vmFactory ?? throw new ArgumentNullException(nameof(vmFactory));
            _loginViewModel = loginViewModel;
            //_sQLfunctions = sQLfunctions;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
            _itemRepository = itemRepository;
        }

        protected override async Task ExecuteAsync(object? parameter)
    {
        var username = _loginViewModel.InputUsername;
        var password = _loginViewModel.InputPassword;

        bool isUser = await _authService.AuthenticateAsync(username, password);

        if (isUser)
        {
            _loginViewModel.StatusMessage = "Correct Pass";
            MessageBox.Show("User");
        }
        else
        {
            _loginViewModel.StatusMessage = "Wrong Pass";
            MessageBox.Show("Not User");
        }

        _navigateStore.CurrentViewModel = new MainWindowViewModel(_vmFactory, _navigateStore, _itemRepository, _editItemStore, _refreshStore, _categoryStore);
    }
    }
}
