using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using Mei.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    public class MainAddCommand : CommandBase
    {
        private readonly VMFactory _factory;
        private readonly NavigationStore _navigateStore;
        private readonly SQLfunctions _sQLfunctions;
        private readonly RefreshStore _refreshStore;
        private readonly CategoryStore _categoryStore;


        public MainAddCommand(VMFactory factory, NavigationStore navigateStore, SQLfunctions sQLfunctions, RefreshStore refreshStore, CategoryStore categoryStore)
        {
            _factory = factory;
            _navigateStore = navigateStore;
            _sQLfunctions = sQLfunctions;
            _refreshStore = refreshStore;
            _categoryStore = categoryStore;
        }

        public override void Execute(object? parameter)
        {

            var vm = _factory.CreateAddFormViewModel();

            if (Application.Current == null)
            {
                var fallback = new FormAddView()
                {
                    DataContext = vm
                };
                fallback.Show();
                return;
            }

            // Try to find an already-created FormAddView in the application's open windows
            var existing = Application.Current.Windows.OfType<FormAddView>().FirstOrDefault();
            if (existing != null)
            {
                // Restore if minimized
                if (existing.WindowState == WindowState.Minimized)
                    existing.WindowState = WindowState.Normal;


                // Bring it to foreground and focus it
                existing.Activate();
                
                // Toggle Topmost to ensure it comes to front on some OS/window managers
                existing.Topmost = true;
                existing.Topmost = false;

                existing.Focus();
                return;
            }

              

            FormAddView addForm = new FormAddView
            {
                DataContext = new FormAddViewModel(_sQLfunctions, _navigateStore, _refreshStore, _categoryStore)
            };

            addForm.Show();

        }
    }
}
