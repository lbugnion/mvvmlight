using System;

namespace GalaSoft.MvvmLight.Test.Command
{
    public class StringEventArgs : EventArgs
    {
        public string Parameter
        {
            get;
            private set;
        }

        public StringEventArgs(string parameter)
        {
            Parameter = parameter;
        }

        public override string ToString()
        {
            return Parameter;
        }
    }
}