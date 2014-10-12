using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.ViewModels
{
    public class InteractionRequestAware : IInteractionRequestAware
    {
        public Action FinishInteraction { get; set; }
        public INotification Notification { get; set; }
    }
}
