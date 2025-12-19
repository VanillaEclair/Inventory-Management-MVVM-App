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
    public class MainDeleteCommand : CommandBase
    {
        private readonly SQLfunctions _sQLFunctions;
        private readonly RefreshStore _refreshStore;


        public MainDeleteCommand(SQLfunctions sQLFunctions, RefreshStore refreshStore)
        {
            _sQLFunctions = sQLFunctions;
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

        public override void Execute(object? parameter)
        {
            var item = parameter as MainWindowModel;

            try
            {
                _sQLFunctions.DeleteQuery(item.ItemID);
                _refreshStore.RequestRefresh();
                MessageBox.Show("Deleted: " + item.ItemName);
            }
            catch (Exception)
            {
                MessageBox.Show("Error Deleting");
                throw;
            }


            
        }
    }
}
