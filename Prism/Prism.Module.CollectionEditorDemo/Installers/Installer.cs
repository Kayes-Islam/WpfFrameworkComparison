using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Prism.Module.CollectionEditorDemo.Interfaces;
using Prism.Module.CollectionEditorDemo.Services;
using Prism.Module.CollectionEditorDemo.ViewModels;
using Prism.Module.CollectionEditorDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo.Installers
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IInfoItemService>()
                    .ImplementedBy<MockInfoItemService>()
                    .LifestyleTransient(),

               Component
                    .For<ICollectionEditorDemoViewModel>()
                    .ImplementedBy<CollectionEditorDemoViewModel>()
                    .LifestyleSingleton(),

                Component
                    .For<CollectionEditorDemoView>()
                    .Named("CollectionEditorDemo")
                    .LifestyleTransient() //Why doesn't navigation work when singleton ?????
            );
        }
    }
}
