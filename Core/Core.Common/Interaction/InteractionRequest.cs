using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interaction
{
    public class InteractionRequest<T> : IInteractionRequest
    {
        public event EventHandler<InteractionRequestedEventArgs> Raised;

        public void Raise(T context)
        {
            Raise(context, c => { });
        }

        public void Raise(T context, Action<T> callback)
        {
            Notification notification = new Notification()
            {
                Content = context
            };

            var handler = Raised;
            if (handler != null)
            {
                handler(
                    this,
                    new InteractionRequestedEventArgs(
                        notification,
                        () => { if (callback != null) callback(context); }));
            }
        }
    }
}
