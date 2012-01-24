using System;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using $safeprojectname$.ViewModel;

namespace $safeprojectname$
{
    public partial class App : Application
    {

        public App()
        {
            Startup += this.ApplicationStartup;
            Exit += ApplicationExit;
            UnhandledException += this.ApplicationUnhandledException;

            InitializeComponent();
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            RootVisual = new MainPage();
            DispatcherHelper.Initialize();
        }

        private static void ApplicationExit(object sender, EventArgs e)
        {
            ViewModelLocator.Cleanup();
        }

        private void ApplicationUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(() => ReportErrorToDom(e));
            }
        }
        private static void ReportErrorToDom(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                var errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 2 Application " + errorMsg + "\");");
            }
            catch
            {
            }
        }
    }
}
