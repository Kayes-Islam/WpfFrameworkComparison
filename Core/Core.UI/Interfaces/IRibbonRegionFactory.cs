using Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Interfaces
{
    public interface IRibbonRegionFactory : IDisposable
    {
        IRibbonRegion CreateRibbonRegion(Ribbon ribbon);
        void DisposeRibbonRegion(IRibbonRegion ribbonRegion);
    }
}
