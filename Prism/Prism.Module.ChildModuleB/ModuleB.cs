using Castle.Windsor;
using Core.Common;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Prism.Module.ChildModuleB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleB
{
    public class ModuleB : IModule
    {
        private IRegionManager _regionManager;
        private IWindsorContainer _container;

        public ModuleB(IWindsorContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.Install(new Installers.Installer());
            _regionManager.RegisterViewWithRegion(KnownRegionNames.ChildRegion, typeof(ModuleBView));
        }
    }
}
