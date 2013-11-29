using System;
using System.Threading.Tasks;

namespace $safeprojectname$.Common
{
    public interface IDialogService
    {
        Task ShowError(
            string message,
            string title,
            string buttonText,
            Action afterHideCallback);

        Task ShowError(
            Exception error,
            string title,
            string buttonText,
            Action afterHideCallback);

        Task ShowMessage(
            string message,
            string title);

        Task ShowMessage(
            string message,
            string title,
            string buttonText,
            Action afterHideCallback);

        Task ShowMessage(
            string message,
            string title,
            string buttonConfirmText,
            string buttonCancelText,
            Action<bool> afterHideCallback);

        Task ShowMessageBox(
            string message,
            string title);
    }
}