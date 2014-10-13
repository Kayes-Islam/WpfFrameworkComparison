using Core.Common.Interactions;
using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.UI.Services
{
    public class DialogHandle : IDialogHandle
    {
        private Window _dialog;
        public DialogHandle(Window dialog)
        {
            _dialog = dialog;
        }

        public void CloseDialog(bool? dialogResult)
        {
            if (_dialog != null)
            {
                _dialog.DialogResult = dialogResult;
            }
        }
    }
}
