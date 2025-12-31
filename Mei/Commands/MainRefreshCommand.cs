using Mei.Interfaces;
using Mei.Models;
using Mei.Stores;
using Mei.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    class MainRefreshCommand : CommandBaseAsync
    {
        private readonly RefreshStore _refreshStore;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public MainRefreshCommand(RefreshStore refreshStore, MainWindowViewModel mainWindowViewModel)
        {
            _refreshStore = refreshStore;
            _mainWindowViewModel = mainWindowViewModel;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                _mainWindowViewModel.SearchItem = "";
                _refreshStore.RequestRefresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred! " + ex.Message);
            }
        }
    }
}
