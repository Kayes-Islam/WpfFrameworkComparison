﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Microsoft.Practices.Prism.Modularity;

using PrismContrib.WindsorExtensions;
using Microsoft.Practices.Prism.Mvvm;
using Prism.Shell.Views;

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
                    .FirstOrDefault(t=>t.Name == interfaceName);

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
