using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldTestMessage : MessageBase
    {
        public OldTestMessage(object sender, string content)
            : base(sender)
        {
            Content = content;
        }

        public string Content
        {
            get;
            private set;
        }
    }
}