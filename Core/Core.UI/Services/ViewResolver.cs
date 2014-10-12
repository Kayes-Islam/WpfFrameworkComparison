using Castle.Windsor;
using Core.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Services
{
    public class ViewResolver : IViewResolver
    {
        private IWindsorContainer _container;

        public ViewResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object GetView(object viewModel)
        {
            if (viewModel == null)
            {
                throw new NullReferenceException("Argument viewModel cannot be null.");
            }

            var vmType = viewModel.GetType();
            var viewType = GetViewType(vmType);
            return GetViewFromType(viewType);
        }

        public object GetView<TViewModel>()
        {
            var vmType = typeof(TViewModel);
            var viewType = GetViewType(vmType);
            return GetViewFromType(viewType);
        }

        public Type GetViewType(Type vmType)
        {
            string vmName = vmType.Name;
            string viewName;

            if (vmName.EndsWith("ViewModel"))
            {
                viewName = vmName.Substring(0, vmName.LastIndexOf("Model"));
            }
            else
            {
                viewName = vmName + "View";
            }

            var viewInterfaceName = "I" + viewName;

            var viewType = vmType
                .Assembly
                .GetExportedTypes()
                .FirstOrDefault(t => t.Name == viewInterfaceName);

            if (viewType == null)
            {
                viewType = vmType
                    .Assembly
                    .GetExportedTypes()
                    .FirstOrDefault(t => t.Name == viewName);
            }

            return viewType;
        }


        public Type GetViewType<TViewModel>()
        {
            var vmType = typeof(TViewModel);
            return GetViewType(vmType);
        }

        private object GetViewFromType(Type viewType)
        {
            return _container.Resolve(viewType);
        }
    }
}
