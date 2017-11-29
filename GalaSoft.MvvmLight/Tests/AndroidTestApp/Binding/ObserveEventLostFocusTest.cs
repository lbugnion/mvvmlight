using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ObserveEventLostFocusTest
    {
        private Helpers.Binding _binding;

        [Test]
        public void Binding_OneWayFromCheckBoxToCheckBoxWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new CheckBox(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, bool>(
                control1,
                () => control1.Checked,
                control2,
                () => control2.Checked)
                .ObserveSourceEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.IsFalse(control1.Checked);
            Assert.IsFalse(control2.Checked);
            control1.Checked = true;
            Assert.IsTrue(control1.Checked);
            Assert.IsTrue(control2.Checked);
        }

        [Test]
        public void Binding_OneWayFromCheckBoxToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, string>(
                control2,
                () => control2.Checked,
                control1,
                () => control1.Text)
                .ObserveSourceEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.AreEqual("False", control1.Text);
            Assert.IsFalse(control2.Checked);
            control2.Checked = true;
            Assert.IsTrue(control2.Checked);
            Assert.AreEqual("True", control1.Text);
        }

        [Test]
        public void Binding_OneWayFromCheckBoxToViewModelWithObserveEvent_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new CheckBox(Application.Context);

            _binding = new Binding<bool, string>(
                control1,
                () => control1.Checked,
                vm,
                () => vm.Model.StringProperty)
                .ObserveSourceEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.AreEqual("False", vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
            control1.Checked = true;
            Assert.IsTrue(control1.Checked);
            Assert.AreEqual("True", vm.Model.StringProperty);
        }

        [Test]
        public void Binding_OneWayFromEditTextToCheckBoxWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<string, bool>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Checked)
                .ObserveSourceEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.IsFalse(control2.Checked);
            var value = "True";
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsFalse(control2.Checked);
            control1.ClearFocus();
            Assert.IsTrue(control2.Checked);
        }

        [Test]
        public void Binding_OneWayFromEditTextToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text)
                .ObserveSourceEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(string.Empty, control2.Text);
            var value = DateTime.Now.Ticks.ToString();
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(string.Empty, control2.Text);
            control1.ClearFocus();
            Assert.AreEqual(control1.Text, control2.Text);
        }

        [Test]
        public void Binding_OneWayFromEditTextToViewModelWithObserveEvent_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                vm,
                () => vm.Model.StringProperty)
                .ObserveSourceEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(string.Empty, vm.Model.StringProperty);
            var value = DateTime.Now.Ticks.ToString();
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(string.Empty, vm.Model.StringProperty);
            control1.ClearFocus();
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToCheckBoxWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new CheckBox(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, bool>(
                control1,
                () => control1.Checked,
                control2,
                () => control2.Checked,
                BindingMode.TwoWay)
                .ObserveSourceEvent() // LostFocus doesn't work programatically with CheckBoxes
                .ObserveTargetEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.IsFalse(control1.Checked);
            Assert.IsFalse(control2.Checked);
            control1.Checked = true;
            Assert.IsTrue(control1.Checked);
            Assert.IsTrue(control2.Checked);

            control2.RequestFocus();
            control2.Checked = false;
            Assert.IsFalse(control2.Checked);
            Assert.IsFalse(control1.Checked);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, string>(
                control2,
                () => control2.Checked,
                control1,
                () => control1.Text,
                BindingMode.TwoWay)
                .ObserveSourceEvent() // LostFocus doesn't work programatically with CheckBoxes
                .ObserveTargetEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual("False", control1.Text);
            Assert.IsFalse(control2.Checked);
            control2.Checked = true;
            Assert.IsTrue(control2.Checked);
            Assert.AreEqual("True", control1.Text);

            var value = "False";
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsTrue(control2.Checked);
            control1.ClearFocus();
            Assert.IsFalse(control2.Checked);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToViewModelWithObserveEvent_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new CheckBox(Application.Context);

            _binding = new Binding<bool, string>(
                control1,
                () => control1.Checked,
                vm,
                () => vm.Model.StringProperty,
                BindingMode.TwoWay)
                .ObserveSourceEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.AreEqual("False", vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
            control1.Checked = true;
            Assert.IsTrue(control1.Checked);
            Assert.AreEqual("True", vm.Model.StringProperty);

            var value = "False";
            vm.Model.StringProperty = value;
            Assert.AreEqual(value, vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToCheckBoxWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<string, bool>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Checked,
                BindingMode.TwoWay)
                .ObserveSourceEvent(UpdateTriggerMode.LostFocus)
                .ObserveTargetEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.IsFalse(control2.Checked);
            var value = "True";
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsFalse(control2.Checked);
            control1.ClearFocus();
            Assert.IsTrue(control2.Checked);

            control2.Checked = false;
            Assert.IsFalse(control2.Checked);
            Assert.AreEqual("False", control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text,
                BindingMode.TwoWay)
                .ObserveSourceEvent(UpdateTriggerMode.LostFocus)
                .ObserveTargetEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(string.Empty, control2.Text);
            var value = DateTime.Now.Ticks.ToString();
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(string.Empty, control2.Text);
            control1.ClearFocus();
            Assert.AreEqual(control1.Text, control2.Text);

            var newValue = value + "Suffix";
            control2.RequestFocus();
            control2.Text = newValue;
            Assert.AreEqual(newValue, control2.Text);
            Assert.AreEqual(value, control1.Text);
            control2.ClearFocus();
            Assert.AreEqual(control2.Text, control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToViewModelWithObserveEvent_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                vm,
                () => vm.Model.StringProperty,
                BindingMode.TwoWay)
                .ObserveSourceEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(string.Empty, vm.Model.StringProperty);
            var value = DateTime.Now.Ticks.ToString();
            control1.RequestFocus();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(string.Empty, vm.Model.StringProperty);
            control1.ClearFocus();
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);

            value += "Suffix";
            vm.Model.StringProperty = value;
            Assert.AreEqual(value, vm.Model.StringProperty);
            Assert.AreEqual(vm.Model.StringProperty, control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromViewModelToCheckBoxWithObserveEvent_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new CheckBox(Application.Context);

            _binding = new Binding<string, bool>(
                vm,
                () => vm.Model.StringProperty,
                control1,
                () => control1.Checked,
                BindingMode.TwoWay)
                .ObserveTargetEvent(); // LostFocus doesn't work programatically with CheckBoxes

            Assert.AreEqual(null, vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
            vm.Model.StringProperty = "True";
            Assert.AreEqual("True", vm.Model.StringProperty);
            Assert.IsTrue(control1.Checked);

            control1.RequestFocus();
            control1.Checked = false;
            Assert.IsFalse(control1.Checked);
            Assert.AreEqual("False", vm.Model.StringProperty);
        }

        [Test]
        public void Binding_TwoWayFromViewModelToEditTextWithObserveEvent_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                vm,
                () => vm.Model.StringProperty,
                control1,
                () => control1.Text,
                BindingMode.TwoWay)
                .ObserveTargetEvent(UpdateTriggerMode.LostFocus);

            Assert.AreEqual(null, vm.Model.StringProperty);
            Assert.AreEqual(string.Empty, control1.Text);
            var value = DateTime.Now.Ticks.ToString();
            vm.Model.StringProperty = value;
            Assert.AreEqual(value, vm.Model.StringProperty);
            Assert.AreEqual(vm.Model.StringProperty, control1.Text);

            var newValue = value + "Suffix";
            control1.RequestFocus();
            control1.Text = newValue;
            Assert.AreEqual(newValue, control1.Text);
            Assert.AreEqual(value, vm.Model.StringProperty);
            control1.ClearFocus();
            Assert.AreEqual(newValue, vm.Model.StringProperty);
        }
    }
}