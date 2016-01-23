using System;
using UIKit;

namespace GalaSoft.MvvmLight.Test.Controls
{
    // ReSharper disable once InconsistentNaming
    public class UIButtonEx : UIButton
    {
        public UIButtonEx()
        {
            base.TouchUpInside += BaseTouchUpInside;
        }

        public void PerformEvent()
        {
            var handler = TouchUpInside;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void BaseTouchUpInside(object sender, EventArgs e)
        {
            PerformEvent();
        }

        public new event EventHandler TouchUpInside;
    }
}