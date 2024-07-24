using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Edit_Info.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action = null;
        private readonly Func<bool> _predicate = null;

        public RelayCommand(Action action)
            : this(null, action)
        {
        }

        public RelayCommand(Func<bool> predicate, Action action)
        {
            _predicate = predicate;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null ? true : _predicate();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _predicate = null;
        private readonly Action<T> _action = null;

        public RelayCommand(Action<T> action)
            : this(null, action)
        {
        }

        public RelayCommand(Predicate<T> predicate, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            _predicate = predicate;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null ? true : _predicate((T)parameter);
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
