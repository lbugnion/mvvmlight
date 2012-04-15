using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public interface ITestMessage
    {
        string Content
        {
            get;
        }
    }
}
