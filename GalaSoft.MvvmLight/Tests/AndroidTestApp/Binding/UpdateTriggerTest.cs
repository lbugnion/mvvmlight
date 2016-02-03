using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Text;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class UpdateTriggerTest
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
                .UpdateSourceTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

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
                .UpdateSourceTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

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
                () => vm.Model.MyProperty)
                .UpdateSourceTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

            Assert.AreEqual("False", vm.Model.MyProperty);
            Assert.IsFalse(control1.Checked);
            control1.Checked = true;
            Assert.AreEqual("True", vm.Model.MyProperty);
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
                .UpdateSourceTrigger<TextChangedEventArgs>("TextChanged");

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
                .UpdateSourceTrigger<TextChangedEventArgs>("TextChanged");

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
                () => vm.Model.MyProperty)
                .UpdateSourceTrigger<TextChangedEventArgs>("TextChanged");

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.MyProperty);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.MyProperty);
        }

        [Test]
        public void Binding_OneWayFromViewModelToCheckBox_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new CheckBox(Application.Context);

            _binding = new Binding<string, bool>(
                vm,
                () => vm.Model.MyProperty,
                control1,
                () => control1.Checked);

            Assert.AreEqual(null, vm.Model.MyProperty);
            Assert.IsFalse(control1.Checked);
            vm.Model.MyProperty = "True";
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.Checked);
        }

        [Test]
        public void Binding_OneWayFromViewModelToEditText_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new EditText(Application.Context);

            _binding = new Binding<string, string>(
                vm,
                () => vm.Model.MyProperty,
                control1,
                () => control1.Text);

            Assert.AreEqual(null, vm.Model.MyProperty);
            Assert.AreEqual(string.Empty, control1.Text);
            var value = DateTime.Now.Ticks.ToString();
            vm.Model.MyProperty = value;
            Assert.AreEqual(value, vm.Model.MyProperty);
            Assert.AreEqual(vm.Model.MyProperty, control1.Text);
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
                .UpdateSourceTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange")
                .UpdateTargetTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

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
                .UpdateSourceTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange")
                .UpdateTargetTrigger<TextChangedEventArgs>("TextChanged");

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
                () => vm.Model.MyProperty,
                BindingMode.TwoWay)
                .UpdateSourceTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

            Assert.AreEqual("False", vm.Model.MyProperty);
            Assert.IsFalse(control1.Checked);
            control1.Checked = true;
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.Checked);

            var value = "False";
            vm.Model.MyProperty = value;
            Assert.AreEqual(value, vm.Model.MyProperty);
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
                .UpdateSourceTrigger<TextChangedEventArgs>("TextChanged")
                .UpdateTargetTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

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
                .UpdateSourceTrigger<TextChangedEventArgs>("TextChanged")
                .UpdateTargetTrigger<TextChangedEventArgs>("TextChanged");

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
                () => vm.Model.MyProperty,
                BindingMode.TwoWay)
                .UpdateSourceTrigger<TextChangedEventArgs>("TextChanged");

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.MyProperty);
            var value = DateTime.Now.Ticks.ToString();
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.MyProperty);

            value += "Suffix";
            vm.Model.MyProperty = value;
            Assert.AreEqual(value, vm.Model.MyProperty);
            Assert.AreEqual(vm.Model.MyProperty, control1.Text);
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
                () => vm.Model.MyProperty,
                control1,
                () => control1.Checked,
                BindingMode.TwoWay)
                .UpdateTargetTrigger<CompoundButton.CheckedChangeEventArgs>("CheckedChange");

            Assert.AreEqual(null, vm.Model.MyProperty);
            Assert.IsFalse(control1.Checked);
            vm.Model.MyProperty = "True";
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.Checked);

            control1.Checked = false;
            Assert.IsFalse(control1.Checked);
            Assert.AreEqual("False", vm.Model.MyProperty);
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
                () => vm.Model.MyProperty,
                control1,
                () => control1.Text,
                BindingMode.TwoWay)
                .UpdateTargetTrigger<TextChangedEventArgs>("TextChanged");

            Assert.AreEqual(null, vm.Model.MyProperty);
            Assert.AreEqual(string.Empty, control1.Text);
            var value = DateTime.Now.Ticks.ToString();
            vm.Model.MyProperty = value;
            Assert.AreEqual(value, vm.Model.MyProperty);
            Assert.AreEqual(vm.Model.MyProperty, control1.Text);

            value += "Suffix";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.AreEqual(control1.Text, vm.Model.MyProperty);
        }
    }
}