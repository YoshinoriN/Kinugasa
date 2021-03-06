﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kinugasa.Map.Test.Models;

namespace Kinugasa.Map.Test
{
    [TestClass]
    public class PropertyMapperTest
    {
        [TestMethod]
        public void MapTest()
        {
            var a = new Destination();
            var b = new Source();
            PropertyMapper.Map(ref a, b);

            Assert.AreEqual(a.StringA, b.StringA);
            Assert.IsNull(a.StringB);
            Assert.AreEqual(a.IntA, b.IntA);
            Assert.AreEqual(a.IntB, 0);
            Assert.AreEqual(a.StringList, b.StringList);
            Assert.AreEqual(a.AttributeA,b.AttributeA);
        }

        [TestMethod]
        public void MapAttributeTest()
        {
            var a = new Destination();
            var b = new Source();
            PropertyMapper.AttributeMap(ref a, b);

            Assert.IsNull(a.StringA);
            Assert.AreEqual(a.IntB, 0);
            Assert.AreEqual(a.AttributeA, b.AttributeB);
            Assert.AreEqual(a.AttributeB, b.AttributeA);
            Assert.AreEqual(a.AttributeInt, b.AttributeInt2);
            Assert.AreEqual(a.AttributeInt2, b.AttributeInt);
        }
    }
}
