using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Notifications
{
    public class Notification<T> : Notification where T : class
    {
        private T _viewModel;
        public T ViewModel
        {
            get
            {
                return _viewModel;
            }
        }

        public object Content
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value as T;
            }
        }

        public string Title { get; set; }
    }
}
