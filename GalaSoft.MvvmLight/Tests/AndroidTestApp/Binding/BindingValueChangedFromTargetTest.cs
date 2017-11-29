using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingValueChangedFromTargetTest
    {
        public TestViewModel _vmTarget;
        private Helpers.Binding _binding;
        private TestViewModel _vmTargetPrivate;

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

        private TestViewModel VmTargetPrivate
        {
            get;
            set;
        }

        [Test]
        public void BindingTarget_NewBindingWithPrivateFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            _vmTargetPrivate = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _vmTargetPrivate,
                () => _vmTargetPrivate.TargetPropertyObservable,
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
            _vmTargetPrivate.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_NewBindingWithPrivatePropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTargetPrivate = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                VmTargetPrivate,
                () => VmTargetPrivate.TargetPropertyObservable,
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
            VmTargetPrivate.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_NewBindingWithPublicFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            _vmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _vmTarget,
                () => _vmTarget.TargetPropertyObservable,
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
            _vmTarget.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_NewBindingWithPublicPropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetPropertyObservable,
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
            VmTarget.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_NewBindingWithVarTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            var vmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetPropertyObservable,
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
            vmTarget.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_SetBindingWithPrivateFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            _vmTargetPrivate = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _vmTargetPrivate.TargetPropertyObservable,
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
            _vmTargetPrivate.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_SetBindingWithPrivatePropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTargetPrivate = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => VmTargetPrivate.TargetPropertyObservable,
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
            VmTargetPrivate.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_SetBindingWithPublicFieldTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            _vmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _vmTarget.TargetPropertyObservable,
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
            _vmTarget.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingTarget_SetBindingWithPublicPropertyTwoWay_NoError()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => VmTarget.TargetPropertyObservable,
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
            VmTarget.TargetPropertyObservable = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }
    }
}