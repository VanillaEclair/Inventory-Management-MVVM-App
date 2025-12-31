using Mei.Interfaces;
using Mei.Models;
using Mei.Services;
using Mei.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    public class MainDeleteCommand : CommandBaseAsync
    {
        //Turn to Async
        private readonly RefreshStore _refreshStore;
        private readonly IItemRepository _itemRepository;


        public MainDeleteCommand(IItemRepository itemRepository, RefreshStore refreshStore)
        {
            _itemRepository = itemRepository;
            _refreshStore = refreshStore;
        }

        public override bool CanExecute(object? parameter)
        {
            var item = parameter as MainWindowModel;

            return item != null &&
                   !string.IsNullOrWhiteSpace(item.ItemName) &&
                   !string.IsNullOrWhiteSpace(item.ItemDescription) &&
                   !string.IsNullOrWhiteSpace(item.ItemCategory) &&
                   item.ItemQty > 0;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            var item = parameter as MainWindowModel;

            try
            {
                await _itemRepository.DeleteQueryAsync(item.ItemID);
                _refreshStore.RequestRefresh();
                MessageBox.Show("Deleted: " + item.ItemName);
            }
            catch (Exception)
            {
                MessageBox.Show("Error Deleting");
                throw;
            }

            _refreshStore.RequestRefresh();



        }
    }
}
