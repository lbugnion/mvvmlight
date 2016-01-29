using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

#if ANDROID
using Android.App;
using Android.Widget;
#elif __IOS__
using UIKit;
#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    public class BindingAccountTest
    {
        private Binding<string, string> _binding1;
        private Binding<string, string> _binding2;

        public AccountViewModel Vm
        {
            get;
            private set;
        }

#if ANDROID
        public EditText Operation
        {
            get;
            private set;
        }

        public EditText ChildName
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextView Operation
        {
            get;
            private set;
        }

        public UITextView ChildName
        {
            get;
            private set;
        }
#endif

        [Test]
        public void Binding_Test1_Error()
        {
            Vm = new AccountViewModel();

#if ANDROID
            Operation = new EditText(Application.Context);
            ChildName = new EditText(Application.Context);
#elif __IOS__
            Operation = new UITextView();
            ChildName = new UITextView();
#endif

            _binding1 = this.SetBinding(
                () => Vm.FormattedOperation,
                () => Operation.Text);

            _binding2 = this.SetBinding(
                () => Vm.AccountDetails.Name,
                () => ChildName.Text,
                fallbackValue: "Fallback",
                targetNullValue: "TargetNull");

            Assert.AreEqual(AccountViewModel.EmptyText, Operation.Text);
            Assert.AreEqual(_binding2.FallbackValue, ChildName.Text);

            Vm.SetAccount();

            Assert.AreEqual(
                AccountViewModel.NotEmptyText + Vm.AccountDetails.Balance + Vm.Amount,
                Operation.Text);
            Assert.AreEqual(Vm.AccountDetails.Name, ChildName.Text);
        }

        [Test]
        public void Binding_Test2_Works()
        {
            Vm = new AccountViewModel();

#if ANDROID
            Operation = new EditText(Application.Context);
            ChildName = new EditText(Application.Context);
#elif __IOS__
            Operation = new UITextView();
            ChildName = new UITextView();
#endif

            _binding1 = this.SetBinding(
                () => Vm.FormattedOperation,
                () => Operation.Text);

            _binding2 = this.SetBinding(
                () => Vm.AccountDetailsName,
                () => ChildName.Text,
                fallbackValue: "Fallback",
                targetNullValue: "TargetNull");

            Assert.AreEqual(AccountViewModel.EmptyText, Operation.Text);
            Assert.AreEqual(AccountViewModel.EmptyText, ChildName.Text);

            Vm.SetAccount();

            Assert.AreEqual(
                AccountViewModel.NotEmptyText + Vm.AccountDetails.Balance + Vm.Amount,
                Operation.Text);
            Assert.AreEqual(Vm.AccountDetails.Name, ChildName.Text);
        }
    }
}