using Mei.Models;
using Mei.Services;
using Mei.Stores;
using Mei.ViewModels;
using Mei.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Commands
{
    public class MainUpdateCommand : CommandBase
    {

        private readonly SQLfunctions _sQLFunctions;
        private readonly EditItemStore _editItemStore;
        private readonly RefreshStore _refreshStore;


        public MainUpdateCommand(SQLfunctions sQLFunctions, EditItemStore editItemStore, RefreshStore refreshStore)
        {
            _sQLFunctions = sQLFunctions;
            _editItemStore = editItemStore;
            _refreshStore = refreshStore;

        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.SelectedItem))
            {
                OnCanExexutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            var item = parameter as MainWindowModel;

            return item != null &&
                   !string.IsNullOrWhiteSpace(item.ItemName) &&
                   !string.IsNullOrWhiteSpace(item.ItemDescription) &&
                   !string.IsNullOrWhiteSpace(item.ItemCategory) &&
                   item.ItemQty > 0;
        }

        public override void Execute(object? parameter)
        {
            var item = parameter as MainWindowModel;
            MessageBox.Show(item.ItemName);

            _editItemStore.ItemToEdit = item;


            if (Application.Current == null)
            {
                var fallback = new FormUpdateView();
                fallback.Show();
                return;
            }

            // Try to find an already-created FormAddView in the application's open windows
            var existing = Application.Current.Windows.OfType<FormUpdateView>().FirstOrDefault();
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

            FormUpdateView updateForm = new FormUpdateView
            {
                DataContext = new FormUpdateViewModel(_editItemStore, _sQLFunctions, _refreshStore)
            };

            updateForm.Show();




        }

        //public override void Execute(object? parameter)
        //{


        //if (Application.Current == null)
        //{
        //    var fallback = new FormUpdateView();
        //    fallback.Show();
        //    return;
        //}

        //// Try to find an already-created FormAddView in the application's open windows
        //var existing = Application.Current.Windows.OfType<FormUpdateView>().FirstOrDefault();
        //if (existing != null)
        //{
        //    // Restore if minimized
        //    if (existing.WindowState == WindowState.Minimized)
        //        existing.WindowState = WindowState.Normal;


        //    // Bring it to foreground and focus it
        //    existing.Activate();

        //    // Toggle Topmost to ensure it comes to front on some OS/window managers
        //    existing.Topmost = true;
        //    existing.Topmost = false;

        //    existing.Focus();
        //    return;
        //}



        //var item = parameter as MainWindowModel;


        //FormUpdateView updateForm = new FormUpdateView
        //{
        //    DataContext = new FormUpdateViewModel()
        //};

        //updateForm.Show();
        //}
    }
}
