using Android.Widget;
using GalaSoft.MvvmLight.Views;

namespace $safeprojectname$
{
    // In this partial Activity, we provide access to the UI elements.
    // This file is partial to keep things cleaner in the MainActivity.cs
    // See http://blog.galasoft.ch/posts/2014/11/structuring-your-android-activities/
    public partial class MainActivity : ActivityBase
    {
        private TextView _welcomeText;

        public TextView WelcomeText
        {
            get
            {
                return _welcomeText
                       ?? (_welcomeText = FindViewById<TextView>(Resource.Id.WelcomeText));
            }
        }

        private Button _incrementButton;

        public Button IncrementButton
        {
            get
            {
                return _incrementButton
                       ?? (_incrementButton = FindViewById<Button>(Resource.Id.IncrementButton));
            }
        }

        private TextView _tapText;

        public TextView TapText
        {
            get
            {
                return _tapText
                       ?? (_tapText = FindViewById<TextView>(Resource.Id.TapText));
            }
        }

        private Button _showDialogButton;

        public Button ShowDialogButton
        {
            get
            {
                return _showDialogButton
                       ?? (_showDialogButton = FindViewById<Button>(Resource.Id.ShowDialogButton));
            }
        }

        private EditText _dialogNavText;

        public EditText DialogNavText
        {
            get
            {
                return _dialogNavText
                       ?? (_dialogNavText = FindViewById<EditText>(Resource.Id.DialogNavText));
            }
        }

        private TextView _clockText;

        public TextView ClockText
        {
            get
            {
                return _clockText
                       ?? (_clockText = FindViewById<TextView>(Resource.Id.ClockText));
            }
        }

        private Button _sendMessageButton;

        public Button SendMessageButton
        {
            get
            {
                return _sendMessageButton
                       ?? (_sendMessageButton = FindViewById<Button>(Resource.Id.SendMessageButton));
            }
        }
    }
}