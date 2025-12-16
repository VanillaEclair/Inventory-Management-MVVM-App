using Mei.Commands;
using Mei.MVVM;
using Mei.Services;
using Mei.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mei.ViewModels
{
    public class FormUpdateViewModel: ViewModelBase
    {
		private int itemID;

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




		//      public void AddItem()
		//{
		//	//SQL Query
		//	SQLfunctions sql = new SQLfunctions();
		//	//sql.AddQuery("AsmonGold", "Cockroach", "Streamer", "Somewhere");
		//}

		//public void Cancel()
		//{

		//}'


		private readonly MainWindowViewModel _mainWindowViewModel;
		private readonly EditItemStore _editItemStore;
		private readonly SQLfunctions _sQLfunctions;
		private readonly RefreshStore _refreshStore;

		public ICommand FormSubmitCommand { get; }
		public ICommand FormCancelCommand { get; }

        public FormUpdateViewModel(EditItemStore editItemStore, SQLfunctions sQLfunctions, RefreshStore refreshStore)
        {

            var Item = editItemStore.ItemToEdit;

            ItemID = Item.ItemID;
            ItemName = Item.ItemName;
            ItemCategory = Item.ItemCategory;
            ItemDescription = Item.ItemDescription;
            ItemQuantity = Item.ItemQty;


            _sQLfunctions = sQLfunctions;
            _refreshStore = refreshStore;


            FormSubmitCommand = new FormUpdateSubmitCommand(this, _sQLfunctions, _refreshStore);



            //ItemID = _mainWindowViewModel.SelectedItem.ItemID;
            //         ItemName = _mainWindowViewModel.SelectedItem.ItemName;
            //         ItemDescription = _mainWindowViewModel.SelectedItem.ItemDescription;
            //         ItemCategory = _mainWindowViewModel.SelectedItem.ItemCategory;
            //         ItemQuantity = _mainWindowViewModel.SelectedItem.ItemQty;
        }



    }
}
