using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Microsoft.Practices.Prism.Modularity;

using PrismContrib.WindsorExtensions;
using Microsoft.Practices.Prism.Mvvm;
using Prism.Shell.Views;
using System.Xml;
using System.Windows.Markup;
using Castle.MicroKernel.Registration;
using Castle.Facilities.TypedFactory;

namespace Prism.Shell
{
    public class Bootstrapper : WindsorBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<ShellView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            System.Windows.Forms.Application.EnableVisualStyles();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        // Creating module isn't working, so temporarily adding by code
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            XmlReader xmlReader = XmlReader.Create("ModulesCatalog.xaml");
            ModuleCatalog moduleCatalog = (ModuleCatalog)XamlReader.Load(xmlReader);
            return moduleCatalog;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.AddFacility<TypedFactoryFacility>();

            this.Container.Install(new Prism.Shell.Installers.Installer());
            this.Container.Install(new Core.UI.Installers.Installer());

            foreach (var mod in ModuleCatalog.Modules)
            {
                var moduleType = Type.GetType(mod.ModuleType);
                var assembly = moduleType.Assembly;
                Container.Register(
                    Component
                        .For(moduleType)
                        .LifestyleTransient(),
                    Classes
                        .FromAssembly(assembly)
                        .BasedOn<IView>()
                        .WithServiceSelf()
                        .LifestyleTransient()
                );
            }
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(FindViewModelTypeFromViewType);
            ViewModelLocationProvider.SetDefaultViewModelFactory(ResolveViewModelFromType);
        }

        private Type FindViewModelTypeFromViewType(Type viewType)
        {
            string viewName = viewType.Name;
            string nameWithoutView = viewName;
            if (viewName.EndsWith("View"))
            {
                nameWithoutView = viewName.Substring(0, viewName.LastIndexOf("View"));
            }

            string viewModelName = nameWithoutView + "ViewModel";
            string interfaceName = "I" + viewModelName;

            Type vmType = viewType
                    .Assembly
                    .GetExportedTypes()
                    .FirstOrDefault(t => t.Name == interfaceName);

            if (vmType == null)
            {
                vmType = viewType
                    .Assembly
                    .GetExportedTypes()
                    .FirstOrDefault(t => t.Name == viewModelName);
            }

            return vmType;
        }

        private object ResolveViewModelFromType(Type viewModelType)
        {
            return Container.Resolve(viewModelType);
        }
    }
}
