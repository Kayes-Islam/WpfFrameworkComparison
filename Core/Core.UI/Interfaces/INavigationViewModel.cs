using Core.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Interfaces
{
    public interface INavigationViewModel
    {
        ObservableCollection<NavigationItemViewModel> NavigationItems { get; }
    }
}
