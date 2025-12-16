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

        public VMFactory(SQLfunctions sQLfunctions, NavigationStore navigationStore, RefreshStore refreshStore)
        {
            _sQLfunctions = sQLfunctions;
            _navigationStore = navigationStore;
            _refreshStore = refreshStore;
        }

        public FormAddViewModel CreateAddFormViewModel()
        {
            // Inject dependencies here if needed

            return new FormAddViewModel(_sQLfunctions, _navigationStore, _refreshStore);
        }
    }
}
