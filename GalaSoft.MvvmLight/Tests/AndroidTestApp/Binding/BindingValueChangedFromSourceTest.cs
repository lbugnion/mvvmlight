using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingValueChangedFromSourceTest
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
        public void BindingValueChanged_NewBindingWithPrivateField_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                _vmSourcePrivate,
                () => _vmSourcePrivate.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPrivateFieldAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = new Binding<string, string>(
                _vmSourcePrivate,
                () => _vmSourcePrivate.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPrivateProperty_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSourcePrivate,
                () => VmSourcePrivate.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPrivatePropertyAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = new Binding<string, string>(
                VmSourcePrivate,
                () => VmSourcePrivate.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPublicField_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                _vmSource,
                () => _vmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPublicFieldAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = new Binding<string, string>(
                _vmSource,
                () => _vmSource.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPublicProperty_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithPublicPropertyAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithVar_ValueChangedFires()
        {
            var valueChangedFired = false;

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                vmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            vmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_NewBindingWithVarAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                vmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            vmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPrivateField_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => _vmSourcePrivate.Model.MyProperty,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPrivateFieldAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = this.SetBinding(
                () => _vmSourcePrivate.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPrivateProperty_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => VmSourcePrivate.Model.MyProperty,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPrivatePropertyAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSourcePrivate = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = this.SetBinding(
                () => VmSourcePrivate.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSourcePrivate.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSourcePrivate.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPublicField_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => _vmSource.Model.MyProperty,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPublicFieldAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            _vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = this.SetBinding(
                () => _vmSource.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                _vmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            _vmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPublicProperty_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.MyProperty,
                () => VmTarget.TargetProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }

        [Test]
        public void BindingValueChanged_SetBindingWithPublicPropertyAndNoTarget_ValueChangedFires()
        {
            var valueChangedFired = false;

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = "Initial value"
                }
            };

            var bindingGeneric = this.SetBinding(
                () => VmSource.Model.MyProperty);

            _binding = bindingGeneric;

            _binding.ValueChanged += (s, e) =>
            {
                valueChangedFired = true;
            };

            Assert.IsFalse(valueChangedFired);
            Assert.AreEqual(
                VmSource.Model.MyProperty,
                bindingGeneric.Value);

            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.MyProperty = newValue;

            Assert.IsTrue(valueChangedFired);
            Assert.AreEqual(
                newValue,
                bindingGeneric.Value);
        }
    }
}