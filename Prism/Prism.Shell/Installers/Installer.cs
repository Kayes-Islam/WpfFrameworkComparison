using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Shell.Interfaces;
using Prism.Shell.ViewModels;
using Prism.Shell.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Shell.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<ShellView>()
                    .LifestyleSingleton(),

                Component
                    .For<Module.Demo.DemoModule>()
                    .LifestyleTransient(),

                Component
                    .For<IShellViewModel>()
                    .ImplementedBy<ShellViewModel>()
                    .LifestyleSingleton()
            );            
        }
    }
}
