using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
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
        private ObservableCollection<InfoItemViewModel> _items;

        public CollectionEditorDemoViewModel(
            IInfoItemService infoItemService
        )
        {
            _infoItemService = infoItemService;
            _items = new ObservableCollection<InfoItemViewModel>();
            EditCommand = new DelegateCommand<InfoItemViewModel>(EditInfoItem, IsEditInfoItemEnabled);
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

        public DelegateCommand<InfoItemViewModel> EditCommand { get; private set; }

        public void EditInfoItem(InfoItemViewModel infoItem)
        {
            var item = infoItem;
        }

        public bool IsEditInfoItemEnabled(InfoItemViewModel infoItem)
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
        }
    }
}
