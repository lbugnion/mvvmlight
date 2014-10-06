using System;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Test.Command
{
    public class EventToCommandStub : EventToCommand
    {
        public void InvokeWithEventArgs(EventArgs args)
        {
            base.Invoke(args);
        }
    }
}