using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.UI.Interfaces
{
    public interface IDialogHandleFactory : IDisposable
    {
        IDialogHandle CreateDialogHandle(Window dialog);
        void DisposeDialogHandle(IDialogHandle dialogHandle);
    }
}
