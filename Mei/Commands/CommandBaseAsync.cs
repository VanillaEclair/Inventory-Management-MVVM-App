using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mei.Commands
{
    public abstract class CommandBaseAsync : ICommand
    {
        private bool _isExecuting;

        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)

            => !_isExecuting;
        //return true;


        public async void Execute(object? parameter)
        {
            if (!CanExecute(parameter))
                return;

            try
            {
                _isExecuting = true;
                RaiseCanExecuteChanged();
                await ExecuteAsync(parameter);
            }
            finally
            {

                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        protected abstract Task ExecuteAsync(object? parameter);

        protected void RaiseCanExecuteChanged()
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }
}
