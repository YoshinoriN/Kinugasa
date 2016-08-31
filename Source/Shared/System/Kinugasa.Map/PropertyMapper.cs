using System.Reflection;
using Kinugasa.Map.Attributes;

/// <summary>
/// Provide featuer of mapping some values.
/// </summary>
namespace Kinugasa.Map
{
    /// <summary>
    /// To map same properties value between classA and classB.
    /// </summary>
    public static class PropertyMapper
    {
        /// <summary>
        /// To map same properties value between classA and classB.
        /// ClassB properties value will map to classA properties.
        /// </summary>
        /// <typeparam name="Type">Instance of classA.</typeparam>
        /// <typeparam name="Type2">Instance of classB.</typeparam>
        public static void Map<Type, Type2>(ref Type T1, Type2 T2)
            where Type : class
            where Type2 : class
        {
            var typeInfo = T1.GetType().GetTypeInfo();
            var typeInfo2 = T2.GetType().GetTypeInfo();

            foreach (PropertyInfo propertyInfo in typeInfo.DeclaredProperties)
            {
                foreach (PropertyInfo propertyInfo2 in typeInfo2.DeclaredProperties)
                {
                    if (propertyInfo.Name == propertyInfo2.Name)
                    {
                        propertyInfo.SetValue(T1, propertyInfo2.GetValue(T2));
                        //TODO : break nested roop.
                    }
                }
            }
        }

        /// <summary>
        /// To map properties value between classA and classB, using by <see cref="MapAttribute"/>.
        /// ClassB properties value will map to classA properties, if classA's property use <see cref="MapAttribute"/>.
        /// ClassA have to specify classB's property name using by <see cref="MapAttribute"/>.
        /// </summary>
        /// <typeparam name="Type">Instance of classA.</typeparam>
        /// <typeparam name="Type2">Instance of classB.</typeparam>
        public static void AttributeMap<Type, Type2>(ref Type T1, Type2 T2)
            where Type : class
            where Type2 : class
        {
            var typeInfo = T1.GetType().GetTypeInfo();
            var typeInfo2 = T2.GetType().GetTypeInfo();

            foreach (PropertyInfo propertyInfo in typeInfo.DeclaredProperties)
            {
                var attribute = propertyInfo.GetCustomAttribute(typeof(MapAttribute));

                if (attribute == null)
                {
                    continue;
                }

                string attributeName = ((MapAttribute)attribute).AttributeName;

                foreach (PropertyInfo propertyInfo2 in typeInfo2.DeclaredProperties)
                {
                    if (attributeName == propertyInfo2.Name)
                    {
                        propertyInfo.SetValue(T1, propertyInfo2.GetValue(T2));
                    }
                }
            }
        }
    }
}
