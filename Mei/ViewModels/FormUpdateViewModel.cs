using Mei.Commands;
using Mei.Interfaces;
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
    public class FormUpdateViewModel: ViewModelBase
    {
		private int itemID;
        public ObservableCollection<string> Categories { get; }

        public int ItemID
		{
			get { return itemID; }
			set { 
				itemID = value;
                OnPropertyChanged();
				}
		}

		private string? itemName;

		public string? ItemName
		{
			get { return itemName; }
			set { 
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

		private string? selectedCategory;

		public string? SelectedCategory
        {
			get { return selectedCategory; }
			set 
			{
                selectedCategory = value;
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




		//      public void AddItem()
		//{
		//	//SQL Query
		//	SQLfunctions sql = new SQLfunctions();
		//	//sql.AddQuery("AsmonGold", "Cockroach", "Streamer", "Somewhere");
		//}

		//public void Cancel()
		//{

		//}'

		private readonly EditItemStore _editItemStore;
		private readonly RefreshStore _refreshStore;
		private readonly CategoryStore _categoryStore;
		private readonly IItemRepository _itemRepository;

		public ICommand FormSubmitCommand { get; }
		public ICommand FormCancelCommand { get; }

        public FormUpdateViewModel(EditItemStore editItemStore, IItemRepository itemRepository, RefreshStore refreshStore, CategoryStore categoryStore)
        {

            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
            _itemRepository = itemRepository;


            var Item = editItemStore.ItemToEdit;


            Categories = _categoryStore.CategoryToStore;

            ItemID = Item.ItemID;
            ItemName = Item.ItemName;
            SelectedCategory = Item.ItemCategory;
            ItemDescription = Item.ItemDescription;
            ItemQuantity = Item.ItemQty;





            FormSubmitCommand = new FormUpdateSubmitCommand(this, _itemRepository, _refreshStore);
            FormCancelCommand = new FormAddCancelCommand();





            //ItemID = _mainWindowViewModel.SelectedItem.ItemID;
            //         ItemName = _mainWindowViewModel.SelectedItem.ItemName;
            //         ItemDescription = _mainWindowViewModel.SelectedItem.ItemDescription;
            //         ItemCategory = _mainWindowViewModel.SelectedItem.ItemCategory;
            //         ItemQuantity = _mainWindowViewModel.SelectedItem.ItemQty;
        }



    }
}
