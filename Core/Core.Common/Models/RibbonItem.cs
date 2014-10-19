using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.Common.Models
{
    public class RibbonItem
    {
        public RibbonItem(object ribbonControl)
        {
            RibbonControl = ribbonControl;
        }

        public object RibbonControl { get; private set; }
    }
}
