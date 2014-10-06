using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Views;
using Microsoft.Phone.Controls;
using Microsoft.Practices.ServiceLocation;

namespace Flowers.Helpers
{
    public class PhonePageBase : PhoneApplicationPage
    {
        public IDialogService Dialog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDialogService>();
            }
        }

        public NavigationService GlobalNavigation
        {
            get
            {
                return (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            }
        }

        public void UpdateCurrentBinding()
        {
            var currentTextBox = FocusManager.GetFocusedElement() as TextBox;

            if (currentTextBox != null)
            {
                var currentBinding = currentTextBox.GetBindingExpression(TextBox.TextProperty);
                if (currentBinding != null)
                {
                    currentBinding.UpdateSource();
                }
            }
        }
    }
}