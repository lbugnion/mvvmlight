using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestClassForCreationTime : ITestClass
    {
        public static int InstancesCreated
        {
            get;
            private set;
        }

        public TestClassForCreationTime()
        {
            InstancesCreated++;
        }

        public static void Reset()
        {
            InstancesCreated = 0;
        }
    }
}
