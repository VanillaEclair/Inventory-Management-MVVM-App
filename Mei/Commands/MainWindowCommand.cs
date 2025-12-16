using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    public class MainWindowCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            MessageBox.Show("Yamete Kudasai!");
        }
    }
}
