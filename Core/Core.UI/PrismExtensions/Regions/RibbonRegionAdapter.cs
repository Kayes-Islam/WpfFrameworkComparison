using Core.UI.Interfaces;
using Fluent;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core.UI.PrismExtensions.Regions
{
    public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>, IRibbonRegionAdapter
    {
        public RibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        private Ribbon _ribbon;

        public IRegion Initialize(object regionTarget, string regionName)
        {
            _ribbon = regionTarget as Ribbon;
            if (_ribbon == null)
            {
                throw new Exception("Type not supported");
            }

            var region = CreateRegion();
            region.Name = regionName;

            this.AttachBehaviors(region, _ribbon);
            this.AttachDefaultBehaviors(region, _ribbon);

            return region;
        }

        protected override IRegion CreateRegion()
        {
            return new RibbonRegion(_ribbon);
        }

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
        }
    }
}
