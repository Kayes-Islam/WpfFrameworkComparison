using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Module.ChildModuleB.ViewModels;
using Prism.Module.ChildModuleB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.ChildModuleB.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ModuleBViewModel>()
                    .LifestyleSingleton()
                //Component
                //    .For<ModuleBView>()
                //    //.Named("ModuleBView")
                //    .LifestyleTransient() //Why doesn't navigation work when singleton ?????
            );
        }
    }
}
