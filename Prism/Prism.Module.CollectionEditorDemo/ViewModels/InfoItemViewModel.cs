using Core.Common.Interfaces;
using Core.Common.Extensions;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo.ViewModels
{
    public class InfoItemViewModel : BindableBase, IDialogAware
    {
        public InfoItemViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(() => Description);
            }
        }

        private double _weight;
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged(() => Weight);
            }
        }

        private ObservableCollection<InfoItemPropertyViewModel> _properties;
        public ObservableCollection<InfoItemPropertyViewModel> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
                OnPropertyChanged(() => Properties);
            }
        }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public void Save()
        {
            DialogHandle.TryClose(true);
        }

        public void Cancel()
        {
            DialogHandle.TryClose(false);
        }
        
        public IDialogHandle DialogHandle { get; set; }
    }
}
