using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interactions
{
    public interface IDialogAware
    {
        /// <summary>
        /// The dialog handle is passed in by the Interaction Service 
        /// when the view model is open in a dialog.
        /// </summary>
        IDialogHandle DialogHandle { get; set; }
    }
}
