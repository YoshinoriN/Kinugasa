using System;
using System.Windows.Input;

namespace Kinugasa.Mvvm
{
    /// <summary>
    /// Abstract class for implement command class. 
    /// </summary>
    public abstract class DelegateCommandBase : ICommand
    {
        /// <summary>
        /// When call RaiseCanExecuteChanged method.
        /// </summary>
        public event EventHandler CanExecuteChanged;

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

        public abstract void Execute(object parameter);

        public abstract bool CanExecute(object parameter);
    }
}
