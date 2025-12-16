using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    internal class FormUpdateCancelCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }
    }
}
