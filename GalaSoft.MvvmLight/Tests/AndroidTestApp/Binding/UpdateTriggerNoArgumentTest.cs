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
    public class UpdateTriggerNoArgumentTest
    {
        private Helpers.Binding _binding;

        [Test]
        public void Binding_OneWayFromCheckBoxToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new CheckBox(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, bool>(
                control1,
                () => control1.Checked,
                control2,
                () => control2.Checked)
                .UpdateSourceTrigger();

            Assert.IsFalse(control1.Checked);
            Assert.IsFalse(control2.Checked);
            control1.Checked = true;
            Assert.IsTrue(control1.Checked);
            Assert.IsTrue(control2.Checked);
        }

        [Test]
        public void Binding_OneWayFromCheckBoxToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, string>(
                control2,
                () => control2.Checked,
                control1,
                () => control1.Text)
                .UpdateSourceTrigger();

            Assert.AreEqual("False", control1.Text);
            Assert.IsFalse(control2.Checked);
            control2.Checked = true;
            Assert.AreEqual("True", control1.Text);
            Assert.IsTrue(control2.Checked);
        }

        [Test]
        public void Binding_OneWayFromCheckBoxToViewModelWithUpdateTrigger_BindingGetsUpdated()
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
                .UpdateSourceTrigger();

            Assert.AreEqual("False", vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
            control1.Checked = true;
            Assert.AreEqual("True", vm.Model.StringProperty);
            Assert.IsTrue(control1.Checked);
        }

        [Test]
        public void Binding_OneWayFromEditTextToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<string, bool>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Checked)
                .UpdateSourceTrigger();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.IsFalse(control2.Checked);
            var value = "True";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsTrue(control2.Checked);
        }

        [Test]
        public void Binding_OneWayFromEditTextToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text)
                .UpdateSourceTrigger();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, control2.Text);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, control2.Text);
        }

        [Test]
        public void Binding_OneWayFromEditTextToViewModelWithUpdateTrigger_BindingGetsUpdated()
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
                .UpdateSourceTrigger();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new CheckBox(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, bool>(
                control1,
                () => control1.Checked,
                control2,
                () => control2.Checked,
                BindingMode.TwoWay)
                .UpdateSourceTrigger()
                .ObserveTargetEvent();

            Assert.IsFalse(control1.Checked);
            Assert.IsFalse(control2.Checked);
            control1.Checked = true;
            Assert.IsTrue(control1.Checked);
            Assert.IsTrue(control2.Checked);

            control2.Checked = false;
            Assert.IsFalse(control2.Checked);
            Assert.IsFalse(control1.Checked);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<bool, string>(
                control2,
                () => control2.Checked,
                control1,
                () => control1.Text,
                BindingMode.TwoWay)
                .UpdateSourceTrigger()
                .ObserveTargetEvent();

            Assert.AreEqual("False", control1.Text);
            Assert.IsFalse(control2.Checked);
            control2.Checked = true;
            Assert.AreEqual("True", control1.Text);
            Assert.IsTrue(control2.Checked);

            var value = "False";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsFalse(control2.Checked);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToViewModelWithUpdateTrigger_BindingGetsUpdated()
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
                .UpdateSourceTrigger();

            Assert.AreEqual("False", vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
            control1.Checked = true;
            Assert.AreEqual("True", vm.Model.StringProperty);
            Assert.IsTrue(control1.Checked);

            var value = "False";
            vm.Model.StringProperty = value;
            Assert.AreEqual(value, vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new CheckBox(Application.Context);

            _binding = new Binding<string, bool>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Checked,
                BindingMode.TwoWay)
                .UpdateSourceTrigger()
                .ObserveTargetEvent();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.IsFalse(control2.Checked);
            var value = "True";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsTrue(control2.Checked);

            control2.Checked = false;
            Assert.IsFalse(control2.Checked);
            Assert.AreEqual("False", control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new EditText(Application.Context);
            var control2 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text,
                BindingMode.TwoWay)
                .UpdateSourceTrigger()
                .ObserveTargetEvent();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, control2.Text);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, control2.Text);

            value += "Suffix";
            control2.Text = value;
            Assert.AreEqual(value, control2.Text);
            Assert.AreEqual(control2.Text, control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToViewModelWithUpdateTrigger_BindingGetsUpdated()
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
                .UpdateSourceTrigger();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);

            value += "Suffix";
            vm.Model.StringProperty = value;
            Assert.AreEqual(value, vm.Model.StringProperty);
            Assert.AreEqual(vm.Model.StringProperty, control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromViewModelToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
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
                .ObserveTargetEvent();

            Assert.AreEqual(null, vm.Model.StringProperty);
            Assert.IsFalse(control1.Checked);
            vm.Model.StringProperty = "True";
            Assert.AreEqual("True", vm.Model.StringProperty);
            Assert.IsTrue(control1.Checked);

            control1.Checked = false;
            Assert.IsFalse(control1.Checked);
            Assert.AreEqual("False", vm.Model.StringProperty);
        }

        [Test]
        public void Binding_TwoWayFromViewModelToEditTextWithUpdateTrigger_BindingGetsUpdated()
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
                .ObserveTargetEvent();

            Assert.AreEqual(null, vm.Model.StringProperty);
            Assert.AreEqual(string.Empty, control1.Text);
            var value = DateTime.Now.Ticks.ToString();
            vm.Model.StringProperty = value;
            Assert.AreEqual(value, vm.Model.StringProperty);
            Assert.AreEqual(vm.Model.StringProperty, control1.Text);

            value += "Suffix";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.StringProperty);
        }
    }
}