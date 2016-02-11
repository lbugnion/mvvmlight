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

            _binding = new Binding<string, string>(
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
        public void BindingTarget_NewBindingWithPrivateFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTargetPrivate = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                _vmTargetPrivate,
                () => _vmTargetPrivate.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, _vmTargetPrivate.TargetPropertyObservable);
            newValue += "Suffix";
            _vmTargetPrivate.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = new Binding<string, string>(
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
        public void BindingTarget_NewBindingWithPrivatePropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTargetPrivate = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                VmTargetPrivate,
                () => VmTargetPrivate.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, VmTargetPrivate.TargetPropertyObservable);
            newValue += "Suffix";
            VmTargetPrivate.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = new Binding<string, string>(
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
        public void BindingTarget_NewBindingWithPublicFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                _vmTarget,
                () => _vmTarget.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, _vmTarget.TargetPropertyObservable);
            newValue += "Suffix";
            _vmTarget.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = new Binding<string, string>(
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
        public void BindingTarget_NewBindingWithPublicPropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, VmTarget.TargetPropertyObservable);
            newValue += "Suffix";
            VmTarget.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = new Binding<string, string>(
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
        public void BindingTarget_NewBindingWithVarTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var vmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                vmTarget,
                () => vmTarget.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, vmTarget.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, vmTarget.TargetPropertyObservable);
            newValue += "Suffix";
            vmTarget.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _vmTargetPrivate.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPrivateFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTargetPrivate = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _vmTargetPrivate.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTargetPrivate.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, _vmTargetPrivate.TargetPropertyObservable);
            newValue += "Suffix";
            _vmTargetPrivate.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTargetPrivate.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPrivatePropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTargetPrivate = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTargetPrivate.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTargetPrivate.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, VmTargetPrivate.TargetPropertyObservable);
            newValue += "Suffix";
            VmTargetPrivate.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _vmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPublicFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            _vmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => _vmTarget.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, _vmTarget.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, _vmTarget.TargetPropertyObservable);
            newValue += "Suffix";
            _vmTarget.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
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

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingTarget_SetBindingWithPublicPropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTarget.TargetPropertyObservable,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.MyProperty, VmTarget.TargetPropertyObservable);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;
            Assert.AreEqual(newValue, VmTarget.TargetPropertyObservable);
            newValue += "Suffix";
            VmTarget.TargetPropertyObservable = newValue;
            Assert.AreEqual(newValue, VmSource.Model.MyProperty);
        }
    }
}