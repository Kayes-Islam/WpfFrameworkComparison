using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Module.ChildModuleA.ViewModels;
using Prism.Module.ChildModuleA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleA.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ModuleAViewModel>()
                    .LifestyleSingleton()
                //Component
                //    .For<ModuleAView>()
                //    //.Named("ModuleAView")
                //    .LifestyleTransient() //Why doesn't navigation work when singleton ?????
            );
        }
    }
}
