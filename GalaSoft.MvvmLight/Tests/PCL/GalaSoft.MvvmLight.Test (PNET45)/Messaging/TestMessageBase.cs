using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class TestMessageBase : MessageBase, ITestMessage
    {
        public TestMessageBase(object sender)
            : base(sender)
        { 
        }

        public string Content
        {
            get;
            set;
        }
    }
}
