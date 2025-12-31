using Mei.Commands;
using Mei.Interfaces;
using Mei.Models;
using Mei.MVVM;
using Mei.Services;
using Mei.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Mei.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {


        //public RelayCommand LoginCommand => new RelayCommand(execute => Login());

        public ICommand LoginCommand { get; }


        private string statusMessage;
        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }

        private string inputUsername;

        public string InputUsername
        {
            get { return inputUsername; }
            set { inputUsername = value; }
        }

        private string inputPassword;

        public string InputPassword
        {
            get { return inputPassword; }
            set { inputPassword = value;}


        }


        public bool isCredCorrect = false;

        private readonly AuthService _authService;
        private readonly NavigationStore _navigationStore;
        private readonly VMFactory _vMFactory;
        private readonly LoginViewModel _loginViewModel;
        private readonly IItemRepository _itemRepository;
        //private readonly SQLfunctions _sQLfunctions;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        // Remove LoginViewModel parameter and use 'this' for the command
        public LoginViewModel(NavigationStore navigationStore, AuthService authService, VMFactory vMFactory, IItemRepository itemRepository, EditItemStore editItemStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _navigationStore = navigationStore;
            _authService = authService;
            _vMFactory = vMFactory;
            _itemRepository = itemRepository;

            _editItemStore = editItemStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;

            LoginCommand = new LoginCommand(_navigationStore, _authService, _vMFactory, this, _itemRepository, _editItemStore, _refreshStore, _categoryStore);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }



    }

}

