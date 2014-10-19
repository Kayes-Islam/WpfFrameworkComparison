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
    public class RibbonPageGroupRegionAdapter : RegionAdapterBase<RibbonGroupBox>, IRibbonPageGroupRegionAdapter
    {
        public RibbonPageGroupRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
        {
        }

        private RibbonGroupBox _ribbonPageGroup;

        public IRegion Initialize(object regionTarget, string regionName)
        {
            _ribbonPageGroup = regionTarget as RibbonGroupBox;
            if (_ribbonPageGroup == null)
            {
                throw new Exception("Type not supported");
            }

            var region = new RibbonPageGroupRegion(_ribbonPageGroup);
            region.Name = regionName;

            //this.AttachBehaviors(region, ribbonPageGroup);
            this.AttachDefaultBehaviors(region, _ribbonPageGroup);

            return region;
        }

        protected override IRegion CreateRegion()
        {
            return new RibbonPageGroupRegion(_ribbonPageGroup);
        }

        protected override void Adapt(IRegion region, RibbonGroupBox regionTarget)
        {
        }
    }
}
