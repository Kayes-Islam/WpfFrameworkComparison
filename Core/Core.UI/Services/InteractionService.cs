using Core.Common.Interfaces;
using Core.UI.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Core.UI.Services
{
    public class InteractionService : IInteractionService
    {
        private IViewResolver _viewResolver;
        private IDialogHandleFactory _dialogHandleFactory;

        public InteractionService(
            IViewResolver viewResolver,
            IDialogHandleFactory dialogHandleFactory
        )
        {
            _viewResolver = viewResolver;
            _dialogHandleFactory = dialogHandleFactory;
        }

        public bool? ShowDialog(object viewModel)
        {
            if (viewModel == null)
            {
                throw new NullReferenceException("Parameter viewModel cannot be null.");
            }

            object view = _viewResolver.GetView(viewModel);
            var window = new Window();
            HwndSource winformWindow = (System.Windows.Interop.HwndSource.FromDependencyObject(Application.Current.Windows[0]) as System.Windows.Interop.HwndSource);
            var interopHelperAdd = new WindowInteropHelper(window) { Owner = winformWindow.Handle };

            var dialogAware = viewModel as IDialogAware;
            if (dialogAware != null)
            {
                dialogAware.DialogHandle = _dialogHandleFactory.CreateDialogHandle(window);
            }

            window.DataContext = viewModel;
            window.Content = view;
            var dialogResult = window.ShowDialog();

            if (dialogAware != null)
            {
                _dialogHandleFactory.DisposeDialogHandle(dialogAware.DialogHandle);
            }

            return dialogResult;
        }
    }
}
