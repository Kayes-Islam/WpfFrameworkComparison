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
    public class RibbonPageGroupRegion : BindableBase, IRibbonRegion
    {
        private readonly RibbonGroupBox _ribbonPageGroup;

        private ObservableCollection<ItemMetadata> _ribbonItemsMetaData;
        private ViewsCollection _views;
        private ViewsCollection _activeViews;

        public RibbonPageGroupRegion(RibbonGroupBox groupBox)
        {
            _ribbonPageGroup = groupBox;
            _ribbonItemsMetaData = new ObservableCollection<ItemMetadata>();
            _views = new ViewsCollection(_ribbonItemsMetaData, x => true);
            _activeViews = new ViewsCollection(_ribbonItemsMetaData, x => x.IsActive == true);
            SortComparison = Region.DefaultSortComparison;
            Behaviors = new RegionBehaviorCollection(this);
        }

        public void Activate(object view)
        {
            // Activating ribbon item does nothing
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
                                "Item with name {0} already exists in ribbon page group {1}",
                                viewName,
                                _ribbonPageGroup.Header
                            )
                        );
                    }
                }

                metaData = new ItemMetadata(view);
                metaData.Name = viewName;
                _ribbonItemsMetaData.Add(metaData);
                if (ribbonItem != null)
                {
                    _ribbonPageGroup.Items.Add(ribbonItem.RibbonControl);
                    _ribbonPageGroup.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                if (view != null)
                {
                    throw new Exception(
                        string.Format("Type {0} is not supported for Ribbon Page Group region.", view.GetType().Name)
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
            // does nothing
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
                _ribbonPageGroup.Items.Remove(metaData.Item);
                if (_ribbonPageGroup.Items.Count == 0)
                {
                    _ribbonPageGroup.Visibility = System.Windows.Visibility.Hidden;
                }
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
    }
}
