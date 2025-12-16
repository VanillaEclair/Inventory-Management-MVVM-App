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
    public class FormUpdateSubmitCommand : CommandBase
    {
        private readonly FormUpdateViewModel _formUpdateViewModel;
        private readonly SQLfunctions _sQLfunctions;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly RefreshStore _refreshStore;

        public FormUpdateSubmitCommand(FormUpdateViewModel formUpdateViewModel, SQLfunctions sQLfunctions, RefreshStore refreshStore)
        {
            _formUpdateViewModel = formUpdateViewModel;
            _sQLfunctions = sQLfunctions;
            _refreshStore = refreshStore;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(FormUpdateViewModel.ItemName) ||
               e.PropertyName == nameof(FormUpdateViewModel.ItemDescription) ||
               e.PropertyName == nameof(FormUpdateViewModel.ItemCategory) ||
               e.PropertyName == nameof(FormUpdateViewModel.ItemQuantity))
            {
                OnCanExexutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) &&
           !string.IsNullOrEmpty(_formUpdateViewModel.ItemName) &&
           !string.IsNullOrEmpty(_formUpdateViewModel.ItemDescription) &&
           !string.IsNullOrEmpty(_formUpdateViewModel.ItemCategory) &&
           _formUpdateViewModel.ItemQuantity > 0;
        }
        
        public override void Execute(object? parameter)
        {

            //Mayber Pass parameters Data directly?

            _sQLfunctions.UpdateQuery(new AddItem(
             _formUpdateViewModel.ItemID,
            _formUpdateViewModel.ItemName,
            _formUpdateViewModel.ItemDescription,
            _formUpdateViewModel.ItemCategory,
            _formUpdateViewModel.ItemQuantity)
        );

            _refreshStore.RequestRefresh();


        }
    }
}
