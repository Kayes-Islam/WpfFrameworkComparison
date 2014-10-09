using Core.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IUiExtensionService
    {
        void AddNavigationalItem(NavigationItemViewModel navigationItem);
        void RemoveNavigationItem(NavigationItemViewModel navigationItem);
    }
}
