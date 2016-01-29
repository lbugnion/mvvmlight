using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.Controls;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

#if ANDROID
using Android.App;
using Android.Widget;
#elif __IOS__
#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingTargetControlTest
    {
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
        public void BindingTargetControl_NewBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                Target,
                () => Target.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, Target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, Target.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivateProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                TargetPrivate,
                () => TargetPrivate.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, TargetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, TargetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                _target,
                () => _target.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, _target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _target.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivateField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                _targetPrivate,
                () => _targetPrivate.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, _targetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _targetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithVar_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            var target = new EditText(Application.Context);
#elif __IOS__
            var target = new UITextViewEx();
#endif

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                target,
                () => target.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, target.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => Target.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, Target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, Target.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivateProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => TargetPrivate.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, TargetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, TargetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _target.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, _target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _target.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivateField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _targetPrivate.Text);

            Assert.AreEqual(VmSource.Model.MyProperty, _targetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _targetPrivate.Text);
        }
    }
}