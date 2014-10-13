using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo.Interfaces
{
    public interface ICollectionEditorDemoViewModel : INavigationAware
    {
        void LoadData();
    }
}
