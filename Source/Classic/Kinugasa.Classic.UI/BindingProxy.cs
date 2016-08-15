using System.Windows;

/// <summary>
/// Provide userinterface components.
/// </summary>
namespace Kinugasa.Classic.UI
{
    /// <summary>
    /// Proxy class for binding sorce.
    /// </summary>
    public class BindingProxy : Freezable
    {
        /// <summary>
        /// Define dependencyProperty.
        /// </summary>
        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));

        /// <summary>
        /// Create freezable object's instance.
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        /// <summary>
        /// Proxy property.
        /// </summary>
        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
    }
}
