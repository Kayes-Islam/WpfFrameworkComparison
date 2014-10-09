using Core.UI.Interfaces;
using Prism.Shell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Shell.ViewModels
{
    public class ShellViewModel : IShellViewModel
    {
        private readonly INavigationViewModel _navigationViewModel;

        public ShellViewModel(INavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }

        public INavigationViewModel NavigationViewModel
        {
            get
            {
                return _navigationViewModel;
            }
        }
    }
}
