using Microsoft.Practices.Prism.Mvvm;
using Prism.Module.Demo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.Demo.ViewModels
{
    public class DemoViewModel : BindableBase, IDemoViewModel
    {

        public DemoViewModel()
        {
            SomePropertyValue = "This is a sample property value.";
        }
        
        public string TabHeader
        {
            get
            {
                return "Demo View";
            }
        }

        private string _somePropertyValue;
        public string SomePropertyValue
        {
            get
            {
                return _somePropertyValue;
            }
            set
            {
                _somePropertyValue = value;
                OnPropertyChanged(() => SomePropertyValue);
            }
        }
    }
}
