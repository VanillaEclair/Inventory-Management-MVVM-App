using Mei.Interfaces;
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
        private readonly IItemRepository _itemRepository;

        private readonly NavigationStore _navigationStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;

        public VMFactory(IItemRepository itemRepository, NavigationStore navigationStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {

            _navigationStore = navigationStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
            _itemRepository = itemRepository;
        }

        public FormAddViewModel CreateAddFormViewModel()
        {

            return new FormAddViewModel(_itemRepository, _navigationStore, _refreshStore, _categoryStore);
        }
    }
}
