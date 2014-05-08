using System;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    public class UiElementFake
    {
        public event EventHandler SimpleEvent;
        public event EventHandler<UiElementFakeEventArgs> EventArgsEvent;

        public string SimpleProperty1
        {
            get;
            set;
        }

        public string SimpleProperty2
        {
            get;
            set;
        }

        public void RaiseSimpleEvent()
        {
            var handler = SimpleEvent;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void RaiseEventArgsEvent()
        {
            var handler = EventArgsEvent;
            if (handler != null)
            {
                handler(this, new UiElementFakeEventArgs());
            }
        }
    }
}