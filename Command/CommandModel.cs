using System.Windows.Input;

namespace Edit_Info.Command
{
    public delegate void ExecuteDelegate(object param);

    public delegate bool CanExecuteDelegate(object param);
   
    public abstract class CommandModel
    {
        #region Fields

        private RoutedCommand _routedCommand;

        #endregion Fields

        #region Properties

        // Routed command associated with the model.
        public RoutedCommand Command
        {
            get { return _routedCommand; }
        }

        #endregion Properties

        #region Constructors

        public CommandModel()
        {
            _routedCommand = new RoutedCommand();
        }

        #endregion Constructors

        // Determines if a command is enabled. Override to provide custom behavior. Do not call the
        // base version when overriding.
        public virtual void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        // Function to execute the command.
        public abstract void OnExecute(object sender, ExecutedRoutedEventArgs e);
    }
}
