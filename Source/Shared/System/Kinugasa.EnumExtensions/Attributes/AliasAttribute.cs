using System;

namespace Kinugasa.EnumExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class AliasAttribute : Attribute
    {
        public string AliasName { get; private set; }

        public AliasAttribute(string alias)
        {
            this.AliasName = alias;
        }
    }
}
