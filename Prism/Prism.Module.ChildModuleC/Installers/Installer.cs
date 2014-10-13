using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Module.ChildModuleC.ViewModels;
using Prism.Module.ChildModuleC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleC.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ModuleCViewModel>()
                    .LifestyleSingleton(),

                Component
                    .For<CustomUserControl>()
                    .LifestyleTransient()
                //Component
                //    .For<ModuleCView>()
                //    .Named("ModuleCView")
                //    .LifestyleTransient() //Why doesn't navigation work when singleton ?????
            );
        }
    }
}
