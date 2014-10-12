using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Extensions
{
    public static class InteractionExtensions
    {
        public static void TryClose(this IDialogHandle dialogHandle, bool? dialogResult)
        {
            if (dialogHandle != null)
            {
                dialogHandle.CloseDialog(dialogResult);
            }
        }
    }
}
