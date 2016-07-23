using System;
using System.Windows.Input;

/// <summary>
/// Provide mvvm infrastructure.
/// </summary>
namespace Kinugasa.Mvvm.Core
{
    /// <summary>
    /// Provide whoes create command. Can not use argument.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// When call RaiseCanExecuteChanged method.
        /// </summary>
        public event EventHandler CanExecuteChanged;

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
        public void Execute(object parameter)
        {
            this._execute();
        }

        /// <summary>
        /// Defines the method whether the command can execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Call the RaiseCanExecuteChanged method.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Provide whose defined command. Can use argument.
    /// Implemented ICommand.
    /// </summary>
    public class DelegateCommand<T> : ICommand
    {

        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        /// <summary>
        /// When call RaiseCanExecuteChanged method.
        /// </summary>
        public event EventHandler CanExecuteChanged;

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
        public void Execute(object parameter)
        {
            this._execute((T)parameter);
        }

        /// <summary>
        /// Defines the method whether the command can execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        /// <summary>
        /// Call the RaiseCanExecuteChanged method.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
