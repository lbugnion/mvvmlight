using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using ProjectForTemplateSL.ViewModel;

namespace ProjectForTemplateSL
{
    public partial class Page : UserControl
    {
        public Page()
        {
            Messenger.Default.Register<DialogMessage>(this, HandleDialogMessage);
            InitializeComponent();
        }

        private static void HandleDialogMessage(DialogMessage message)
        {
            if (message == null)
            {
                return;
            }

            if (message.Sender.GetType() == typeof(MainViewModel)
                && message.Target == typeof(Page))
            {
                var result = MessageBox.Show(
                    message.Content,
                    message.Caption,
                    message.Button);

                if (message.Callback != null)
                {
                    message.Callback(result);
                }
            }
        }
    }
}