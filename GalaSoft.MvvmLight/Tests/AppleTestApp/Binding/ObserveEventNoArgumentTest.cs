using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.Controls;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ObserveEventNoArgumentTest
    {
        private Helpers.Binding _binding;

        [Test]
        public void Binding_OneWayFromCheckBoxToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UISwitchEx();
            var control2 = new UISwitchEx();

            _binding = new Binding<bool, bool>(
                control1,
                () => control1.On,
                control2,
                () => control2.On)
                .ObserveSourceEvent();

            Assert.IsFalse(control1.On);
            Assert.IsFalse(control2.On);
            control1.On = true;
            Assert.IsTrue(control1.On);
            Assert.IsTrue(control2.On);
        }

        [Test]
        public void Binding_OneWayFromCheckBoxToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UITextViewEx();
            var control2 = new UISwitchEx();

            _binding = new Binding<bool, string>(
                control2,
                () => control2.On,
                control1,
                () => control1.Text)
                .ObserveSourceEvent();

            Assert.AreEqual("False", control1.Text);
            Assert.IsFalse(control2.On);
            control2.On = true;
            Assert.AreEqual("True", control1.Text);
            Assert.IsTrue(control2.On);
        }

        [Test]
        public void Binding_OneWayFromCheckBoxToViewModelWithUpdateTrigger_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new UISwitchEx();

            _binding = new Binding<bool, string>(
                control1,
                () => control1.On,
                vm,
                () => vm.Model.MyProperty)
                .ObserveSourceEvent();

            Assert.AreEqual("False", vm.Model.MyProperty);
            Assert.IsFalse(control1.On);
            control1.On = true;
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.On);
        }

        [Test]
        public void Binding_OneWayFromEditTextToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UITextViewEx();
            var control2 = new UISwitchEx();

            _binding = new Binding<string, bool>(
                control1,
                () => control1.Text,
                control2,
                () => control2.On)
                .ObserveSourceEvent();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.IsFalse(control2.On);
            var value = "True";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsTrue(control2.On);
        }

        [Test]
        public void Binding_OneWayFromEditTextToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UITextViewEx();
            var control2 = new UITextViewEx();

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text)
                .ObserveSourceEvent();

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

            var control1 = new UITextViewEx();

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                vm,
                () => vm.Model.MyProperty)
                .ObserveSourceEvent();

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

            var control1 = new UISwitchEx();

            _binding = new Binding<string, bool>(
                vm,
                () => vm.Model.MyProperty,
                control1,
                () => control1.On);

            Assert.AreEqual(null, vm.Model.MyProperty);
            Assert.IsFalse(control1.On);
            vm.Model.MyProperty = "True";
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.On);
        }

        [Test]
        public void Binding_OneWayFromViewModelToEditText_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new UITextViewEx();

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
            var control1 = new UISwitchEx();
            var control2 = new UISwitchEx();

            _binding = new Binding<bool, bool>(
                control1,
                () => control1.On,
                control2,
                () => control2.On,
                BindingMode.TwoWay)
                .ObserveSourceEvent()
                .ObserveTargetEvent();

            Assert.IsFalse(control1.On);
            Assert.IsFalse(control2.On);
            control1.On = true;
            Assert.IsTrue(control1.On);
            Assert.IsTrue(control2.On);

            control2.On = false;
            Assert.IsFalse(control2.On);
            Assert.IsFalse(control1.On);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UITextViewEx();
            var control2 = new UISwitchEx();

            _binding = new Binding<bool, string>(
                control2,
                () => control2.On,
                control1,
                () => control1.Text,
                BindingMode.TwoWay)
                .ObserveSourceEvent()
                .ObserveTargetEvent();

            Assert.AreEqual("False", control1.Text);
            Assert.IsFalse(control2.On);
            control2.On = true;
            Assert.AreEqual("True", control1.Text);
            Assert.IsTrue(control2.On);

            var value = "False";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsFalse(control2.On);
        }

        [Test]
        public void Binding_TwoWayFromCheckBoxToViewModelWithUpdateTrigger_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new UISwitchEx();

            _binding = new Binding<bool, string>(
                control1,
                () => control1.On,
                vm,
                () => vm.Model.MyProperty,
                BindingMode.TwoWay)
                .ObserveSourceEvent();

            Assert.AreEqual("False", vm.Model.MyProperty);
            Assert.IsFalse(control1.On);
            control1.On = true;
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.On);

            var value = "False";
            vm.Model.MyProperty = value;
            Assert.AreEqual(value, vm.Model.MyProperty);
            Assert.IsFalse(control1.On);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToCheckBoxWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UITextViewEx();
            var control2 = new UISwitchEx();

            _binding = new Binding<string, bool>(
                control1,
                () => control1.Text,
                control2,
                () => control2.On,
                BindingMode.TwoWay)
                .ObserveSourceEvent()
                .ObserveTargetEvent();

            Assert.AreEqual(string.Empty, control1.Text);
            Assert.IsFalse(control2.On);
            var value = "True";
            control1.Text = value;
            Assert.AreEqual(value, control1.Text);
            Assert.IsTrue(control2.On);

            control2.On = false;
            Assert.IsFalse(control2.On);
            Assert.AreEqual("False", control1.Text);
        }

        [Test]
        public void Binding_TwoWayFromEditTextToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var control1 = new UITextViewEx();
            var control2 = new UITextViewEx();

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                control2,
                () => control2.Text,
                BindingMode.TwoWay)
                .ObserveSourceEvent()
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

            var control1 = new UITextViewEx();

            _binding = new Binding<string, string>(
                control1,
                () => control1.Text,
                vm,
                () => vm.Model.MyProperty,
                BindingMode.TwoWay)
                .ObserveSourceEvent();

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

            var control1 = new UISwitchEx();

            _binding = new Binding<string, bool>(
                vm,
                () => vm.Model.MyProperty,
                control1,
                () => control1.On,
                BindingMode.TwoWay)
                .ObserveTargetEvent();

            Assert.AreEqual(null, vm.Model.MyProperty);
            Assert.IsFalse(control1.On);
            vm.Model.MyProperty = "True";
            Assert.AreEqual("True", vm.Model.MyProperty);
            Assert.IsTrue(control1.On);

            control1.On = false;
            Assert.IsFalse(control1.On);
            Assert.AreEqual("False", vm.Model.MyProperty);
        }

        [Test]
        public void Binding_TwoWayFromViewModelToEditTextWithUpdateTrigger_BindingGetsUpdated()
        {
            var vm = new TestViewModel
            {
                Model = new TestModel()
            };

            var control1 = new UITextViewEx();

            _binding = new Binding<string, string>(
                vm,
                () => vm.Model.MyProperty,
                control1,
                () => control1.Text,
                BindingMode.TwoWay)
                .ObserveTargetEvent();

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