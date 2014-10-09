using Castle.Windsor;
using Core.Common;
using Core.Common.Interfaces;
using Core.Common.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Module.Demo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prism.Module.Demo
{
    public class DemoModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IWindsorContainer _container;
        private readonly IUiExtensionService _uiExtensionService;

        private NavigationItemViewModel _navigationItem;

        public DemoModule(
            IRegionManager regionManager, 
            IWindsorContainer container,
            IUiExtensionService uiExtensionService
        ) 
        { 
            _regionManager = regionManager;
            _container = container;
            _uiExtensionService = uiExtensionService;
            var openViewCommand = new DelegateCommand(OpenView);
            _navigationItem = new NavigationItemViewModel("Open Demo Module", openViewCommand);

        }

        public void Initialize()
        {
            _container.Install(new Installers.Installer());
            _uiExtensionService.AddNavigationalItem(_navigationItem);
        }

        private void OpenView()
        {
            var demoView = new Demo.Views.DemoView();
            _regionManager.AddToRegion(KnownRegionNames.InfoPanel, demoView);
            _regionManager.Regions[KnownRegionNames.InfoPanel].Activate(demoView);
        }


    }
}
