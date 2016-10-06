using System;

/// <summary>
/// Provide extension function for enum using by attributes.
/// </summary>
namespace Kinugasa.EnumExtensions.Attributes
{
    /// <summary>
    /// Apply alias name to Enum
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class AliasAttribute : Attribute
    {
        public string AliasName { get; private set; }

        public AliasAttribute(string alias)
        {
            this.AliasName = alias;
        }
    }
}
