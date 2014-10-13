using Core.Common.Interfaces;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleC.ViewModels
{
    public class ModuleCViewModel : BindableBase, IHaveHeader
    {
        public ModuleCViewModel()
        {
        }

        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(() => Text);
            }
        }

        public string Header
        {
            get { return "Module C"; }
        }
    }
}
