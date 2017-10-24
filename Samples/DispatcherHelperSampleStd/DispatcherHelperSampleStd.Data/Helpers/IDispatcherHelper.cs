using System;
using System.Collections.Generic;
using System.Text;

namespace DispatcherHelperSampleStd.Data.Helpers
{
    public interface IDispatcherHelper
    {
        void CheckBeginInvokeOnUi(Action action);
    }
}
