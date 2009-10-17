using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using ProjectForTemplate.ViewModel;

namespace ProjectForTemplate
{
    /// <summary>
    /// This application's main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            Messenger.Default.Register<DialogMessage>(this, HandleDialogMessage);

            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Dispose();
        }

        private void HandleDialogMessage(DialogMessage message)
        {
            if (message == null)
            {
                return;
            }

            if (message.Sender.GetType() == typeof(MainViewModel)
                && message.Target == typeof(MainWindow))
            {
                var result = MessageBox.Show(
                    this,
                    message.Content,
                    message.Caption,
                    message.Button,
                    message.Icon,
                    message.DefaultResult,
                    message.Options);

                if (message.Callback != null)
                {
                    message.Callback(result);
                }
            }
        }
    }
}