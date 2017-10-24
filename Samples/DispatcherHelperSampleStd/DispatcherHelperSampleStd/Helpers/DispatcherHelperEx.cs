using DispatcherHelperSampleStd.Data.Helpers;
using GalaSoft.MvvmLight.Threading;
using System;

namespace DispatcherHelperSampleStd.Helpers
{
    public class DispatcherHelperEx : IDispatcherHelper
    {
        public void CheckBeginInvokeOnUi(Action action)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }
    }
}
