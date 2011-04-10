using System.Windows;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestBindingTarget : DependencyObject
    {
        /// <summary>
        /// The <see cref="MyTargetProperty" /> dependency property's name.
        /// </summary>
        public const string MyTargetPropertyPropertyName = "MyTargetProperty";

        /// <summary>
        /// Gets or sets the value of the <see cref="MyTargetProperty" />
        /// property. This is a dependency property.
        /// </summary>
        public bool MyTargetProperty
        {
            get
            {
                return (bool)GetValue(MyTargetPropertyProperty);
            }
            set
            {
                SetValue(MyTargetPropertyProperty, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="MyTargetProperty" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty MyTargetPropertyProperty = DependencyProperty.Register(
            MyTargetPropertyPropertyName,
            typeof(bool),
            typeof(TestBindingTarget),
            new PropertyMetadata(false));
    }
}