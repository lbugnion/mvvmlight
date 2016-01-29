using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingTargetTest
    {
        public TestViewModel _vmTarget;
        private TestViewModel _vmTargetPrivate;

        public TestViewModel VmSource
        {
            get;
            private set;
        }

        private TestViewModel VmTargetPrivate
        {
            get;
            set;
        }

        public TestViewModel VmTarget
        {
            get;
            private set;
        }

        [Test]
        public void BindingTarget_NewBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_NewBindingWithPrivateProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTargetPrivate = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                VmTargetPrivate,
                () => VmTargetPrivate.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetProperty);
        }

        [Test]
        public void BindingTarget_NewBindingWithPublicField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                _vmTarget,
                () => _vmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_NewBindingWithPrivateField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTargetPrivate = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                _vmTargetPrivate,
                () => _vmTargetPrivate.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetProperty);
        }

        [Test]
        public void BindingTarget_NewBindingWithVar_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var vmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                vmTarget,
                () => vmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, vmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, vmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPrivateProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTargetPrivate = new TestViewModel();

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTargetPrivate.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPublicField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTarget = new TestViewModel();

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _vmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPrivateField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTargetPrivate = new TestViewModel();

            var binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _vmTargetPrivate.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetProperty);
        }
    }
}