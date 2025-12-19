using Mei.Models;
using Mei.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mei.Stores
{
    public class CategoryStore
    {
        public ObservableCollection<string> CategoryToStore { get; }
            = new ObservableCollection<string>();

    }
}
