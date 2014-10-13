using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interactions
{
    public interface IInteractionService
    {
        bool? ShowDialog(object viewModel);
    }
}
