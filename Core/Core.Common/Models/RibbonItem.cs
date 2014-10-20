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

        public RibbonItem(object ribbonControl, string pageHeader, string groupHeader)
        {
            RibbonControl = ribbonControl;
            TabHeader = pageHeader;
            GroupHeader = groupHeader;
        }

        public string TabHeader { get; private set; }

        public string GroupHeader { get; private set; }

        public object RibbonControl { get; private set; }
    }
}
