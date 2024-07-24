using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Edit_Info.Command
{
    public class DelegateCommandModel : CommandModel, ICommand
    {
        #region Fields

        private ExecuteDelegate _executeHandler;
        private CanExecuteDelegate _canExecuteHandler;

        #endregion Fields

        #region Constructors

        public DelegateCommandModel(ExecuteDelegate executeHandler)
        {
            _executeHandler = executeHandler;
        }

        public DelegateCommandModel(ExecuteDelegate executeHandler,
            CanExecuteDelegate canExecuteHandler)
        {
            _executeHandler = executeHandler;
            _canExecuteHandler = canExecuteHandler;
        }

        #endregion Constructors

        #region Override methods

        public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (CanExecuteChanged != null)
            //    CanExecuteChanged(sender, new EventArgs());

            e.CanExecute = CanExecute(e.Parameter);
            e.Handled = true;
        }

        public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            Execute(e.Parameter);
        }

        #endregion Override methods

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler == null ? true : _canExecuteHandler(parameter);
        }

        // public event EventHandler CanExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }

        #endregion ICommand Members
    }
}
