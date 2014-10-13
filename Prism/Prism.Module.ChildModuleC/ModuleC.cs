using Castle.Windsor;
using Core.Common;
using Core.Common.Constants;
using Core.Common.Interfaces;
using Core.Common.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Module.ChildModuleC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Prism.Module.ChildModuleC
{
    public class ModuleC : IModule
    {
        private IWindsorContainer _container;
        private IRegionManager _regionManager;
        private IUiExtensionService _uiExtensionService;

        private NavigationItemViewModel _navigationItem;

        public ModuleC(
            IWindsorContainer container,
            IRegionManager regionManager,
            IUiExtensionService uiExtensionService
        )
        {
            _container = container;
            _regionManager = regionManager;
            _uiExtensionService = uiExtensionService;
            var openViewCommand = new DelegateCommand(OpenView);
            _navigationItem = new NavigationItemViewModel("Open Module C View", openViewCommand);
        }

        public void Initialize()
        {
            _container.Install(new Installers.Installer());
            _regionManager.RegisterViewWithRegion(KnownRegionNames.ChildRegion,typeof(ModuleCView));
            _uiExtensionService.AddNavigationalItem(_navigationItem);

            var openWinFormsViewCommand = new DelegateCommand(OpenWinformsView);
            var navigationItem2 = new NavigationItemViewModel("Open Module C Winforms View", openWinFormsViewCommand);
            _uiExtensionService.AddNavigationalItem(navigationItem2);
        }

        private void OpenView()
        {
            Uri parentViewUri = new Uri(KnownViewNames.ParentModuleView, UriKind.Relative);
            _regionManager.RequestNavigate(KnownRegionNames.ContentRegion, parentViewUri);

            Uri uri = new Uri("ModuleCView", UriKind.Relative);
            _regionManager.RequestNavigate(KnownRegionNames.ChildRegion, uri);
        }

        private void OpenWinformsView()
        {
            var control = new CustomUserControl();
            var frm = new Form();
            frm.Controls.Add(control);
            frm.Width = 600;
            frm.Height = 400;
            frm.BackColor = System.Drawing.Color.White;
            frm.Show();
        }
    }
}
