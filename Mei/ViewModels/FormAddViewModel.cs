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
    public class FormAddViewModel : ViewModelBase
    {
        //Transfer All To MainViewModel????
        private string? itemName;
        public ObservableCollection<string> Categories { get; }

        public string? ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                OnPropertyChanged();
            }
        }

        private string? itemDescription;

        public string? ItemDescription
        {
            get { return itemDescription; }
            set
            {
                itemDescription = value;
                OnPropertyChanged();
            }
        }

        private string? itemCategory;

        public string? ItemCategory
        {
            get { return itemCategory; }
            set
            {
                itemCategory = value;
                OnPropertyChanged();
            }
        }

        private int itemQuantity;

        public int ItemQuantity
        {
            get { return itemQuantity; }
            set
            {
                itemQuantity = value;
                OnPropertyChanged();
            }
        }


        public ICommand FormAddSubmitCommand { get; }
        public ICommand FormAddCancelCommand { get; }

        private readonly NavigationStore _navigationStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;
        private readonly IItemRepository _itemRepository;

        public FormAddViewModel(IItemRepository itemRepository, NavigationStore navigationStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _navigationStore = navigationStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
            _itemRepository = itemRepository;

            Categories = _categoryStore.CategoryToStore;

            //Remove Passing of Viewmodels

            FormAddSubmitCommand = new FormAddSubmitCommand(this, _itemRepository, _refreshStore, _categoryStore);
            FormAddCancelCommand = new FormAddCancelCommand();

        }


    }
}
