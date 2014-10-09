using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Microsoft.Practices.Prism.Modularity;

using PrismContrib.WindsorExtensions;

namespace Prism.Shell
{
    public class Bootstrapper : WindsorBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

            var demoModuleType = typeof(Prism.Module.Demo.DemoModule);
            var demoModuleInfo = new ModuleInfo()
            {
                ModuleName = demoModuleType.Name,
                ModuleType = demoModuleType.AssemblyQualifiedName
            };

            moduleCatalog.AddModule(demoModuleInfo);
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
        //        new Uri(
        //            "/Prism.Shell;component/ModulesCatalog.xaml",
        //            UriKind.Relative
        //        )
        //    );
        //}

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            this.Container.Install(new Prism.Shell.Installers.Installer());
            this.Container.Install(new Core.UI.Installers.Installer());
        }
    }
}
