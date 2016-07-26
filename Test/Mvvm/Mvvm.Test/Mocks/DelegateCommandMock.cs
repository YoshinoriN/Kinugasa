using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm.Test.Mocks
{
    public class DelegateCommandMock : Kinugasa.Mvvm.DelegateCommand
    {
        public DelegateCommandMock(Action execute) : base(execute, () => true)
        {

        }

        public DelegateCommandMock(Action execute, Func<bool> canExecute) : base(execute, canExecute)
        {

        }
    }

    public class DelegateCommandMock<T> : Kinugasa.Mvvm.DelegateCommand<T>
    {
        public DelegateCommandMock(Action<T> execute) : base(execute, (O) => true)
        {

        }

        public DelegateCommandMock(Action<T> execute, Func<T, bool> canExecute) : base(execute, canExecute)
        {

        }
    }

    internal static class MockMethods
    {
        internal static void MockMethod()
        {

        }

        internal static void MockMethod2()
        {

        }

        internal static bool MockMethodReturnTrue()
        {
            return true;
        }

        internal static bool MockMethodReturnFalse()
        {
            return false;
        }

        internal static void MockMethodHasArgument(int x)
        {

        }

        internal static void MockMethodHasArgument2(int x)
        {

        }

        internal static bool MockMethodReturnTrue(int x)
        {
            return true;
        }

        internal static bool MockMethodReturnFalse(int x)
        {
            return false;
        }
    }
}
