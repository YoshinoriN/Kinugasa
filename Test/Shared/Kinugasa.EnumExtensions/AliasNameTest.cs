using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinugasa.EnumExtensions;

namespace Kinugasa.EnumExtensions.Test
{
    [TestClass]
    public class AliasNameTest
    {
        [TestMethod]
        public void GetAliasTest()
        {
            Assert.AreEqual("モック1", Alias.Mocks.MockEnum.Mock1.GetAlias());
            Assert.AreEqual("モック2", Alias.Mocks.MockEnum.Mock2.GetAlias());
            Assert.AreEqual("Mock3", Alias.Mocks.MockEnum.Mock3.GetAlias());
            Assert.AreEqual("モック1", AliasService.GetAlias(Alias.Mocks.MockEnum.Mock1));
            Assert.AreEqual("モック2", AliasService.GetAlias(Alias.Mocks.MockEnum.Mock2));
            Assert.AreEqual("Mock3", AliasService.GetAlias(Alias.Mocks.MockEnum.Mock3));
        }
    }
}
