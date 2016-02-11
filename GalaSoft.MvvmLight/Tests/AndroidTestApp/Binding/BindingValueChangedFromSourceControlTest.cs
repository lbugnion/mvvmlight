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
    public class BindingValueChangedFromSourceControlTest
    {
        private Helpers.Binding _binding;

#if ANDROID
        public EditText _source;
        private EditText _sourcePrivate;

        public EditText Source
        {
            get;
            private set;
        }

        private EditText SourcePrivate
        {
            get;
            set;
        }
#elif __IOS__
        public UITextViewEx _source;
        private UITextViewEx _sourcePrivate;

        public UITextViewEx Source
        {
            get;
            private set;
        }

        private UITextViewEx SourcePrivate
        {
            get;
            set;
        }
#endif

        public TestViewModel VmTarget
        {
            get;
            private set;
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPublicProperty_ValueChangedFires()
        {
#if ANDROID
            Source = new EditText(Application.Context);
#elif __IOS__
            Source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                Source,
                () => Source.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                Source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            Source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPrivateProperty_ValueChangedFires()
        {
#if ANDROID
            SourcePrivate = new EditText(Application.Context);
#elif __IOS__
            SourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                SourcePrivate,
                () => SourcePrivate.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                SourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            SourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPublicField_ValueChangedFires()
        {
#if ANDROID
            _source = new EditText(Application.Context);
#elif __IOS__
            _source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                _source,
                () => _source.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPrivateField_ValueChangedFires()
        {
#if ANDROID
            _sourcePrivate = new EditText(Application.Context);
#elif __IOS__
            _sourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                _sourcePrivate,
                () => _sourcePrivate.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _sourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _sourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithVar_ValueChangedFires()
        {
#if ANDROID
            var source = new EditText(Application.Context);
#elif __IOS__
            var source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                source,
                () => source.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPublicProperty_ValueChangedFires()
        {
#if ANDROID
            Source = new EditText(Application.Context);
#elif __IOS__
            Source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => Source.Text,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                Source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            Source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPrivateProperty_ValueChangedFires()
        {
#if ANDROID
            SourcePrivate = new EditText(Application.Context);
#elif __IOS__
            SourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => SourcePrivate.Text,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                SourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            SourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPublicField_ValueChangedFires()
        {
#if ANDROID
            _source = new EditText(Application.Context);
#elif __IOS__
            _source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => _source.Text,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPrivateField_ValueChangedFires()
        {
#if ANDROID
            _sourcePrivate = new EditText(Application.Context);
#elif __IOS__
            _sourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => _sourcePrivate.Text,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _sourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _sourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPublicPropertyAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            Source = new EditText(Application.Context);
#elif __IOS__
            Source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = new Binding<string, string>(
                Source,
                () => Source.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                Source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            Source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPrivatePropertyAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            SourcePrivate = new EditText(Application.Context);
#elif __IOS__
            SourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = new Binding<string, string>(
                SourcePrivate,
                () => SourcePrivate.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                SourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            SourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPublicFieldAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            _source = new EditText(Application.Context);
#elif __IOS__
            _source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = new Binding<string, string>(
                _source,
                () => _source.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithPrivateFieldAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            _sourcePrivate = new EditText(Application.Context);
#elif __IOS__
            _sourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = new Binding<string, string>(
                _sourcePrivate,
                () => _sourcePrivate.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _sourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _sourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_NewBindingWithVarAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            var source = new EditText(Application.Context);
#elif __IOS__
            var source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = new Binding<string, string>(
                source,
                () => source.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPublicPropertyAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            Source = new EditText(Application.Context);
#elif __IOS__
            Source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = this.SetBinding(
                () => Source.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                Source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            Source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPrivatePropertyAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            SourcePrivate = new EditText(Application.Context);
#elif __IOS__
            SourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = this.SetBinding(
                () => SourcePrivate.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                SourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            SourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPublicFieldAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            _source = new EditText(Application.Context);
#elif __IOS__
            _source = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = this.SetBinding(
                () => _source.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _source.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _source.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChangedControl_SetBindingWithPrivateFieldAndNoTarget_ValueChangedFires()
        {
#if ANDROID
            _sourcePrivate = new EditText(Application.Context);
#elif __IOS__
            _sourcePrivate = new UITextViewEx();
#endif

            var valueChangedFired = false;

            var bindingGeneric = this.SetBinding(
                () => _sourcePrivate.Text);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _sourcePrivate.Text,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _sourcePrivate.Text = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }
    }
}