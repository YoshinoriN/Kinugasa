using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

/// <summary>
/// Provide converter for UI.
/// </summary>
namespace Kinugasa.UI.Converters
{
    /// <summary>
    /// Convert boolean values to visibility.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert boolean values to visibility.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        /// <param name="targetType">Visibility.</param>
        /// <returns>Visibility.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Convert visibility to boolean.
        /// </summary>
        /// <param name="value">Visibility.</param>
        /// <param name="targetType">The boolean value.</param>
        /// <returns>Boolean.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (Visibility)value == Visibility.Visible ? true : false;
        }
    }
}
