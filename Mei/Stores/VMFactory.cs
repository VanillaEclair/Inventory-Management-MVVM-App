using Mei.Models;
using Mei.Services;
using Mei.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mei.Stores
{
    public class VMFactory
    {
        //private readonly IItemRepository _repo;
        private readonly SQLfunctions _sQLfunctions;
        private readonly NavigationStore _navigationStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;

        public VMFactory(SQLfunctions sQLfunctions, NavigationStore navigationStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _sQLfunctions = sQLfunctions;
            _navigationStore = navigationStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
        }

        public FormAddViewModel CreateAddFormViewModel()
        {

            return new FormAddViewModel(_sQLfunctions, _navigationStore, _refreshStore, _categoryStore);
        }
    }
}
