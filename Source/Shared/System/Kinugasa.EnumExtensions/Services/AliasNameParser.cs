using System.Reflection;
using Kinugasa.EnumExtensions.Attributes;

namespace Kinugasa.EnumExtensions.Services
{
    public static class AliasNameParser
    {
        public static string GetAlias<T>(this T source)
        {
            var attribute = source.GetType().GetRuntimeField(source.ToString()).GetCustomAttribute(typeof(AliasAttribute), false);
            return attribute == null ? source.ToString() : ((AliasAttribute)attribute).AliasName;
        }
    }
}
