//using Mei.MVVM;
//using Mei.Stores;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mei.ViewModels
//{
//   public class MainViewModel : ViewModelBase
//    {
        //Check Seans Tutorial
        //private readonly NavigationStore _navigationStore;
        //private readonly FormAddNavStore _FormAddNavStore;

        //public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        //public ViewModelBase CurrentFormViewModel => _FormAddNavStore.CurrentViewModel;

        //public MainViewModel(NavigationStore navigationStore, FormAddNavStore formAddNavStore)
        //{
        //    _navigationStore = navigationStore;
        //    _FormAddNavStore = formAddNavStore;

        //    _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        //    _FormAddNavStore.CurrentViewModelChanged += OnCurrentFormViewModelChanged;

        //}

        //private void OnCurrentFormViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(CurrentFormViewModel));
        //}

        //private void OnCurrentViewModelChanged()
        //{
        //    OnPropertyChanged(nameof(CurrentViewModel));
        //}

        //internal void RefreshData()
        //{
        //    throw new NotImplementedException();
        //}
//    }
//}
