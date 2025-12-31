using Mei.Commands;
using Mei.Interfaces;
using Mei.Models;
using Mei.MVVM;
using Mei.Services;
using Mei.Stores;
using Mei.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace Mei.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        public ObservableCollection<MainWindowModel> ItemInfo { get;}
        private readonly NavigationStore _navigationStore;
        private readonly VMFactory _factory;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;
        private readonly IItemRepository _itemRepository;


        //Refactor Command Codes
        //public RelayCommand AddCommand => new RelayCommand(execute => AddWindow());
        //public RelayCommand UpdateCommand => new RelayCommand(execute => DeleteItem());
        //public RelayCommand DeleteCommand => new RelayCommand(execute => UpdateWindow());


        public async Task LoadCategoriesAsync()
        {
            _categoryStore.CategoryToStore.Clear();
            var data = await _itemRepository.GetCategoryAsync();

            foreach (var c in data)
            {
                _categoryStore.CategoryToStore.Add(c);
            }
        }

        public async Task LoadAsync()
        {
            ItemInfo.Clear();

            IEnumerable<MainWindowModel> data =
                string.IsNullOrWhiteSpace(SearchItem)
                    ? await _itemRepository.AsyncDataQuery()
                    : await _itemRepository.SearchQuery(SearchItem);

            foreach (var item in data)
                ItemInfo.Add(item);
        }



        //public async Task LoadDataAsync()
        //{
        //    ItemInfo.Clear();

        //    var data = await _itemRepository.AsyncDataQuery();

        //    foreach (var e in data)
        //    {
        //        ItemInfo.Add(e);

        //    }
        //}

        //public async Task LoadSearchData()
        //{
        //    ItemInfo.Clear();

        //    var data = await _itemRepository.AsyncDataQuery();

        //    foreach (var e in data)
        //    {
        //        ItemInfo.Add(e);

        //    }
        //}

        private string searchItem;

        public string SearchItem
        {
            get { return searchItem; }
            set 
            {
                searchItem = value;
                OnPropertyChanged();
            }
        }


        private MainWindowModel selectedItem;

        public MainWindowModel SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value;
                OnPropertyChanged();

            }
        }


        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }





        public MainWindowViewModel(VMFactory factory, NavigationStore navigationStore, IItemRepository itemRepository, EditItemStore editItemStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {

            _factory = factory;
            _navigationStore = navigationStore;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
            _itemRepository = itemRepository;



            ItemInfo = new ObservableCollection<MainWindowModel>();
            AddCommand = new MainAddCommand(_factory, _navigationStore, _itemRepository, _refreshStore, _categoryStore);
            DeleteCommand = new MainDeleteCommand(_itemRepository, _refreshStore);
            UpdateCommand = new MainUpdateCommand(_itemRepository, _editItemStore, _refreshStore, _categoryStore);
            SearchCommand = new MainSearchCommand(this, _itemRepository);
            RefreshCommand = new MainRefreshCommand(_refreshStore, this);


   
            _refreshStore.RefreshRequested += () => LoadAsync();

            _refreshStore.RequestRefresh();


            LoadCategoriesAsync();
 



            //Questionable to MVVM architecture
            //OutputData();

        }




        //private void OpenAddWindow(object? parameter)
        //{
        //    var addWindow = new AddWindow
        //    {
        //        DataContext = new AddViewModel()
        //    };
        //    addWindow.ShowDialog();
        //}
    }



}

