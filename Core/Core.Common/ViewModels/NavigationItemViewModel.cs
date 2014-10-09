using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;

namespace Core.Common.ViewModels
{
    public class NavigationItemViewModel : BindableBase
    {
        private string _title;
        private bool _isVisible;
        private ICommand _command;

        public NavigationItemViewModel() { }

        public NavigationItemViewModel(string title, ICommand command)
            : this()
        {
            Title = title;
            Command = command;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(() => Title);
            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged(() => IsVisible);
            }
        }

        public ICommand Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                OnPropertyChanged(() => Command);
            }
        }
    }
}
