using System;
using UIKit;

namespace GalaSoft.MvvmLight.Test.Controls
{
    // ReSharper disable once InconsistentNaming
    public class UISwitchEx : UISwitch
    {
        public new bool On
        {
            get
            {
                return base.On;
            }

            set
            {
                if (base.On != value)
                {
                    base.On = value;
                    PerformEvent();
                }
            }
        }

        public UISwitchEx()
        {
            base.ValueChanged += BaseValueChanged;
        }

        public void PerformEvent()
        {
            var handler = ValueChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void BaseValueChanged(object sender, EventArgs e)
        {
            PerformEvent();
        }

        public new event EventHandler ValueChanged;
    }
}