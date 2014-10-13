using Core.Common.Interfaces;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleB.ViewModels
{
    public class ModuleBViewModel : BindableBase, IHaveTabHeader
    {
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


        public string TabHeader
        {
            get { return "Module B"; }
        }
    }
}
