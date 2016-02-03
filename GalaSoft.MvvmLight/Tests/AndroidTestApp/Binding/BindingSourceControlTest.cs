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
    public class BindingSourceControlTest
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
        public void BindingSourceControl_NewBindingWithPublicProperty_NoError()
        {
#if ANDROID
            Source = new EditText(Application.Context);
#elif __IOS__
            Source = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                Source,
                () => Source.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(Source.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            Source.Text = newValue;
            Assert.AreEqual(Source.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_NewBindingWithPrivateProperty_NoError()
        {
#if ANDROID
            SourcePrivate = new EditText(Application.Context);
#elif __IOS__
            SourcePrivate = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                SourcePrivate,
                () => SourcePrivate.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(SourcePrivate.Text, VmTarget.TargetProperty);
            var newValue2 = DateTime.Now.Ticks.ToString();
            SourcePrivate.Text = newValue2;
            Assert.AreEqual(SourcePrivate.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_NewBindingWithPublicField_NoError()
        {
#if ANDROID
            _source = new EditText(Application.Context);
#elif __IOS__
            _source = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                _source,
                () => _source.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_source.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _source.Text = newValue;
            Assert.AreEqual(_source.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_NewBindingWithPrivateField_NoError()
        {
#if ANDROID
            _sourcePrivate = new EditText(Application.Context);
#elif __IOS__
            _sourcePrivate = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                _sourcePrivate,
                () => _sourcePrivate.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_sourcePrivate.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _sourcePrivate.Text = newValue;
            Assert.AreEqual(_sourcePrivate.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_NewBindingWithVar_NoError()
        {
#if ANDROID
            var source = new EditText(Application.Context);
#elif __IOS__
            var source = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                source,
                () => source.Text,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(source.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            source.Text = newValue;
            Assert.AreEqual(source.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_SetBindingWithPublicProperty_NoError()
        {
#if ANDROID
            Source = new EditText(Application.Context);
#elif __IOS__
            Source = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => Source.Text,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(Source.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            Source.Text = newValue;
            Assert.AreEqual(Source.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_SetBindingWithPrivateProperty_NoError()
        {
#if ANDROID
            SourcePrivate = new EditText(Application.Context);
#elif __IOS__
            SourcePrivate = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => SourcePrivate.Text,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(SourcePrivate.Text, VmTarget.TargetProperty);
            var newValue2 = DateTime.Now.Ticks.ToString();
            SourcePrivate.Text = newValue2;
            Assert.AreEqual(SourcePrivate.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_SetBindingWithPublicField_NoError()
        {
#if ANDROID
            _source = new EditText(Application.Context);
#elif __IOS__
            _source = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => _source.Text,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_source.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _source.Text = newValue;
            Assert.AreEqual(_source.Text, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSourceControl_SetBindingWithPrivateField_NoError()
        {
#if ANDROID
            _sourcePrivate = new EditText(Application.Context);
#elif __IOS__
            _sourcePrivate = new UITextViewEx();
#endif

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => _sourcePrivate.Text,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_sourcePrivate.Text, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _sourcePrivate.Text = newValue;
            Assert.AreEqual(_sourcePrivate.Text, VmTarget.TargetProperty);
        }
    }
}