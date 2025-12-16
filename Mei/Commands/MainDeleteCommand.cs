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

        public MainDeleteCommand(SQLfunctions sQLFunctions)
        {
            _sQLFunctions = sQLFunctions;
        }

        public override void Execute(object? parameter)
        {
            var item = parameter as MainWindowModel;

            try
            {
                _sQLFunctions.DeleteQuery(item.ItemID);
                MessageBox.Show("Delete: " + item.ItemID);
            }
            catch (Exception)
            {
                MessageBox.Show("Error Deleting");
                throw;
            }


            
        }
    }
}
