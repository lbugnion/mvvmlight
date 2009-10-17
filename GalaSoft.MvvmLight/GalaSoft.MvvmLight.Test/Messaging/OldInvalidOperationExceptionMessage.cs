using System;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldInvalidOperationExceptionMessage : OldExceptionMessage<InvalidOperationException>
    {
        public OldInvalidOperationExceptionMessage(object sender, InvalidOperationException ex)
            : base(sender, ex)
        {
        }
    }
}