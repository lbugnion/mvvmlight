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
using UIKit;

#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingTest
    {
        private Helpers.Binding _binding;

        public TestViewModel VmSource
        {
            get;
            private set;
        }

        public TestViewModel VmTarget
        {
            get;
            private set;
        }

        [Test]
        public void Binding_DifferentTypeFallbackValue_ShouldGetConvertedWithoutError()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    DoubleProperty = 5.0
                }
            };

            var vmTarget = new TestViewModel
            {
                Model = new TestModel()
            };

            const double fallbackValue = 9.0;

            _binding = new Binding<double, string>(
                vmSource,
                () => vmSource.Model.DoubleProperty,
                vmTarget,
                () => vmTarget.Model.StringProperty);

            Assert.AreEqual(vmSource.Model.DoubleProperty.ToString(), vmTarget.Model.StringProperty);

            _binding = new Binding<double, string>(
                vmSource,
                () => vmSource.Model.DoubleProperty,
                vmTarget,
                () => vmTarget.Model.StringProperty,
                fallbackValue: fallbackValue);

            Assert.AreEqual(vmSource.Model.DoubleProperty.ToString(), vmTarget.Model.StringProperty);
            vmSource.Model = null;
            Assert.AreEqual(fallbackValue.ToString(), vmTarget.Model.StringProperty);
        }

        [Test]
        public void Binding_ConverterWithFallbackValue_ErrorInConverterShouldUseFallbackValue()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            var vmTarget = new TestViewModel();

            const string fallbackValue = "Fallback value";
            const string targetNullValue = "Target null value";

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty,
                BindingMode.Default,
                fallbackValue,
                targetNullValue)
                .ConvertSourceToTarget(
                    value =>
                    {
                        throw new InvalidCastException("Only for test");
                    });

            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);

            vmSource.Model.StringProperty = "New value";

            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);
        }

        [Test]
        public void Binding_MultipleLevelsOfNull_ShouldUseFallbackValueThenTargetNullValue()
        {
            var vmSource = new TestViewModel();
            var vmTarget = new TestViewModel();

            const string fallbackValue = "Fallback value";
            const string targetNullValue = "Target null value";

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Nested.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty,
                BindingMode.Default,
                fallbackValue,
                targetNullValue);

            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);
            vmSource.Nested = new TestViewModel();
            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);
            vmSource.Nested.Model = new TestModel();
            Assert.AreEqual(targetNullValue, vmTarget.TargetProperty);
            vmSource.Nested.Model.StringProperty = DateTime.Now.Ticks.ToString();
            Assert.AreEqual(vmSource.Nested.Model.StringProperty, vmTarget.TargetProperty);
        }

        [Test]
        public void
            Binding_MultipleLevelsOfNullWithConverter_ShouldCallConverterWithNullThenTargetNullValueButNotFallbackValue(
            
            )
        {
            var vmSource = new TestViewModel();
            var vmTarget = new TestViewModel();

            const string fallbackValue = "Fallback value";
            const string targetNullValue = "Target null value";
            const string suffix = "Suffix";
            var converterWasCalledWithNull = 0;
            var converterWasCalledWithTargetNullValue = 0;
            var converterWasCalledWithFallbackValue = 0;

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Nested.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty,
                BindingMode.Default,
                fallbackValue,
                targetNullValue)
                .ConvertSourceToTarget(
                    v =>
                    {
                        if (v == null)
                        {
                            converterWasCalledWithNull++;
                            return null;
                        }

                        switch (v)
                        {
                            case fallbackValue:
                                converterWasCalledWithFallbackValue++;
                                break;

                            case targetNullValue:
                                converterWasCalledWithTargetNullValue++;
                                break;
                        }

                        return v + suffix;
                    });

            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);
            Assert.AreEqual(0, converterWasCalledWithNull);
            Assert.AreEqual(0, converterWasCalledWithFallbackValue);
            Assert.AreEqual(0, converterWasCalledWithTargetNullValue);

            vmSource.Nested = new TestViewModel();
            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);
            Assert.AreEqual(0, converterWasCalledWithNull);
            Assert.AreEqual(0, converterWasCalledWithFallbackValue);
            Assert.AreEqual(0, converterWasCalledWithTargetNullValue);

            vmSource.Nested.Model = new TestModel();
            Assert.AreEqual(targetNullValue + suffix, vmTarget.TargetProperty);
            Assert.AreEqual(1, converterWasCalledWithNull);
            Assert.AreEqual(0, converterWasCalledWithFallbackValue);
            Assert.AreEqual(1, converterWasCalledWithTargetNullValue);

            vmSource.Nested.Model.StringProperty = DateTime.Now.Ticks.ToString();
            Assert.AreEqual(vmSource.Nested.Model.StringProperty + suffix, vmTarget.TargetProperty);
            Assert.AreEqual(1, converterWasCalledWithNull);
            Assert.AreEqual(0, converterWasCalledWithFallbackValue);
            Assert.AreEqual(1, converterWasCalledWithTargetNullValue);
        }

        [Test]
        public void Binding_NoErrors_ShouldUpdateTargetValue()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Hello world"
                }
            };

            var vmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty);

            Assert.AreEqual(vmSource.Model.StringProperty, vmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            vmSource.Model.StringProperty = newValue;
            Assert.AreEqual(vmSource.Model.StringProperty, vmTarget.TargetProperty);
        }

        [Test]
        public void Binding_NullSourceProperty_ShouldUseTargetNullValue()
        {
            var vmSource = new TestViewModel()
            {
                Model = new TestModel()
            };

            var vmTarget = new TestViewModel();

            const string fallbackValue = "Fallback value";
            const string targetNullValue = "Target null value";

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty,
                BindingMode.Default,
                fallbackValue,
                targetNullValue);

            Assert.AreEqual(targetNullValue, vmTarget.TargetProperty);
            vmSource.Model.StringProperty = DateTime.Now.Ticks.ToString();
            Assert.AreEqual(vmSource.Model.StringProperty, vmTarget.TargetProperty);
        }

        [Test]
        public void Binding_ObjectCreation_ShouldAttachOnDemand()
        {
            VmSource = new TestViewModel();
            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => VmTarget.TargetProperty);

            Assert.IsNull(VmTarget.TargetProperty);
            VmSource.Model = new TestModel();
            Assert.IsNull(VmTarget.TargetProperty);
            VmSource.Model.StringProperty = DateTime.Now.Ticks.ToString();
            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.TargetProperty);
            VmSource.Model.StringProperty = "Another value";
            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void Binding_OneLevelOfNull_ShouldUseFallbackValue()
        {
            var vmSource = new TestViewModel();
            var vmTarget = new TestViewModel();

            const string fallbackValue = "Fallback value";
            const string targetNullValue = "Target null value";

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty,
                BindingMode.Default,
                fallbackValue,
                targetNullValue);

            Assert.AreEqual(fallbackValue, vmTarget.TargetProperty);

            vmSource.Model = new TestModel
            {
                StringProperty = DateTime.Now.Ticks.ToString()
            };

            Assert.AreEqual(vmSource.Model.StringProperty, vmTarget.TargetProperty);
        }

        private TestViewModel _vmField;

#if ANDROID
        public EditText TextBox
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextView TextBox
        {
            get;
            private set;
        }
#endif

        [Test]
        public void Binding_SetBindingWithPrivateField_ShouldCreateBinding()
        {
            // Just for comparison
            var vm = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value for local var"
                }
            };

#if ANDROID
            var textBox = new EditText(Application.Context);
#elif __IOS__
            var textBox = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                vm,
                () => vm.Model.StringProperty,
                textBox,
                () => textBox.Text);

            Assert.IsNotNull(_binding);
            Assert.AreEqual(textBox.Text, vm.Model.StringProperty);
            vm.Model.StringProperty = "New value";
            Assert.AreEqual(textBox.Text, vm.Model.StringProperty);

            _vmField = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value for field"
                }
            };

            _binding = new Binding<string, string>(
                _vmField,
                () => _vmField.Model.StringProperty,
                textBox,
                () => textBox.Text);

            Assert.IsNotNull(_binding);
            Assert.AreEqual(textBox.Text, _vmField.Model.StringProperty);
            _vmField.Model.StringProperty = "New value";
            Assert.AreEqual(textBox.Text, _vmField.Model.StringProperty);

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value for public property"
                }
            };

#if ANDROID
            TextBox = new EditText(Application.Context);
#elif __IOS__
            TextBox = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => TextBox.Text);

            Assert.IsNotNull(_binding);
            Assert.AreEqual(textBox.Text, _vmField.Model.StringProperty);
            _vmField.Model.StringProperty = "New value";
            Assert.AreEqual(textBox.Text, _vmField.Model.StringProperty);

            _vmField.Model.StringProperty = "Initial value for field again";

            _binding = this.SetBinding(
                () => _vmField.Model.StringProperty,
                () => TextBox.Text);

            Assert.IsNotNull(_binding);
            Assert.AreEqual(textBox.Text, _vmField.Model.StringProperty);
            _vmField.Model.StringProperty = "New value";
            Assert.AreEqual(textBox.Text, _vmField.Model.StringProperty);
        }

        [Test]
        public void Binding_SetTextBoxToTrueInTwoWayBinding_ShouldRemainLowCaps()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel()
            };
            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => VmTarget.BoolProperty,
                BindingMode.TwoWay);

            Assert.AreEqual(null, VmSource.Model.StringProperty);
            Assert.IsFalse(VmTarget.BoolProperty);

            VmSource.Model.StringProperty = "true";

            Assert.AreEqual("true", VmSource.Model.StringProperty);
            Assert.IsTrue(VmTarget.BoolProperty);

            VmTarget.BoolProperty = false;

            Assert.IsFalse(VmTarget.BoolProperty);
            Assert.AreEqual("False", VmSource.Model.StringProperty);
        }
    }
}