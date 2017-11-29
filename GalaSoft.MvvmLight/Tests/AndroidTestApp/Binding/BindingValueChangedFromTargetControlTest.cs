using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;
#if ANDROID
using Android.App;
using Android.Widget;

#elif __IOS__
using GalaSoft.MvvmLight.Test.Controls;

#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingValueChangedFromTargetControlTest
    {
        private Helpers.Binding _binding;

#if ANDROID
        public EditText _target;
        private EditText _targetPrivate;

        private EditText TargetPrivate
        {
            get;
            set;
        }

        public EditText Target
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextViewEx _target;
        private UITextViewEx _targetPrivate;

        public UITextViewEx Target
        {
            get;
            private set;
        }

        private UITextViewEx TargetPrivate
        {
            get;
            set;
        }
#endif

        public TestViewModel VmSource
        {
            get;
            private set;
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicPropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                Target,
                () => Target.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            Target.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivatePropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                TargetPrivate,
                () => TargetPrivate.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            TargetPrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _target,
                () => _target.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            _target.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivateFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _targetPrivate,
                () => _targetPrivate.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            _targetPrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithVarTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            var target = new EditText(Application.Context);
#elif __IOS__
            var target = new UITextViewEx();
#endif

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                target,
                () => target.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            target.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicPropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => Target.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            Target.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivatePropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => TargetPrivate.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            TargetPrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _target.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            _target.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivateFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _targetPrivate.Text,
                BindingMode.TwoWay);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.StringProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);

            valueChangedFired = false;

            newValue += "Suffix";
            _targetPrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }
    }
}