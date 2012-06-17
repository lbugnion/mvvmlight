using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestClass : ITestClass
    {
        public static int InstancesCount
        {
            get;
            private set;
        }

        public static void Reset()
        {
            InstancesCount = 0;
        }

        public TestClass()
        {
            Identifier = Guid.NewGuid().ToString();
            InstancesCount++;
        }

        public string Identifier
        {
            get;
            private set;
        }
    }
}
