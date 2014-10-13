using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Module.Demo.Interfaces;
using Prism.Module.Demo.ViewModels;
using Prism.Module.Demo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.Demo.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IDemoViewModel>()
                    .ImplementedBy<Demo.ViewModels.DemoViewModel>()
                    .LifestyleSingleton(),
                Component
                    .For<DemoView>()
                    .Named("DemoView")
                    .LifestyleTransient() //Why doesn't navigation work when singleton ?????
            );
        }        
    }
}
