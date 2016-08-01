using System;

/// <summary>
/// Provide mvvm infrastructure.
/// </summary>
namespace Kinugasa.Uwp.Mvvm
{
    /// <summary>
    /// Provide whoes create command. Can not use argument.
    /// </summary>
    public class DelegateCommand : DelegateCommandBase
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Create new instance of DelegateCommand.
        /// Can execute everytime.
        /// </summary>
        /// <param name="execute">Execute method.</param>
        public DelegateCommand(Action execute) : this(execute, () => true) { }

        /// <summary>
        /// Create new instance of DelegateCommand.
        /// </summary>
        /// <param name="execute">Execute method.</param>
        /// <param name="canExecute">When can call execute method. Can input null.</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute");
            }

            this._execute = execute;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method when call the command.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            this._execute();
        }

        /// <summary>
        /// Defines the method whether the command can execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
    }

    /// <summary>
    /// Provide whose defined command. Can use argument.
    /// Implemented ICommand.
    /// </summary>
    public class DelegateCommand<T> : DelegateCommandBase
    {

        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        /// <summary>
        /// Create new instance of DelegateCommand.
        /// </summary>
        /// <param name="execute">Execute method.</param>
        public DelegateCommand(Action<T> execute) : this(execute, (O) => true) { }

        /// <summary>
        /// Create new instance of DelegateCommand.
        /// </summary>
        /// <param name="execute">Execute method.</param>
        /// <param name="canExecute">When can call execute method. Can input null.</param>
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute");
            }

            this._execute = execute;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// Defines the method when call the command.
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            this._execute((T)parameter);
        }

        /// <summary>
        /// Defines the method whether the command can execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }
    }
}
