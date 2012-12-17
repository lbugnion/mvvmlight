using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestBaseClass
    {
        public void Remove()
        {
            SimpleIoc.Default.Unregister(this);
        }
    }

    public class TestChildClass : TestBaseClass
    {
    }
}
