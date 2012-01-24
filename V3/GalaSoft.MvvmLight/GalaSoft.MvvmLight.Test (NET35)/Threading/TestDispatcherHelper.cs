using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;
using System.Threading;
using GalaSoft.MvvmLight.Threading;
using System.Windows;
using System.Windows.Threading;

namespace GalaSoft.MvvmLight.Test.Threading
{
    [TestClass]
    public class TestDispatcherHelper
    {
        private Button _button;

        [TestMethod]
        public void TestDispatchingToUiThread()
        {
            _button = new Button
            {
                Content = "Content1"
            };

            var manualEvent = new ManualResetEvent(false);

            var thread = new Thread(() =>
            {
                Thread.Sleep(500);
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    AccessMethodOnUiThread(NewContent);
                    manualEvent.Set();
                });
            });

            DispatcherHelper.Initialize();

            thread.Start();

            manualEvent.WaitOne(1000);

#if SILVERLIGHT
            // No way to verify that the button is correctly set
            // in WPF, however the mere fact that we didn't get an exception
            // is an indication of success.
            DispatcherHelper.UIDispatcher.BeginInvoke(VerifyButtonNewContent);
#endif
        }

        private void AccessMethodOnUiThread(string newContent)
        {
            _button.Content = newContent;
        }

        [TestMethod]
        public void TestDirectAccessToUiThread()
        {
            _button = new Button
            {
                Content = "Content1"
            };

            DispatcherHelper.Initialize();
            DispatcherHelper.CheckBeginInvokeOnUI(() => _button.Content = NewContent);

#if SILVERLIGHT
            // No way to verify that the button is correctly set
            // in WPF, however the mere fact that we didn't get an exception
            // is an indication of success.
            Assert.AreEqual(NewContent, _button.Content);
#endif
        }

        private const string NewContent = "New content";

        private void VerifyButtonNewContent()
        {
            Assert.AreEqual(NewContent, _button.Content);
        }
    }
}
