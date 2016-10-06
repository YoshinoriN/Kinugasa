using System.Reflection;
using Kinugasa.EnumExtensions.Attributes;

/// <summary>
/// Provide extension function for enum.
/// </summary>
namespace Kinugasa.EnumExtensions.Services
{
    /// <summary>
    /// Static functions for alias name.
    /// </summary>
    public static class AliasName
    {
        /// <summary>
        /// Get alias name of enum.
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="source">Enum value</param>
        /// <returns><see cref="AliasAttribute.AliasName"></returns>
        public static string GetAlias<T>(this T source)
            where T : struct
        {
            var attribute = source.GetType().GetRuntimeField(source.ToString()).GetCustomAttribute(typeof(AliasAttribute), false);
            return attribute == null ? source.ToString() : ((AliasAttribute)attribute).AliasName;
        }
    }
}
