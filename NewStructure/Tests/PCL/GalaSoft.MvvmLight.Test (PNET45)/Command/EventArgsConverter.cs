using System;
using System.Globalization;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;

namespace GalaSoft.MvvmLight.Test.Command
{
    public class TestEventArgsConverter : IEventArgsConverter
    {
        public string TestPrefix
        {
            get;
            set;
        }

        public object Convert(object value, object parameter)
        {
            var args = (StringEventArgs)value;

            return TestPrefix 
                + args.Parameter
                + (parameter == null ? string.Empty : parameter.ToString());
        }
    }
}