using System.Linq;
using System.Reflection;
using Kinugasa.Map.Attributes;

/// <summary>
/// Provide featuer of mapping some values.
/// </summary>
namespace Kinugasa.Map
{
    /// <summary>
    /// To map same properties value between destination class and source class.
    /// </summary>
    public static class PropertyMapper
    {
        /// <summary>
        /// To map same properties value between destination class and source class.
        /// Source class properties value will map to destination class properties.
        /// </summary>
        /// <typeparam name="TDestination">Instance of destination class.</typeparam>
        /// <typeparam name="TSource">Instance of source class.</typeparam>
        public static void Map<TDestination, TSource>(ref TDestination destination, TSource source)
            where TDestination : class
            where TSource : class
        {
            var sourceProperties = source.GetType().GetTypeInfo().DeclaredProperties;
            var destinationProperties = destination.GetType().GetTypeInfo().DeclaredProperties.Where(dp => sourceProperties.Any(sp => sp.Name == dp.Name));

            foreach (PropertyInfo destinationPropertyInfo in destinationProperties)
            {
                destinationPropertyInfo.SetValue(destination, sourceProperties.First(sp => destinationPropertyInfo.Name == sp.Name).GetValue(source));
            }
        }

        /// <summary>
        /// To map properties value between destination class and source class, using by <see cref="MapAttribute"/>.
        /// Source class properties value will map to destination class properties, if destination class's property use <see cref="MapAttribute"/>.
        /// Destination class have to specify source class's property name using by <see cref="MapAttribute"/>.
        /// </summary>
        /// <typeparam name="TDestination">Instance of destination class.</typeparam>
        /// <typeparam name="TSource">Instance of source class.</typeparam>
        public static void AttributeMap<TDestination, TSource>(ref TDestination destination, TSource source)
            where TDestination : class
            where TSource : class
        {
            var sourceProperties = source.GetType().GetTypeInfo().DeclaredProperties;
            var destinationProperties = destination.GetType().GetTypeInfo().DeclaredProperties.Where(dp => dp.GetCustomAttribute(typeof(MapAttribute)) != null);

            foreach (PropertyInfo destinationPropertyInfo in destinationProperties)
            {
                destinationPropertyInfo.SetValue(destination, 
                                                 sourceProperties.First(sp => sp.Name == ((MapAttribute)destinationPropertyInfo.GetCustomAttribute(typeof(MapAttribute))).AttributeName)
                                                                 .GetValue(source));
            }
        }
        //TODO : Add mixed map method. (Normally mapping & attribute mapping)
    }
}
