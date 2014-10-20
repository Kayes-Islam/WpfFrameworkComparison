using Castle.Windsor;
using Core.Common;
using Core.Common.Constants;
using Core.Common.Interfaces;
using Core.Common.Models;
using Core.Common.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Prism.Module.ParentModule
{
    public class ParentModule : IModule
    {
private readonly IRegionManager _regionManager;
        private readonly IWindsorContainer _container;
        private readonly IUiExtensionService _uiExtensionService;

        private NavigationItemViewModel _navigationItem;

        public ParentModule(
            IRegionManager regionManager, 
            IWindsorContainer container,
            IUiExtensionService uiExtensionService
        ) 
        { 
            _regionManager = regionManager;
            _container = container;
            _uiExtensionService = uiExtensionService;
            var openViewCommand = new DelegateCommand(OpenView);
            _navigationItem = new NavigationItemViewModel("Open Parent Module", openViewCommand);
        }

        public void Initialize()
        {
            _container.Install(new Installers.Installer());
            _uiExtensionService.AddNavigationalItem(_navigationItem);

            var button = new Fluent.Button();
            button.Header = "Parent Module";
            var ribbonItem = new RibbonItem(button, "Tab1", "Group1");
            _regionManager.RegisterViewWithRegion(KnownRegionNames.RibbonRegion, () => ribbonItem);
        }

        private void OpenView()
        {
            Uri uri = new Uri(KnownViewNames.ParentModuleView, UriKind.Relative);
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, uri);
        }        
    }
}
