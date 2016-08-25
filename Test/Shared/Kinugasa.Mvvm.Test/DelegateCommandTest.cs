using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Windows.Input;

namespace Mvvm.Test
{
    [TestClass]
    public class DelegateCommandBaseTest
    {
        [TestMethod]
        public void RaisCanExecuteNotNull()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod, null);
            bool canExecuteChangeraised = false;
            command.CanExecuteChanged += delegate { canExecuteChangeraised = true; };
            command.RaiseCanExecuteChanged();

            Assert.IsTrue(canExecuteChangeraised);
        }

        [TestMethod]
        public void RaisCanExecuteIsNull()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod, null);
            command.CanExecuteChanged += null ;
            command.RaiseCanExecuteChanged();
        }
    }

    [TestClass]
    public class DelegateCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ArgumentExceptionTest()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(null);
        }

        [TestMethod]
        public void CanExecuteNullTest()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod, null);
            Assert.IsTrue(command.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteNonNullTestSuccess()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod, Mocks.MockMethods.MockMethodReturnTrue);
            var obj = new object();
            Assert.IsTrue(command.CanExecute(obj));
        }

        [TestMethod]
        public void CanExecuteNonNullTestFaild()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod, Mocks.MockMethods.MockMethodReturnFalse);
            var obj = new object();
            Assert.IsFalse(command.CanExecute(obj));
        }

        [TestMethod]
        public void ExecuteTestSuccess()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod);
            var po = new PrivateObject(command);
            Assert.IsTrue(po.GetField("_execute").Equals((Action)Mocks.MockMethods.MockMethod));
        }

        [TestMethod]
        public void ExecuteTestFaild()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand(Mocks.MockMethods.MockMethod);
            var po = new PrivateObject(command);
            Assert.IsFalse(po.GetField("_execute").Equals((Action)Mocks.MockMethods.MockMethod2));
        }
    }

    [TestClass]
    public class DelegateCommandHasArgumentTest
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ArgumentExceptionTest()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand<int>(null);
        }

        [TestMethod]
        public void CanExecuteNullTest()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand<int>(Mocks.MockMethods.MockMethodHasArgument, null);
            Assert.IsTrue(command.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteNonNullTestSuccess()
        {
            //HACK : Need brush up.
            var command = new Kinugasa.Mvvm.DelegateCommand<int>(Mocks.MockMethods.MockMethodHasArgument, Mocks.MockMethods.MockMethodReturnTrue);
            Assert.IsTrue(command.CanExecute(1));
        }

        [TestMethod]
        public void CanExecuteNonNullTestFaild()
        {
            //HACK : Need brush up.
            var command = new Kinugasa.Mvvm.DelegateCommand<int>(Mocks.MockMethods.MockMethodHasArgument, Mocks.MockMethods.MockMethodReturnFalse);
            var obj = new object();
            Assert.IsFalse(command.CanExecute(1));
        }

        [TestMethod]
        public void ExecuteTestSuccess()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand<int>(Mocks.MockMethods.MockMethodHasArgument);
            var po = new PrivateObject(command);
            Assert.IsTrue(po.GetField("_execute").Equals((Action<int>)Mocks.MockMethods.MockMethodHasArgument));
        }

        [TestMethod]
        public void ExecuteTestFaild()
        {
            var command = new Kinugasa.Mvvm.DelegateCommand<int>(Mocks.MockMethods.MockMethodHasArgument);
            var po = new PrivateObject(command);
            Assert.IsFalse(po.GetField("_execute").Equals((Action)Mocks.MockMethods.MockMethod2));
        }
    }
}
