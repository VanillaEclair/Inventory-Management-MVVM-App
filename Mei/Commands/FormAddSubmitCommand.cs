using Mei.Interfaces;
using Mei.Models;
using Mei.Stores;
using Mei.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Mei.Commands
{
    public class FormAddSubmitCommand : CommandBaseAsync
    {


        private readonly FormAddViewModel _formAddViewModel;
        //private readonly SQLfunctions _sQlFunctions;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;
        private readonly IItemRepository _itemRepository;


        public FormAddSubmitCommand(FormAddViewModel viewModel, IItemRepository itemRepository, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _formAddViewModel = viewModel;
            _formAddViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
            _itemRepository = itemRepository;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            var window = parameter as Window;

            await _itemRepository.AddQueryAsync(
                new AddItem(
                    0,
                    _formAddViewModel.ItemName,
                    _formAddViewModel.ItemDescription,
                    _formAddViewModel.ItemCategory,
                    _formAddViewModel.ItemQuantity
                )
            );

            _refreshStore.RequestRefresh();
            window?.Close();
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter)
                && !string.IsNullOrWhiteSpace(_formAddViewModel.ItemName)
                && !string.IsNullOrWhiteSpace(_formAddViewModel.ItemDescription)
                && !string.IsNullOrWhiteSpace(_formAddViewModel.ItemCategory)
                && _formAddViewModel.ItemQuantity > 0;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FormAddViewModel.ItemName) ||
                e.PropertyName == nameof(FormAddViewModel.ItemDescription) ||
                e.PropertyName == nameof(FormAddViewModel.ItemCategory) ||
                e.PropertyName == nameof(FormAddViewModel.ItemQuantity))
            {
                RaiseCanExecuteChanged();
            }
        }


        //Backup
        //public override bool CanExecute(object? parameter)
        //{
        //    return base.CanExecute(parameter) &&
        //           !string.IsNullOrEmpty(_formAddViewModel.ItemName) &&
        //           !string.IsNullOrEmpty(_formAddViewModel.ItemDescription) &&
        //           !string.IsNullOrEmpty(_formAddViewModel.ItemCategory) &&
        //           _formAddViewModel.ItemQuantity > 0;
        //}

        //public override void Execute(object? parameter)
        //{
        //    //AddItem addItem = new AddItem(0, 
        //    //    _formAddViewModel.ItemName, 
        //    //    _formAddViewModel.ItemDescription, 
        //    //    _formAddViewModel.ItemCategory, 
        //    //    _formAddViewModel.ItemQuantity);

        //    Window window = parameter as Window;



        //    try
        //    {

        //        //ADD Interface
        //        _sQlFunctions.AddQuery(new AddItem(0,
        //                _formAddViewModel.ItemName,
        //                _formAddViewModel.ItemDescription,
        //                _formAddViewModel.ItemCategory,
        //                _formAddViewModel.ItemQuantity)
        //            );

        //        MessageBox.Show("Items Added Theorethically");

        //        _refreshStore.RequestRefresh();

        //        window.Close();



        //        //Pass to Services?
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error Occured!");
        //    }

        //    }

    }
}



//BACKUP ============================================================================
//private readonly FormAddViewModel _formAddViewModel;
//private readonly SQLfunctions _sQlFunctions;
//private readonly RefreshStore _refreshStore;
//private readonly CategoryStore _categoryStore;


//public FormAddSubmitCommand(FormAddViewModel viewModel, SQLfunctions sQlFunctions, RefreshStore refreshStore, CategoryStore categoryStore)
//{
//    _formAddViewModel = viewModel;
//    _formAddViewModel.PropertyChanged += OnViewModelPropertyChanged;
//    _sQlFunctions = sQlFunctions;
//    _refreshStore = refreshStore;
//    _categoryStore = categoryStore;
//}

//private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
//{
//    if (e.PropertyName == nameof(FormAddViewModel.ItemName) ||
//        e.PropertyName == nameof(FormAddViewModel.ItemDescription) ||
//        e.PropertyName == nameof(FormAddViewModel.ItemCategory) ||
//        e.PropertyName == nameof(FormAddViewModel.ItemQuantity))
//    {
//        OnCanExexutedChanged();
//    }
//}

//public override bool CanExecute(object? parameter)
//{
//    return base.CanExecute(parameter) &&
//           !string.IsNullOrEmpty(_formAddViewModel.ItemName) &&
//           !string.IsNullOrEmpty(_formAddViewModel.ItemDescription) &&
//           !string.IsNullOrEmpty(_formAddViewModel.ItemCategory) &&
//           _formAddViewModel.ItemQuantity > 0;
//}

//public override void Execute(object? parameter)
//{
//    //AddItem addItem = new AddItem(0, 
//    //    _formAddViewModel.ItemName, 
//    //    _formAddViewModel.ItemDescription, 
//    //    _formAddViewModel.ItemCategory, 
//    //    _formAddViewModel.ItemQuantity);

//    Window window = parameter as Window;



//    try
//    {

//        //ADD Interface
//        _sQlFunctions.AddQuery(new AddItem(0,
//                _formAddViewModel.ItemName,
//                _formAddViewModel.ItemDescription,
//                _formAddViewModel.ItemCategory,
//                _formAddViewModel.ItemQuantity)
//            );

//        MessageBox.Show("Items Added Theorethically");

//        _refreshStore.RequestRefresh();

//        window.Close();



//        //Pass to Services?
//    }
//    catch (Exception)
//    {
//        MessageBox.Show("Error Occured!");
//    }

//}
//    }
