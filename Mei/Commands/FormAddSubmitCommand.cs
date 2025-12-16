using Mei.Models;
using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    public class FormAddSubmitCommand : CommandBase
    {


        private readonly FormAddViewModel _formAddViewModel;
        private readonly SQLfunctions _sQlFunctions;
        private readonly RefreshStore _refreshStore;


        public FormAddSubmitCommand(FormAddViewModel viewModel, SQLfunctions sQlFunctions, RefreshStore refreshStore)
        {
            _formAddViewModel = viewModel;
            _formAddViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _sQlFunctions = sQlFunctions;
            _refreshStore = refreshStore;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FormAddViewModel.ItemName) ||
                e.PropertyName == nameof(FormAddViewModel.ItemDescription) ||
                e.PropertyName == nameof(FormAddViewModel.ItemCategory) ||
                e.PropertyName == nameof(FormAddViewModel.ItemQuantity))
            {
                OnCanExexutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) &&
                   !string.IsNullOrEmpty(_formAddViewModel.ItemName) &&
                   !string.IsNullOrEmpty(_formAddViewModel.ItemDescription) &&
                   !string.IsNullOrEmpty(_formAddViewModel.ItemCategory) &&
                   _formAddViewModel.ItemQuantity > 0;
        }

        public override void Execute(object? parameter)
        {
            //AddItem addItem = new AddItem(0, 
            //    _formAddViewModel.ItemName, 
            //    _formAddViewModel.ItemDescription, 
            //    _formAddViewModel.ItemCategory, 
            //    _formAddViewModel.ItemQuantity);

            Window window = parameter as Window;



            try
            {

                //ADD Interface
                _sQlFunctions.AddQuery(new AddItem(0,
                        _formAddViewModel.ItemName,
                        _formAddViewModel.ItemDescription,
                        _formAddViewModel.ItemCategory,
                        _formAddViewModel.ItemQuantity)
                    );

                MessageBox.Show("Items Added Theorethically");


                window.Close();

                _refreshStore.RequestRefresh();

                //Pass to Services?
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured!");
            }
               
        }
    }
}
