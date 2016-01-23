using System;
using UIKit;

namespace GalaSoft.MvvmLight.Test.Controls
{
    // ReSharper disable once InconsistentNaming
    public class UITextViewEx : UITextView
    {
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    PerformEvent();
                }
            }
        }

        public UITextViewEx()
        {
            base.Changed += BaseChanged;
        }

        public void PerformEvent()
        {
            var handler = Changed;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void BaseChanged(object sender, EventArgs e)
        {
            PerformEvent();
        }

        public new event EventHandler Changed;
    }
}