using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Test.ViewModel;
using GalaSoft.MvvmLight.Helpers;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingDeepPathHybridTest
    {
        private Helpers.Binding _binding1;
        private Helpers.Binding _binding2;

        public TestViewModel Vm1
        {
            get;
            private set;
        }

        public TestViewModel Vm2
        {
            get;
            private set;
        }

#if ANDROID
        public EditText TargetText1
        {
            get;
            private set;
        }

        public EditText TargetText2
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextView TargetText1
        {
            get;
            private set;
        }

        public UITextView TargetText2
        {
            get;
            private set;
        }
#endif

        [Test]
        public void BindingDeepPathHybrid_FallbackValueIsCastProperly()
        {
            Vm1 = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Model = new TestModel()
                }
            };

            Vm2 = new TestViewModel(); // Nested remains null

#if ANDROID
            TargetText1 = new EditText(Application.Context);
            TargetText2 = new EditText(Application.Context);
#elif __IOS__
            TargetText1 = new UITextView();
            TargetText2 = new UITextView();
#endif

            _binding1 = this.SetBinding(
                () => Vm1.Nested.Model.DoubleProperty,
                () => TargetText1.Text);

            Assert.AreEqual(Vm1.Nested.Model.DoubleProperty.ToString(), TargetText1.Text);
            Vm1.Nested.Model.DoubleProperty = 5.0;
            Assert.AreEqual(Vm1.Nested.Model.DoubleProperty.ToString(), TargetText1.Text);

            _binding2 = this.SetBinding(
                () => Vm2.Nested.Model.DoubleProperty,
                () => TargetText2.Text);

            Assert.AreEqual("0", TargetText2.Text);

            Vm2.Nested = new TestViewModel
            {
                Model = new TestModel
                {
                    DoubleProperty = 9.0
                }
            };

            Assert.AreEqual(Vm2.Nested.Model.DoubleProperty.ToString(), TargetText2.Text);
            Vm2.Nested.Model.DoubleProperty = 5.0;
            Assert.AreEqual(Vm2.Nested.Model.DoubleProperty.ToString(), TargetText2.Text);
        }
    }
}