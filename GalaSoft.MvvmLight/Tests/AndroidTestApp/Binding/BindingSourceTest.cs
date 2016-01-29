using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingSourceTest
    {
        public TestViewModel _vmSource;
        private TestViewModel _vmSourcePrivate;

        public TestViewModel VmSource
        {
            get;
            private set;
        }

        private TestViewModel VmSourcePrivate
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
        public void BindingSource_NewBindingWithPublicProperty_NoError()
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
        public void BindingSource_NewBindingWithPrivateProperty_NoError()
        {
            // For comparison only

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var vmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty,
                vmTarget,
                () => vmTarget.TargetProperty);

            Assert.AreEqual(vmSource.Model.MyProperty, vmTarget.TargetProperty);
            var newValue1 = DateTime.Now.Ticks.ToString();
            vmSource.Model.MyProperty = newValue1;
            Assert.AreEqual(vmSource.Model.MyProperty, vmTarget.TargetProperty);

            // Actual test

            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            binding = new Helpers.Binding<string, string>(
                VmSourcePrivate,
                () => VmSourcePrivate.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
            var newValue2 = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.MyProperty = newValue2;
            Assert.AreEqual(VmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithPublicField_NoError()
        {
            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                _vmSource,
                () => _vmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSource.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.MyProperty = newValue;
            Assert.AreEqual(_vmSource.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithPrivateField_NoError()
        {
            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                _vmSourcePrivate,
                () => _vmSourcePrivate.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.MyProperty = newValue;
            Assert.AreEqual(_vmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithVar_NoError()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = new Helpers.Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(vmSource.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            vmSource.Model.MyProperty = newValue;
            Assert.AreEqual(vmSource.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPublicProperty_NoError()
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
        public void BindingSource_SetBindingWithPrivateProperty_NoError()
        {
            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = this.SetBinding(
                () => VmSourcePrivate.Model.MyProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
            var newValue2 = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.MyProperty = newValue2;
            Assert.AreEqual(VmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPublicField_NoError()
        {
            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = this.SetBinding(
                () => _vmSource.Model.MyProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSource.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.MyProperty = newValue;
            Assert.AreEqual(_vmSource.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPrivateField_NoError()
        {
            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var binding = this.SetBinding(
                () => _vmSourcePrivate.Model.MyProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.MyProperty = newValue;
            Assert.AreEqual(_vmSourcePrivate.Model.MyProperty, VmTarget.TargetProperty);
        }
    }
}