using Prism.Module.CollectionEditorDemo.Interfaces;
using Prism.Module.CollectionEditorDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo.Services
{
    public class MockInfoItemService : IInfoItemService
    {
        public List<InfoItemViewModel> GetInfoItems()
        {
            return new List<InfoItemViewModel>()
            {
                new InfoItemViewModel()
                {
                    Name = "Item1",
                    Description = "Item 1",
                    Weight = 1,
                    Properties = new ObservableCollection<InfoItemPropertyViewModel>()
                    {
                        new InfoItemPropertyViewModel(){Name = "Prop1", Description = "Property 1", Value = "1"}
                    }
                },
                
                new InfoItemViewModel()
                {
                    Name = "Item2",
                    Description = "Item 2",
                    Weight = 1,
                    Properties = new ObservableCollection<InfoItemPropertyViewModel>()
                    {
                        new InfoItemPropertyViewModel(){Name = "Prop2", Description = "Property 2", Value = "2"}
                    }
                }
            };
        }
    }
}
