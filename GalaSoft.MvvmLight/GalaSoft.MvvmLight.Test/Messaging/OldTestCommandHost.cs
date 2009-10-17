using System;
using GalaSoft.MvvmLight.Messaging;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    public class OldTestCommandHost
    {
        public const string SaveCommand = "APPLICATIONCOMMANDS_SAVE";

        public OldTestCommandHost()
        {
            LastSaved = DateTime.Now - TimeSpan.FromDays(1);
        }

        public DateTime LastSaved
        {
            get;
            private set;
        }

        public void Save()
        {
            LastSaved = DateTime.Now;
            Messenger.Default.Broadcast(new CommandMessage<DateTime>(this, LastSaved, SaveCommand));
        }
    }
}