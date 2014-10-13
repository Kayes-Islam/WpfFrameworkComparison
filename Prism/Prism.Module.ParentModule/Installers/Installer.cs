using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Module.ParentModule.Interfaces;
using Prism.Module.ParentModule.ViewModels;
using Prism.Module.ParentModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ParentModule.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IParentModuleViewModel>()
                    .ImplementedBy<ParentModuleViewModel>()
                    .LifestyleSingleton(),
                Component
                    .For<ParentModuleView>()
                    .Named("ParentModuleView")
                    .LifestyleTransient() //Why doesn't navigation work when singleton ?????
            );
        }
    }
}
