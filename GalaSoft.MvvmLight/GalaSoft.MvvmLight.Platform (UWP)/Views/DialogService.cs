// ****************************************************************************
// <copyright file="DialogService.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>02.10.2014</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace GalaSoft.MvvmLight.Views
{
    /// <summary>
    /// An implementation of <see cref="IDialogService"/> allowing
    /// to display simple dialogs to the user. Note that this class
    /// uses the built in Android dialogs which may or may not
    /// be sufficient for your needs. Using this class is easy
    /// but feel free to develop your own IDialogService implementation
    /// if needed.
    /// </summary>
    ////[ClassInfo(typeof(IDialogService))]
    public class DialogService : IDialogService
    {
        /// <summary>
        /// Displays information about an error.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            var dialog = CreateDialog(message, title, buttonText, null, afterHideCallback);
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Displays information about an error.
        /// </summary>
        /// <param name="error">The exception of which the message must be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            var dialog = CreateDialog(error.Message, title, buttonText, null, afterHideCallback);
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button with the text "OK".
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        public async Task ShowMessage(string message, string title)
        {
            var dialog = CreateDialog(message, title);
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            var dialog = CreateDialog(message, title, buttonText, null, afterHideCallback);
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonConfirmText">The text shown in the "confirm" button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="buttonCancelText">The text shown in the "cancel" button
        /// in the dialog box. If left null, the text "Cancel" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user. The callback method will get a boolean
        /// parameter indicating if the "confirm" button (true) or the "cancel" button
        /// (false) was pressed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        public async Task<bool> ShowMessage(
            string message,
            string title,
            string buttonConfirmText,
            string buttonCancelText,
            Action<bool> afterHideCallback)
        {
            var result = false;

            var dialog = CreateDialog(
                message, 
                title, 
                buttonConfirmText, 
                buttonCancelText,
                null, 
                afterHideCallback,
                r => result = r);

            await dialog.ShowAsync();
            return result;
        }

        /// <summary>
        /// Displays information to the user in a simple dialog box. The dialog box will have only
        /// one button with the text "OK". This method should be used for debugging purposes.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        public async Task ShowMessageBox(string message, string title)
        {
            var dialog = CreateDialog(message, title);
            await dialog.ShowAsync();
        }

        private MessageDialog CreateDialog(
            string message,
            string title,
            string buttonConfirmText = "OK",
            string buttonCancelText = null,
            Action afterHideCallback = null,
            Action<bool> afterHideCallbackWithResponse = null,
            Action<bool> afterHideInternal = null)
        {
            var dialog = new MessageDialog(message, title);

            dialog.Commands.Add(
                new UICommand(
                    buttonConfirmText,
                    o =>
                    {
                        if (afterHideCallback != null)
                        {
                            afterHideCallback();
                        }

                        if (afterHideCallbackWithResponse != null)
                        {
                            afterHideCallbackWithResponse(true);
                        }

                        if (afterHideInternal != null)
                        {
                            afterHideInternal(true);
                        }
                    }));

            dialog.DefaultCommandIndex = 0;

            if (!string.IsNullOrEmpty(buttonCancelText))
            {
                dialog.Commands.Add(
                    new UICommand(
                        buttonCancelText,
                        o =>
                        {
                            if (afterHideCallback != null)
                            {
                                afterHideCallback();
                            }

                            if (afterHideCallbackWithResponse != null)
                            {
                                afterHideCallbackWithResponse(false);
                            }

                            if (afterHideInternal != null)
                            {
                                afterHideInternal(false);
                            }
                        }));

                dialog.CancelCommandIndex = 1;
            }

            return dialog;
        }
    }
}