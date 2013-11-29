using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;

namespace $safeprojectname$.Common
{
    public class OrientationStateBehavior : OrientationStateControlBehavior
    {
        /// <summary>
        /// The <see cref="SnapViewMaximumWidth" /> dependency property's name.
        /// </summary>
        public const string SnapViewMaximumWidthPropertyName = "SnapViewMaximumWidth";

        /// <summary>
        /// Identifies the <see cref="SnapViewMaximumWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SnapViewMaximumWidthProperty = DependencyProperty.Register(
            SnapViewMaximumWidthPropertyName,
            typeof (double),
            typeof (OrientationStateBehavior),
            new PropertyMetadata(500.0));

        private Page _associatedPage;

        /// <summary>
        /// Gets or sets the value of the <see cref="SnapViewMaximumWidth" />
        /// property. This is a dependency property.
        /// </summary>
        public double SnapViewMaximumWidth
        {
            get
            {
                return (double)GetValue(SnapViewMaximumWidthProperty);
            }
            set
            {
                SetValue(SnapViewMaximumWidthProperty, value);
            }
        }

        public override void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            _associatedPage = AssociatedObject as Page;

            if (_associatedPage == null)
            {
                throw new InvalidOperationException(
                    "OrientationStateBehavior can only be attached to a Page.");
            }

            _associatedPage.Loaded += AssociatedPageLoaded;
        }

        public override void Detach()
        {
            if (_associatedPage != null)
            {
                _associatedPage.SizeChanged -= PageBaseSizeChanged;
                DisplayInformation.GetForCurrentView().OrientationChanged -= PageBaseOrientationChanged;
            }
        }

        protected override void SendMessage(PageOrientations orientation)
        {
            Messenger.Default.Send(new OrientationStateMessage(orientation));
        }

        private void AssociatedPageLoaded(object sender, RoutedEventArgs e)
        {
            _associatedPage.Loaded -= AssociatedPageLoaded;
            _associatedPage.SizeChanged += PageBaseSizeChanged;
            DisplayInformation.GetForCurrentView().OrientationChanged += PageBaseOrientationChanged;
            DispatcherHelper.RunAsync(CheckOrientationForPage);
        }

        private void CheckOrientationForPage()
        {
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                if (_associatedPage.ActualWidth < SnapViewMaximumWidth)
                {
                    if (DisplayInformation.GetForCurrentView().CurrentOrientation != DisplayOrientations.Portrait
                        && DisplayInformation.GetForCurrentView().CurrentOrientation
                        != DisplayOrientations.PortraitFlipped)
                    {
                        HandleOrientation(PageOrientations.Snap);
                    }
                }
                else
                {
                    HandleOrientation(DisplayInformation.GetForCurrentView().CurrentOrientation.GetPageOrientation());
                }
            }
        }

        private void PageBaseOrientationChanged(DisplayInformation sender, object args)
        {
            CheckOrientationForPage();
        }

        private void PageBaseSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                CheckOrientationForPage();
            }
        }
    }
}