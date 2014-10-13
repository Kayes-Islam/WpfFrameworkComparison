using Core.Common.Interfaces;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using Prism.Module.CollectionEditorDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prism.Module.CollectionEditorDemo.ViewModels
{
    public class CollectionEditorDemoViewModel : BindableBase, ICollectionEditorDemoViewModel
    {
        private readonly IInfoItemService _infoItemService;
        private readonly IInteractionService _interactionService;
        private ObservableCollection<InfoItemViewModel> _items;
        private bool _isLoaded;


        public CollectionEditorDemoViewModel(
            IInfoItemService infoItemService,
            IInteractionService interactionService
        )
        {
            _infoItemService = infoItemService;
            _interactionService = interactionService;
            _items = new ObservableCollection<InfoItemViewModel>();
            EditCommand = new DelegateCommand(EditInfoItem, IsEditInfoItemEnabled);
        }

        public ObservableCollection<InfoItemViewModel> Items
        {
            get
            {
                return _items;
            }
        }

        private InfoItemViewModel _selectedItem;
        public InfoItemViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(() => SelectedItem);
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand EditCommand { get; private set; }

        public void EditInfoItem()
        {
            InfoItemViewModel infoItem = SelectedItem;
            var dialogResult = _interactionService.ShowDialog(infoItem);
            var b = dialogResult;
        }

        public bool IsEditInfoItemEnabled()
        {
            return SelectedItem != null;
        }

        public void LoadData()
        {
            var items = _infoItemService.GetInfoItems();
            _items.Clear();
            foreach (var item in items)
            {
                _items.Add(item);
            }

            _isLoaded = true;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (!_isLoaded)
            {
                LoadData();
            }
        }
    }
}
