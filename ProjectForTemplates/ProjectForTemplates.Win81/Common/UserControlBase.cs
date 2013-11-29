using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;

namespace ProjectForTemplates.Common
{
    public abstract class UserControlBase : UserControl
    {
        public abstract double SnapViewMaximumWidth
        {
            get;
        }

        public UserControlBase()
        {
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                Loaded += UserControlBaseLoaded;
            }
        }

        private void CheckOrientation()
        {
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                if (ActualWidth < SnapViewMaximumWidth)
                {
                    if (DisplayInformation.GetForCurrentView().CurrentOrientation != DisplayOrientations.Portrait
                        && DisplayInformation.GetForCurrentView().CurrentOrientation
                        != DisplayOrientations.PortraitFlipped)
                    {
                        VisualStateManager.GoToState(this, "OrientationSnap", true);
                    }
                }
                else
                {
                    switch (DisplayInformation.GetForCurrentView().CurrentOrientation)
                    {
                        case DisplayOrientations.Portrait:
                        case DisplayOrientations.PortraitFlipped:
                            VisualStateManager.GoToState(this, "OrientationPortrait", true);
                            break;

                        default:
                            VisualStateManager.GoToState(this, "OrientationLandscape", true);
                            break;
                    }
                }
            }
        }

        private void UserControlBaseLoaded(object sender, RoutedEventArgs e)
        {
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                SizeChanged += UserControlBaseSizeChanged;
                DisplayInformation.GetForCurrentView().OrientationChanged += UserControlBaseOrientationChanged;
                DispatcherHelper.RunAsync(CheckOrientation);
            }
        }

        private void UserControlBaseOrientationChanged(DisplayInformation sender, object args)
        {
            CheckOrientation();
        }

        private void UserControlBaseSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                CheckOrientation();
            }
        }
    }
}