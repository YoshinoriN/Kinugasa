using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
/// Provide mvvm infrastructure.
/// </summary>
namespace Kinugasa.Mvvm
{
    /// <summary>
    /// Provide notification when propertie's values will change.
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// This event handler will work when propertie's values change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notificate to client and set a new value, if current property value and new property value are differnce.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="storeValue">Current value.</param>
        /// <param name="value">New value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>True:Change the value. /False:Same value.</returns>
        protected virtual bool SetProperty<T>(ref T storeValue, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storeValue, value))
            {
                return false;
            }
            storeValue = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notify to client when propery value will change.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
