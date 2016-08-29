using System;

namespace Kinugasa.Map.Attributes
{
    /// <summary>
    /// Attribute for mapping class property value to another class property value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MapAttribute : Attribute
    {
        public string AttributeName { get; private set; }

        public MapAttribute(string attributeName)
        {
            this.AttributeName = attributeName;
        }
    }
}
