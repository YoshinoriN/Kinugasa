using Kinugasa.EnumExtensions.Attributes;

namespace Kinugasa.EnumExtensions.Test.Alias.Mocks
{
    public enum MockEnum
    {
        [AliasAttribute("モック1")]
        Mock1,

        [AliasAttribute("モック2")]
        Mock2,

        Mock3
    }
}
