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
        public ObservableCollection<MainWindowModel> ItemInfo { get; set; }
        public bool isWindowOpen = false;

        //Refactor Command Codes
        //public RelayCommand AddCommand => new RelayCommand(execute => AddWindow());
        //public RelayCommand UpdateCommand => new RelayCommand(execute => DeleteItem());
        //public RelayCommand DeleteCommand => new RelayCommand(execute => UpdateWindow());


        //Move to Services
        public void OutputData()
        {
            ItemInfo.Clear();

            var items = new List<MainWindowModel>();
            SQLfunctions sQLfunctions = new SQLfunctions();
            //remove sql query here, move to services
            string query = "SELECT * FROM item";
            items = sQLfunctions.DataQuery(query);

            foreach (var e in items)
            {
                //MessageBox.Show(e.ItemDescription);

                ItemInfo.Add(new MainWindowModel
                {
                    ItemID = e.ItemID,
                    ItemName = e.ItemName,
                    ItemDescription = e.ItemDescription,
                    ItemCategory = e.ItemCategory,
                    ItemImg = e.ItemImg,
                    ItemQty = e.ItemQty
                });
            }
            OnPropertyChanged();

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




        //public void AddWindow()
        //{
        //    //find way to intantiate only one image
        //    FormUpdateView form = new FormUpdateView();
        //        isWindowOpen = true;
        //        form.Show();
        //}

        //public void DeleteItem()
        //{

        //}

        //public void UpdateWindow()
        //{

        //}

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }


        private readonly NavigationStore _navigationStore;
        private readonly VMFactory _factory;
        private readonly SQLfunctions _sQLfunctions;
        //private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;


        public MainWindowViewModel(VMFactory factory, NavigationStore navigationStore, SQLfunctions sQLfunctions, EditItemStore editItemStore, RefreshStore refreshStore)
        {

            _factory = factory;
            _navigationStore = navigationStore;
            _sQLfunctions = sQLfunctions;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;



            ItemInfo = new ObservableCollection<MainWindowModel>();
            AddCommand = new MainAddCommand(_factory, _navigationStore, _sQLfunctions, _refreshStore);
            DeleteCommand = new MainDeleteCommand(_sQLfunctions);
            UpdateCommand = new MainUpdateCommand(_sQLfunctions, _editItemStore, _refreshStore);


            _refreshStore.RefreshRequested += () => OutputData();

            //Questionable to MVVM architecture
            OutputData();

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

