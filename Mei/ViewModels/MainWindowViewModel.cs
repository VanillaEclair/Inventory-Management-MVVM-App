using Mei.Commands;
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

        //public bool isWindowOpen = false;
        //private bool _isLoaded;

        //Refactor Command Codes
        //public RelayCommand AddCommand => new RelayCommand(execute => AddWindow());
        //public RelayCommand UpdateCommand => new RelayCommand(execute => DeleteItem());
        //public RelayCommand DeleteCommand => new RelayCommand(execute => UpdateWindow());


        public void LoadCategories()
        {
            _categoryStore.CategoryToStore.Clear();

            foreach (var c in _sQLfunctions.GetCategory())
            {
                _categoryStore.CategoryToStore.Add(c);
            }
        }

        //Move to Services
        public void LoadData()
        {
            ItemInfo.Clear();

            foreach (var e in _sQLfunctions.DataQuery())
            {
                ItemInfo.Add(e);

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


        private readonly NavigationStore _navigationStore;
        private readonly VMFactory _factory;
        private readonly SQLfunctions _sQLfunctions;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;


        public MainWindowViewModel(VMFactory factory, NavigationStore navigationStore, SQLfunctions sQLfunctions, EditItemStore editItemStore, RefreshStore refreshStore, CategoryStore categoryStore)
        {

            _factory = factory;
            _navigationStore = navigationStore;
            _sQLfunctions = sQLfunctions;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;



            ItemInfo = new ObservableCollection<MainWindowModel>();
            AddCommand = new MainAddCommand(_factory, _navigationStore, _sQLfunctions, _refreshStore, _categoryStore);
            DeleteCommand = new MainDeleteCommand(_sQLfunctions, _refreshStore);
            UpdateCommand = new MainUpdateCommand(_sQLfunctions, _editItemStore, _refreshStore, _categoryStore);


            _refreshStore.RefreshRequested += () => LoadData();

            _refreshStore.RequestRefresh();


            LoadCategories();


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

