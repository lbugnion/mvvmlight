using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestClass3
    {
        public ITestClass SavedProperty
        {
            get;
            set;
        }

        public TestClass3(ITestClass parameter)
        {
            SavedProperty = parameter;
        }
    }
}
