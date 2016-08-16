using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Kinugasa.UI.Test
{
    /// <summary>
    /// Hack : For PCL Unit test is very difficult.
    /// The normally unit test project can't assert collectory below test. Because, Kinugasa.UI.BooleanToVisibilityConverter are using Windows.UI class library.
    /// But those class liblarycan't use normally unit test project.
    /// I try to use UWP unit test project, but UWP unit test projyect has some errors.
    /// So, I decide the normally unit test and conpare resalt using by ToString method.
    /// </summary>
    [TestClass]
    public class BooleanToVisibilityConverterTest
    {
        private static Converter.BooleanToVisibilityConverter converter = new Converter.BooleanToVisibilityConverter();

        #region Convert

        [TestMethod]
        public void BooleanTrueConvertTest()
        {
            Assert.AreEqual(Visibility.Visible.ToString(), converter.Convert(true, typeof(System.Windows.Visibility), null, "").ToString());
        }

        [TestMethod]
        public void BooleanFalseConvertTest()
        {
            Assert.AreEqual(Visibility.Collapsed.ToString(), converter.Convert(false, typeof(System.Windows.Visibility), null, "").ToString());
        }

        [TestMethod]
        public void BooleanTrueConvertTestFailer()
        {
            Assert.AreNotEqual(Visibility.Visible.ToString(), converter.Convert(false, typeof(System.Windows.Visibility), null, "").ToString());
        }

        [TestMethod]
        public void BooleanFalseConvertTestFailer()
        {
            Assert.AreNotEqual(Visibility.Collapsed.ToString(), converter.Convert(true, typeof(System.Windows.Visibility), null, "").ToString());
        }
        #endregion

        //TODO : I have to write test code for ConvertBack. BUt how to do it... 
    }
}
