using Castle.Windsor;
using Core.Common;
using Core.Common.Interfaces;
using Core.Common.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Module.CollectionEditorDemo.Installers;
using Prism.Module.CollectionEditorDemo.Interfaces;
using Prism.Module.CollectionEditorDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo
{
    public class CollectionEditorDemoModule : IModule
    {
        private IWindsorContainer _container;
        private IRegionManager _regionManager;
        private NavigationItemViewModel _navigationItem;
        private IUiExtensionService _uiExtensionService;
        private CollectionEditorDemoView _view;

        public CollectionEditorDemoModule(
            IWindsorContainer container,
            IRegionManager regionManager,
            IUiExtensionService uiExtensionService
        )
        {
            _container = container;
            _regionManager = regionManager;
            _uiExtensionService = uiExtensionService;
            _navigationItem = new NavigationItemViewModel("Open Collection Editor Module", new DelegateCommand(OpenView));
        }

        public void Initialize()
        {
            _container.Install(new Installer());
            _uiExtensionService.AddNavigationalItem(_navigationItem);
        }

        public void OpenView()
        {
            if (_view == null)
            {
                _view = new CollectionEditorDemoView();
                _regionManager.AddToRegion(KnownRegionNames.ContentRegion, _view);
                var viewModel = _container.Resolve<ICollectionEditorDemoViewModel>();
                viewModel.LoadData();
            }

            _regionManager.Regions[KnownRegionNames.ContentRegion].Activate(_view);
        }
    }
}
