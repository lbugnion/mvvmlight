using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestClass6
    {
        public ITestClass MyProperty
        {
            get;
            set;
        }

        public TestClass6()
        {
            
        }

        public TestClass6(ITestClass myProperty)
        {
            MyProperty = myProperty;
        }
    }
}
