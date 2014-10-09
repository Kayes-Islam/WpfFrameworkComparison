using System;
using System.Collections.Generic;
using System.Linq;

using Core.Common.Interfaces;
using Core.Common.ViewModels;
using Core.UI.Interfaces;

namespace Core.UI.Services
{
    public class UiExtensionService : IUiExtensionService
    {
        private INavigationViewModel _navigationViewModel;

        public UiExtensionService(INavigationViewModel navigationViewModel)
        {
            _navigationViewModel = navigationViewModel;
        }

        public void AddNavigationalItem(NavigationItemViewModel navigationItem)
        {
            _navigationViewModel.NavigationItems.Add(navigationItem);
        }

        public void RemoveNavigationItem(NavigationItemViewModel navigationItem)
        {
            _navigationViewModel.NavigationItems.Remove(navigationItem);
        }
    }
}
