using Core.Common.Models;
using Core.UI.Interfaces;
using Fluent;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.PrismExtensions.Regions
{
    public class RibbonRegion : BindableBase, IRibbonRegion
    {
        private readonly Ribbon _ribbon;

        private ObservableCollection<ItemMetadata> _ribbonItemsMetaData;
        private ViewsCollection _views;
        private ViewsCollection _activeViews;

        public RibbonRegion(Ribbon groupBox)
        {
            _ribbon = groupBox;
            _ribbonItemsMetaData = new ObservableCollection<ItemMetadata>();
            _views = new ViewsCollection(_ribbonItemsMetaData, x => true);
            _activeViews = new ViewsCollection(_ribbonItemsMetaData, x => x.IsActive == true);
            SortComparison = Region.DefaultSortComparison;
            Behaviors = new RegionBehaviorCollection(this);
        }

        public void Activate(object view)
        {
            // Activates the tab
            var item = view as RibbonItem;

            if (item != null)
            {
                var tab = _ribbon.Tabs
                    .FirstOrDefault(t => t.Header.ToString() == item.TabHeader);

                if (tab != null)
                {
                    _ribbon.SelectedTabItem = tab;
                }
            }
        }

        public IViewsCollection ActiveViews
        {
            get
            {
                return _views;
            }
        }

        public IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
        {
            IRegionManager manager = createRegionManagerScope ? this.RegionManager.CreateRegionManager() : this.RegionManager;
            var ribbonItem = view as RibbonItem;
            if (ribbonItem != null)
            {
                ItemMetadata metaData;
                if (viewName != null)
                {
                    metaData = _ribbonItemsMetaData.FirstOrDefault(m => m.Name == viewName);
                    if (metaData != null)
                    {
                        throw new Exception(
                            string.Format(
                                "Item with name {0} already exists in ribbon",
                                viewName
                            )
                        );
                    }
                }

                metaData = new ItemMetadata(view);
                metaData.Name = viewName;
                _ribbonItemsMetaData.Add(metaData);
                if (ribbonItem != null)
                {
                    AddItemToRibbon(ribbonItem);
                    _ribbon.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                if (view != null)
                {
                    throw new Exception(
                        string.Format("Type {0} is not supported for Ribbon region.", view.GetType().Name)
                    );
                }
            }

            return manager;
        }

        public IRegionManager Add(object view, string viewName)
        {
            return Add(view, viewName, false);
        }

        public IRegionManager Add(object view)
        {
            return Add(view, null, false);
        }

        public IRegionBehaviorCollection Behaviors { get; private set; }

        public object Context { get; set; }

        public void Deactivate(object view)
        {
            // selects the first tab
            _ribbon.SelectedTabIndex = 0;
        }

        public object GetView(string viewName)
        {
            ItemMetadata itemData = _ribbonItemsMetaData
                .FirstOrDefault(m => m.Name == viewName);

            return itemData.Item;
        }

        public string Name { get; set; }

        public IRegionNavigationService NavigationService { get; set; }

        public IRegionManager RegionManager { get; set; }

        public void Remove(object view)
        {
            var metaData = _ribbonItemsMetaData
                .FirstOrDefault(m => m.Item == view);
            if (metaData != null)
            {
                _ribbonItemsMetaData.Remove(metaData);
                var ribbonItem = metaData.Item as RibbonItem;
                RemoveItemFromRibbon(ribbonItem);
            }
        }

        public Comparison<object> SortComparison { get; set; }

        public IViewsCollection Views
        {
            get
            {
                return _views;
            }
        }

        public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback)
        {
            throw new NotImplementedException();
        }

        private void AddItemToRibbon(RibbonItem item)
        {
            var tabItem = FindOrCreateTab(item.TabHeader);
            var groupBox = FindOrCreateGroup(tabItem, item.GroupHeader);
            groupBox.Items.Add(item.RibbonControl);
            tabItem.Visibility = System.Windows.Visibility.Visible;
            groupBox.Visibility = System.Windows.Visibility.Visible;
        }

        private RibbonTabItem FindOrCreateTab(string header)
        {
            var tabItem = _ribbon.Tabs
                .FirstOrDefault(t => t.Header.ToString() == header);
            if (tabItem == null)
            {
                tabItem = new RibbonTabItem();
                tabItem.Header = header;
                _ribbon.Tabs.Add(tabItem);
            }

            return tabItem;
        }

        private RibbonGroupBox FindOrCreateGroup(RibbonTabItem tabItem, string header)
        {
            var groupBox = tabItem.Groups
                .FirstOrDefault(g => g.Header.ToString() == header);
            if (groupBox == null)
            {
                groupBox = new RibbonGroupBox();
                groupBox.Header = header;
                tabItem.Groups.Add(groupBox);
            }

            return groupBox;
        }

        private void RemoveItemFromRibbon(RibbonItem ribbonItem)
        {
            var tab = _ribbon.Tabs
                .FirstOrDefault(t => t.Header.ToString() == ribbonItem.TabHeader);
            if (tab == null) return;

            var group = tab.Groups
                .FirstOrDefault(g => g.Header.ToString() == ribbonItem.GroupHeader);
            if (group == null) return;

            group.Items.Remove(ribbonItem.RibbonControl);
            AdjustGroupVisibility(group);
            AdjustTabVisibility(tab);
        }

        private void AdjustTabVisibility(RibbonTabItem tabItem)
        {
            if (tabItem.Groups.Any(g => g.Visibility == System.Windows.Visibility.Visible))
            {
                tabItem.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                tabItem.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void AdjustGroupVisibility(RibbonGroupBox groupBox)
        {
            if (groupBox.Items.Count > 0)
            {
                groupBox.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                groupBox.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
