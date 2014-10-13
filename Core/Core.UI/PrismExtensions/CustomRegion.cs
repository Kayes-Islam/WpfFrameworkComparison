using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.PrismExtensions
{
    public class CustomSelectorRegion : IRegion
    {
        private class CustomViewsCollection : ObservableCollection<object>, IViewsCollection { }
        private IViewsCollection _views;

        public CustomSelectorRegion(IRegionNavigationService navigationService)
        {
            NavigationService = navigationService;
            _views = new CustomViewsCollection();
        }

        public void Activate(object view)
        {
        }

        public IViewsCollection ActiveViews
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRegionManager Add(object view, string viewName, bool createRegionManagerScope)
        {
            throw new NotImplementedException();
        }

        public IRegionManager Add(object view, string viewName)
        {
            throw new NotImplementedException();
        }

        public IRegionManager Add(object view)
        {
            throw new NotImplementedException();
        }

        public IRegionBehaviorCollection Behaviors
        {
            get { throw new NotImplementedException(); }
        }

        public object Context
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Deactivate(object view)
        {
            throw new NotImplementedException();
        }

        public object GetView(string viewName)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IRegionNavigationService NavigationService { get; set; }

        public IRegionManager RegionManager
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Remove(object view)
        {
            throw new NotImplementedException();
        }

        public Comparison<object> SortComparison
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IViewsCollection Views
        {
            get { throw new NotImplementedException(); }
        }

        public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate(Uri target, Action<NavigationResult> navigationCallback)
        {
            throw new NotImplementedException();
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
