using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Core.Common.Interactions;
using Core.Common.Interfaces;
using Core.UI.Interactions;
using Core.UI.Interfaces;
using Core.UI.PrismExtensions.Regions;
using Core.UI.Services;
using Core.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Installers
{
    public class Installer : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IMimicViewModel>()
                    .ImplementedBy<MimicViewModel>()
                    .LifestyleTransient(),

                Component
                    .For<IUiExtensionService>()
                    .ImplementedBy<UiExtensionService>()
                    .LifestyleSingleton(),

                Component
                    .For<INavigationViewModel>()
                    .ImplementedBy<NavigationViewModel>()
                    .LifestyleSingleton(),

                Component
                    .For<IDialogHandle>()
                    .ImplementedBy<DialogHandle>()
                    .LifestyleTransient(),

                Component
                    .For<IDialogHandleFactory>()
                    .AsFactory()
                    .LifestyleTransient(),

                Component
                    .For<IViewResolver>()
                    .ImplementedBy<ViewResolver>()
                    .LifestyleTransient(),
                
                Component
                    .For<IInteractionService>()
                    .ImplementedBy<InteractionService>()
                    .LifestyleTransient(),

               Component
                    .For<IRibbonRegionAdapter>()
                    .ImplementedBy<RibbonRegionAdapter>()
                    .LifestyleTransient()
            );  
        }
    }
}
