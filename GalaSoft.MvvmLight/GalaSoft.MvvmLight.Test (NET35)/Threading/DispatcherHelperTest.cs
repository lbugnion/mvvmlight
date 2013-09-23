using System;
using System.Threading;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Threading
{
    [TestClass]
    public class DispatcherHelperTest
    {
        private const string NewContent = "New content";
        private Button _button;

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

        [TestMethod]
        public void TestDispatchingToUiThread()
        {
            _button = new Button
            {
                Content = "Content1"
            };

            var manualEvent = new ManualResetEvent(false);

            var thread = new Thread(
                () =>
                {
                    Thread.Sleep(500);
                    DispatcherHelper.CheckBeginInvokeOnUI(
                        () =>
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

        [TestMethod]
        public void TestFailingInitializationInCheckBeginInvokeOnUi()
        {
            DispatcherHelper.Reset();
            var done = false;
            Exception receivedException = null;

            try
            {
                DispatcherHelper.CheckBeginInvokeOnUI(
                    () =>
                    {
                        done = true;
                    });
            }
            catch (Exception ex)
            {
                receivedException = ex;
            }

            CheckException(receivedException);
            Assert.IsFalse(done);
        }

        [TestMethod]
        public void TestFailingInitializationInRunAsync()
        {
            DispatcherHelper.Reset();
            var done = false;
            Exception receivedException = null;

            try
            {
                DispatcherHelper.RunAsync(
                    () =>
                    {
                        done = true;
                    });
            }
            catch (Exception ex)
            {
                receivedException = ex;
            }

            CheckException(receivedException);
            Assert.IsFalse(done);
        }

        private void AccessMethodOnUiThread(string newContent)
        {
            _button.Content = newContent;
        }

        private void CheckException(Exception receivedException)
        {
            Assert.IsNotNull(receivedException);
            Assert.AreEqual(typeof (InvalidOperationException), receivedException.GetType());

#if SILVERLIGHT
#if WINDOWS_PHONE
            Assert.IsTrue(receivedException.Message.Contains("Call DispatcherHelper.Initialize() at the end of App.InitializePhoneApplication."));
#else
            Assert.IsTrue(receivedException.Message.Contains("Call DispatcherHelper.Initialize() in Application_Startup (App.xaml.cs)."));
#endif
#elif NETFX_CORE
            Assert.IsTrue(receivedException.Message.Contains("Call DispatcherHelper.Initialize() at the end of App.OnLaunched."));
#else
            Assert.IsTrue(
                receivedException.Message.Contains("Call DispatcherHelper.Initialize() in the static App constructor."));
#endif
        }

        private void VerifyButtonNewContent()
        {
            Assert.AreEqual(NewContent, _button.Content);
        }
    }
}