using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using $safeprojectname$.ViewModel;
using UIKit;

namespace $safeprojectname$
{
	partial class MainViewController : UIViewController
	{
        // Keep track of bindings to avoid premature garbage collection
        private readonly List<Binding> _bindings = new List<Binding>();

        /// <summary>
        /// Gets a reference to the MainViewModel from the ViewModelLocator.
        /// </summary>
	    private MainViewModel Vm
	    {
	        get
	        {
                return Application.Locator.Main;
	        }
	    }

		public MainViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Dismiss the keyboard
            DialogNavText.ShouldReturn += t =>
            {
                t.ResignFirstResponder();
                return true;
            };

            // Binding and commanding

            // Binding between the first UILabel and the WelcomeTitle property on the VM.
            // Keep track of the binding to avoid premature garbage collection
            _bindings.Add(
                this.SetBinding(
                    () => Vm.WelcomeTitle,
                    () => WelcomeText.Text));

            // Actuate the IncrementCommand on the VM.
            IncrementButton.SetCommand(
                "TouchUpInside",
                Vm.IncrementCommand);

            // Create a binding that fires every time that the EditingChanged event is called
            var dialogNavBinding = this.SetBinding(
                () => DialogNavText.Text)
                .UpdateSourceTrigger("EditingChanged");
            
            // Keep track of the binding to avoid premature garbage collection
            _bindings.Add(dialogNavBinding);

            // Actuate the NavigateCommand on the VM.
            // This command needs a CommandParameter of type string.
            // This is what the dialogNavBinding provides.
            NavigateButton.SetCommand(
                "TouchUpInside",
                Vm.NavigateCommand,
                dialogNavBinding);

            // Actuate the ShowDialogCommand on the VM.
            // This command needs a CommandParameter of type string.
            // This is what the dialogNavBinding provides.
            // This button will be disabled when the content of DialogNavText
            // is empty (see ShowDialogCommand on the MainViewModel class).
            ShowDialogButton.SetCommand(
                "TouchUpInside",
                Vm.ShowDialogCommand,
                dialogNavBinding);

            // Create a binding between the Clock property of the VM
            // and the ClockText UILabel.
            // Keep track of the binding to avoid premature garbage collection
            _bindings.Add(
                this.SetBinding(
                    () => Vm.Clock,
                    () => ClockText.Text));

            // Actuate the SendMessageCommand on the VM.
            SendMessageButton.SetCommand(
                "TouchUpInside",
                Vm.SendMessageCommand);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Start the clock background thread on the MainViewModel.
            Vm.StartClock();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            // Stop the clock background thread on the MainViewModel.
            Vm.StopClock();
        }
	}
}
