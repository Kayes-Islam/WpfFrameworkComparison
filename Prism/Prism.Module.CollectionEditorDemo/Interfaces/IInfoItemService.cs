using Prism.Module.CollectionEditorDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Module.CollectionEditorDemo.Interfaces
{
    public interface IInfoItemService
    {
        List<InfoItemViewModel> GetInfoItems();

    }
}
