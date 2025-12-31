using Mei.Interfaces;
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
    public class FormUpdateSubmitCommand : CommandBaseAsync
    {
        private readonly FormUpdateViewModel _formUpdateViewModel;
        private readonly RefreshStore _refreshStore;
        private readonly IItemRepository _itemRepository;

        public FormUpdateSubmitCommand(FormUpdateViewModel formUpdateViewModel, IItemRepository itemRepository, RefreshStore refreshStore)
        {
            _formUpdateViewModel = formUpdateViewModel;
            _formUpdateViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _refreshStore = refreshStore;
            _itemRepository = itemRepository;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FormUpdateViewModel.ItemName) ||
                e.PropertyName == nameof(FormUpdateViewModel.ItemDescription) ||
                e.PropertyName == nameof(FormUpdateViewModel.SelectedCategory) ||
                e.PropertyName == nameof(FormUpdateViewModel.ItemQuantity))
            {
                RaiseCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) &&
                   !string.IsNullOrEmpty(_formUpdateViewModel.ItemName) &&
                   !string.IsNullOrEmpty(_formUpdateViewModel.ItemDescription) &&
                   !string.IsNullOrEmpty(_formUpdateViewModel.SelectedCategory) &&
                   _formUpdateViewModel.ItemQuantity > 0;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            _ = ExecuteAsync(parameter as Window);
        }

        private async Task ExecuteAsync(Window window)
        {
            try
            {

                await _itemRepository.UpdateQueryAsync(new AddItem(
                    _formUpdateViewModel.ItemID,
                    _formUpdateViewModel.ItemName,
                    _formUpdateViewModel.ItemDescription,
                    _formUpdateViewModel.SelectedCategory,
                    _formUpdateViewModel.ItemQuantity)
                );

  
                _refreshStore.RequestRefresh();

                MessageBox.Show("Updated Item Information");

                window?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred! " + ex.Message);
            }
        }
    }
}
