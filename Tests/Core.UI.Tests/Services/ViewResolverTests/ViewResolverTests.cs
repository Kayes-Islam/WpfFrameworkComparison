using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.UI.Services;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Core.UI.Interfaces;

namespace Core.UI.Tests.Services
{
    [TestClass]
    public class ViewResolverTests
    {
        private ViewResolver _viewResolver;
        [TestInitialize]
        public void Setup()
        {
            var container = new WindsorContainer();

            _viewResolver = new ViewResolver(container);
        }

        [TestMethod]
        public void ViewResolver_Returns_Correct_View_Type_For_Type_Ending_With_ViewModel()
        {
            var viewType = _viewResolver.GetViewType(typeof(DemoViewModel));
            Assert.AreEqual(viewType, typeof(DemoView));
        }

        [TestMethod]
        public void ViewResolver_Returns_Correct_View_Type_For_Type_Ending_Without_ViewModel()
        {
            var viewType = _viewResolver.GetViewType(typeof(Demo));
            Assert.AreEqual(viewType, typeof(DemoView));
        }

        [TestMethod]
        public void ViewResolver_Returns_Correct_View_Interface_Type()
        {
            var viewType = _viewResolver.GetViewType(typeof(Demo2ViewModel));
            Assert.AreEqual(viewType, typeof(IDemo2View));
        }
    }
}
