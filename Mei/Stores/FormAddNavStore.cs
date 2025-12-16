using Mei.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mei.Stores
{
    public class FormAddNavStore
    {


        private ViewModelBase? _currentViewModel;
        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;


            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action? CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
