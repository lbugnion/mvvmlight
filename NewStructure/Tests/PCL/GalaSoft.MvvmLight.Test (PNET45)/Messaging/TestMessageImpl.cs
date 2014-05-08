using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class TestMessageImpl : TestMessageBase
    {
        public TestMessageImpl(object sender)
            : base(sender)
        { 
        }

        public bool Result
        {
            get;
            set;
        }
    }
}
