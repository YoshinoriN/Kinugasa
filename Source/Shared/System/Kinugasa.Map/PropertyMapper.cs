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
        /// <typeparam name="TDestination">Instance of classA.</typeparam>
        /// <typeparam name="TSource">Instance of classB.</typeparam>
        public static void Map<TDestination, TSource>(ref TDestination destination, TSource source)
            where TDestination : class
            where TSource : class
        {
            var destinationTypeInfo = destination.GetType().GetTypeInfo();
            var sourceTypeInfo = source.GetType().GetTypeInfo();

            foreach (PropertyInfo destinationPropertyInfo in destinationTypeInfo.DeclaredProperties)
            {
                foreach (PropertyInfo sourcePropertyInfo in sourceTypeInfo.DeclaredProperties)
                {
                    if (destinationPropertyInfo.Name == sourcePropertyInfo.Name)
                    {
                        destinationPropertyInfo.SetValue(destination, sourcePropertyInfo.GetValue(source));
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// To map properties value between classA and classB, using by <see cref="MapAttribute"/>.
        /// ClassB properties value will map to classA properties, if classA's property use <see cref="MapAttribute"/>.
        /// ClassA have to specify classB's property name using by <see cref="MapAttribute"/>.
        /// </summary>
        /// <typeparam name="TDestination">Instance of classA.</typeparam>
        /// <typeparam name="TSource">Instance of classB.</typeparam>
        public static void AttributeMap<TDestination, TSource>(ref TDestination destination, TSource source)
            where TDestination : class
            where TSource : class
        {
            var destinationTypeInfo = destination.GetType().GetTypeInfo();
            var sourceTypeInfo = source.GetType().GetTypeInfo();

            foreach (PropertyInfo destinationPropertyInfo in destinationTypeInfo.DeclaredProperties)
            {
                var attribute = destinationPropertyInfo.GetCustomAttribute(typeof(MapAttribute));
                if (attribute == null)
                {
                    continue;
                }

                string attributeName = ((MapAttribute)attribute).AttributeName;
                foreach (PropertyInfo sourcePropertyInfo in sourceTypeInfo.DeclaredProperties)
                {
                    if (attributeName == sourcePropertyInfo.Name)
                    {
                        destinationPropertyInfo.SetValue(destination, sourcePropertyInfo.GetValue(source));
                    }
                }
            }
        }
    }
}
