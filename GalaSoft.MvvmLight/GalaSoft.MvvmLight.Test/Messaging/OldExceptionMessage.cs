using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldExceptionMessage<T> : GenericMessage<T> where T : Exception
    {
        public OldExceptionMessage(object sender, T exception)
            : base(sender, exception)
        {
        }
    }
}