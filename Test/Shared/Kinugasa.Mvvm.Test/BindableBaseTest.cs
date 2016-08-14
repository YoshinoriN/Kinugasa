using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mvvm.Test
{
    [TestClass]
    public class BindableBaseTest
    {
        [TestMethod]
        public void MockIntTest()
        {
            var mockViewModel = new Mocks.MockViewModel();
            mockViewModel.MockInt = 1;

            Assert.AreEqual(1, mockViewModel.MockInt);
        }

        [TestMethod]
        public void MockStringTest()
        {
            var mockViewModel = new Mocks.MockViewModel();
            mockViewModel.MockString = "test";

            Assert.AreEqual("test", mockViewModel.MockString);
        }

        [TestMethod]
        public void MockOvservableCollectionTest()
        {
            var mockViewModel = new Mocks.MockViewModel();
            mockViewModel.MockObservalCollection.Add(new Mocks.MockModel { MockInt = 1, MockString = "test"});
            mockViewModel.MockObservalCollection.Add(new Mocks.MockModel { MockInt = 2, MockString = "test2" });

            Assert.AreEqual(1, mockViewModel.MockObservalCollection[0].MockInt);
            Assert.AreEqual("test", mockViewModel.MockObservalCollection[0].MockString);
            Assert.AreEqual(2, mockViewModel.MockObservalCollection[1].MockInt);
            Assert.AreEqual("test2", mockViewModel.MockObservalCollection[1].MockString);
        }

        [TestMethod]
        public void OnPropertyChangedTestSuccess()
        {
            var mockViewModel = new Mocks.MockViewModel();

            bool invoked = false;
            mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockInt")) invoked = true; };
            mockViewModel.MockInt = 1;

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void OnPropertyChangedPropertyNameTestSuccess()
        {
            var mockViewModel = new Mocks.MockViewModel();

            bool invoked = false;
            mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockProperty")) invoked = true; };
            mockViewModel.InvokeOnPropertyChanged();

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void OnPropertyChangedPropertyNameTestFaild()
        {
            var mockViewModel = new Mocks.MockViewModel();

            bool invoked = false;
            mockViewModel.PropertyChanged += (o, e) => { if (e.PropertyName.Equals("MockFaild")) invoked = true; };
            mockViewModel.InvokeOnPropertyChanged();

            Assert.IsFalse(invoked);
        }
    }
}
