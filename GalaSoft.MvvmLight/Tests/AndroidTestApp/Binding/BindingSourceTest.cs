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
        private Helpers.Binding _binding;
        private TestViewModel _vmSourcePrivate;

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

        private TestViewModel VmSourcePrivate
        {
            get;
            set;
        }

        [Test]
        public void BindingSource_NewBindingWithPrivateField_NoError()
        {
            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                _vmSourcePrivate,
                () => _vmSourcePrivate.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.StringProperty = newValue;
            Assert.AreEqual(_vmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithPrivateProperty_NoError()
        {
            // For comparison only

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            var vmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.StringProperty,
                vmTarget,
                () => vmTarget.TargetProperty);

            Assert.AreEqual(vmSource.Model.StringProperty, vmTarget.TargetProperty);
            var newValue1 = DateTime.Now.Ticks.ToString();
            vmSource.Model.StringProperty = newValue1;
            Assert.AreEqual(vmSource.Model.StringProperty, vmTarget.TargetProperty);

            // Actual test

            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSourcePrivate,
                () => VmSourcePrivate.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
            var newValue2 = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.StringProperty = newValue2;
            Assert.AreEqual(VmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithPublicField_NoError()
        {
            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                _vmSource,
                () => _vmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSource.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.StringProperty = newValue;
            Assert.AreEqual(_vmSource.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_NewBindingWithVar_NoError()
        {
            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(vmSource.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            vmSource.Model.StringProperty = newValue;
            Assert.AreEqual(vmSource.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPrivateField_NoError()
        {
            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => _vmSourcePrivate.Model.StringProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.StringProperty = newValue;
            Assert.AreEqual(_vmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPrivateProperty_NoError()
        {
            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSourcePrivate.Model.StringProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
            var newValue2 = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.StringProperty = newValue2;
            Assert.AreEqual(VmSourcePrivate.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPublicField_NoError()
        {
            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => _vmSource.Model.StringProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(_vmSource.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.StringProperty = newValue;
            Assert.AreEqual(_vmSource.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingSource_SetBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.TargetProperty);
        }
    }
}