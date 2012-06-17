using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestClass5
    {
        public ITestClass MyProperty
        {
            get;
            private set;
        }

        public TestClass5()
        {
            
        }

        [PreferredConstructor]
        public TestClass5(ITestClass myProperty)
        {
            MyProperty = myProperty;
        }
    }
}
