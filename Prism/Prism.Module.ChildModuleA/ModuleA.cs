﻿using Castle.Windsor;
using Core.Common;
using Core.Common.Constants;
using Core.Common.Interfaces;
using Core.Common.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Module.ChildModuleA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleA
{
    public class ModuleA : IModule
    {
        private IWindsorContainer _container;
        private IRegionManager _regionManager;
        private IUiExtensionService _uiExtensionService;

        private NavigationItemViewModel _navigationItem;

        public ModuleA(
            IWindsorContainer container,
            IRegionManager regionManager,
            IUiExtensionService uiExtensionService
        )
        {
            _container = container;
            _regionManager = regionManager;
            _uiExtensionService = uiExtensionService;
            var openViewCommand = new DelegateCommand(OpenView);
            _navigationItem = new NavigationItemViewModel("Open Module A View", openViewCommand);
        }

        public void Initialize()
        {
            _container.Install(new Installers.Installer());
            _regionManager.RegisterViewWithRegion(KnownRegionNames.ChildRegion,typeof(ModuleAView));
            _uiExtensionService.AddNavigationalItem(_navigationItem);
        }

        private void OpenView()
        {
            Uri parentViewUri = new Uri(KnownViewNames.ParentModuleView, UriKind.Relative);
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, parentViewUri);

            Uri uri = new Uri("ModuleAView", UriKind.Relative);
            _regionManager.RequestNavigate(KnownRegionNames.ChildRegion, uri);
        }
    }
}
