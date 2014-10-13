using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Core.UI.PrismExtensions
{
    public class CustomSelectorRegionAdapter : RegionAdapterBase<Selector>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SelectorRegionAdapter"/>.
        /// </summary>
        /// <param name="regionBehaviorFactory">The factory used to create the region behaviors to attach to the created regions.</param>
        public CustomSelectorRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        /// <summary>
        /// Adapts an <see cref="Selector"/> to an <see cref="IRegion"/>.
        /// </summary>
        /// <param name="region">The new region being used.</param>
        /// <param name="regionTarget">The object to adapt.</param>
        protected override void Adapt(IRegion region, Selector regionTarget)
        {
        }

        protected override void AttachBehaviors(IRegion region, Selector regionTarget)
        {
            if (region == null) throw new System.ArgumentNullException("region");
            // Add the behavior that syncs the items source items with the rest of the items
            region.Behaviors.Add(
                SelectorItemsSourceSyncBehavior.BehaviorKey, 
                new SelectorItemsSourceSyncBehavior()
                {
                    HostControl = regionTarget
                }
            );

            base.AttachBehaviors(region, regionTarget);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Region"/>.
        /// </summary>
        /// <returns>A new instance of <see cref="Region"/>.</returns>
        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
