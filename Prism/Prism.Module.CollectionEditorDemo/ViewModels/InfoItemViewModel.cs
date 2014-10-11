using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo.ViewModels
{
    public class InfoItemViewModel : BindableBase
    {
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
    }
}
