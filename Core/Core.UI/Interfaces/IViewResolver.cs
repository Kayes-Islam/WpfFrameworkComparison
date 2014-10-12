using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Interfaces
{
    public interface IViewResolver
    {
        /// <summary>
        /// returns a view from a view model
        /// </summary>
        object GetView(object viewModel);

        /// <summary>
        /// Returns a view from a view model type
        /// </summary>
        object GetView<TViewModel>();

        /// <summary>
        /// Returns a 
        /// </summary>
        Type GetViewType(Type vmType);

        /// <summary>
        /// returns a view 
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        Type GetViewType<TViewModel>();
    }
}
