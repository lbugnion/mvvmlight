using System;
using UIKit;

namespace GalaSoft.MvvmLight.Test.Controls
{
    // ReSharper disable once InconsistentNaming
    public class UIBarButtonItemEx : UIBarButtonItem
    {
        public UIBarButtonItemEx()
        {
            base.Clicked += BaseClicked;
        }

        public void PerformEvent()
        {
            var handler = Clicked;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void BaseClicked(object sender, EventArgs e)
        {
            PerformEvent();
        }

        public new event EventHandler Clicked;
    }
}