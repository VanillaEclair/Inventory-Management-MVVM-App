using Mei.Interfaces;
using Mei.ViewModels;
using System.ComponentModel;


namespace Mei.Commands
{
    public class MainSearchCommand : CommandBaseAsync
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly IItemRepository _itemRepository;

        public MainSearchCommand(MainWindowViewModel mainWindowViewModel, IItemRepository itemRepository)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _itemRepository = itemRepository;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_mainWindowViewModel.SearchItem))
            {
                RaiseCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return base.CanExecute(parameter) &&
                   !string.IsNullOrEmpty(_mainWindowViewModel.SearchItem);
        }

        protected override async Task ExecuteAsync(object? parameter)
        {

            await _mainWindowViewModel.LoadAsync();
        }
    }
}
