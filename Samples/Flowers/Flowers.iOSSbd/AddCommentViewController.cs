using System;
using Flowers.Data.ViewModel;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace Flowers.iOSSbd
{
    partial class AddCommentViewController : ControllerBase
    {
        private Binding _commentBinding;

        public UIBarButtonItem SaveCommentButton
        {
            get;
            private set;
        }

        public FlowerViewModel Vm
        {
            get;
            private set;
        }

        public AddCommentViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            if (NavigationParameter == null)
            {
                throw new InvalidOperationException("No parameter found after navigation");
            }

            Vm = (FlowerViewModel)NavigationParameter;

            SaveCommentButton = new UIBarButtonItem(UIBarButtonSystemItem.Save, null);
            NavigationItem.SetRightBarButtonItem(SaveCommentButton, false);

            _commentBinding = this.SetBinding(
                () => CommentText.Text)
                .UpdateSourceTrigger("Changed");

            SaveCommentButton.SetCommand(
                "Clicked",
                Vm.SaveCommentCommand,
                _commentBinding);

            base.ViewDidLoad();
        }
    }
}