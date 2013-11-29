using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace ProjectForTemplates.Common
{
    public class DialogService : IDialogService
    {
        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            var dialog = new MessageDialog(message, title ?? string.Empty);

            dialog.Commands.Add(
                new UICommand(
                    buttonText,
                    c =>
                    {
                        if (afterHideCallback != null)
                        {
                            afterHideCallback();
                        }
                    }));

            dialog.CancelCommandIndex = 0;
            await dialog.ShowAsync();
        }

        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            await ShowError(error.Message, title ?? string.Empty, buttonText, afterHideCallback);
        }

        public async Task ShowMessage(string message, string title)
        {
            var dialog = new MessageDialog(message, title ?? string.Empty);
            await dialog.ShowAsync();
        }

        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            var dialog = new MessageDialog(message, title ?? string.Empty);
            dialog.Commands.Add(
                new UICommand(
                    buttonText,
                    c =>
                    {
                        if (afterHideCallback != null)
                        {
                            afterHideCallback();
                        }
                    }));
            dialog.CancelCommandIndex = 0;
            await dialog.ShowAsync();
        }

        public async Task ShowMessage(
            string message,
            string title,
            string buttonConfirmText,
            string buttonCancelText,
            Action<bool> afterHideCallback)
        {
            var dialog = new MessageDialog(message, title ?? string.Empty);
            dialog.Commands.Add(new UICommand(buttonConfirmText, c => afterHideCallback(true)));
            dialog.Commands.Add(new UICommand(buttonCancelText, c => afterHideCallback(false)));
            dialog.CancelCommandIndex = 1;
            await dialog.ShowAsync();
        }

        public async Task ShowMessageBox(string message, string title)
        {
            var dialog = new MessageDialog(message, title ?? string.Empty);
            await dialog.ShowAsync();
        }
    }
}