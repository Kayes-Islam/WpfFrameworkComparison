using Fluent;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prism.Shell.Views
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class ShellView : RibbonWindow, IView
    {
        public ShellView()
        {
            InitializeComponent();

            SetupRibbon();
        }

        private void SetupRibbon()
        {
            //var tabItem = new RibbonTabItem();
            //tabItem.Header = "Tab";
            //var group = new RibbonGroupBox();
            //group.Header = "Group";
            //tabItem.Groups.Add(group);
            //var button = new Fluent.Button();
            //button.Header = "Green";
            //button.Icon = @"..\Images\Green.png";
            //button.LargeIcon = @"..\Images\GreenLarge.png";
            //group.Items.Add(button);
            //Ribbon.Tabs.Add(tabItem);
        }
    }
}
