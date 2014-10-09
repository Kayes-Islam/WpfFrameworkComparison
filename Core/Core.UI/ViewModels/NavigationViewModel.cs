using Core.Common.ViewModels;
using Core.UI.Interfaces;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationViewModel
    {
        public NavigationViewModel()
        {
            _navigationItems = new ObservableCollection<NavigationItemViewModel>();
        }

        private ObservableCollection<NavigationItemViewModel> _navigationItems;
        public ObservableCollection<NavigationItemViewModel> NavigationItems
        {
            get
            {
                return _navigationItems;
            }
        }
    }
}
