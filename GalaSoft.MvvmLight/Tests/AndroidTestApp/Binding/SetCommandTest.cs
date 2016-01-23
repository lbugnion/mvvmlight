using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.Controls;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class SetCommandTest
    {
        [Test]
        public void SetCommand_OnButtonExWithSimpleValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var button = new ButtonEx(Application.Context);

            button.SetCommand(
                "Click",
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonExWithSimpleValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var button = new ButtonEx(Application.Context);

            button.SetCommand(
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonNoValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var button = new Button(Application.Context);

            button.SetCommand("Click", vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var button = new Button(Application.Context);

            button.SetCommand(vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonWithBinding_ParameterShouldUpdate()
        {
            var value = DateTime.Now.Ticks.ToString();

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = value
                }
            };

            var vmTarget = new TestViewModel();

            var button = new Button(Application.Context);

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            button.SetCommand(
                "Click",
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonWithBindingNoEventName_ParameterShouldUpdate()
        {
            var value = DateTime.Now.Ticks.ToString();

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = value
                }
            };

            var vmTarget = new TestViewModel();

            var button = new Button(Application.Context);

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            button.SetCommand(
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonWithSimpleValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var button = new Button(Application.Context);

            button.SetCommand(
                "Click",
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonWithSimpleValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var button = new Button(Application.Context);

            button.SetCommand(
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            button.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnCheckBoxNoValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var checkBox = new CheckBox(Application.Context);

            checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>(
                "CheckedChange",
                vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnCheckBoxNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var checkBox = new CheckBox(Application.Context);

            checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>(vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnCheckBoxWithBinding_ParameterShouldUpdate()
        {
            var value = DateTime.Now.Ticks.ToString();

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = value
                }
            };

            var vmTarget = new TestViewModel();

            var checkBox = new CheckBox(Application.Context);

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
                "CheckedChange",
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnCheckBoxWithBindingNoEventName_ParameterShouldUpdate()
        {
            var value = DateTime.Now.Ticks.ToString();

            var vmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    MyProperty = value
                }
            };

            var vmTarget = new TestViewModel();

            var checkBox = new CheckBox(Application.Context);

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnCheckBoxWithSimpleValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var checkBox = new CheckBox(Application.Context);

            checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
                "CheckedChange",
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnCheckBoxWithSimpleValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var checkBox = new CheckBox(Application.Context);

            checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            checkBox.PerformClick();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_WithICommandOnButtonNoValue_NoError()
        {
            var vmTarget = new TestViewModel();
            var button = new Button(Application.Context);

            button.SetCommand("Click", vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            button.PerformClick();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        [Test]
        public void SetCommand_WithICommandOnButtonNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var vmTarget = new TestViewModel();
            var button = new Button(Application.Context);

            button.SetCommand(vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            button.PerformClick();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        [Test]
        public void SetCommand_WithICommandOnCheckBoxNoValue_NoError()
        {
            var vmTarget = new TestViewModel();
            var checkBox = new CheckBox(Application.Context);

            checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>("CheckedChange", vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            checkBox.PerformClick();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        [Test]
        public void SetCommand_WithICommandOnCheckBoxNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var vmTarget = new TestViewModel();
            var checkBox = new CheckBox(Application.Context);

            checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>(vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            checkBox.PerformClick();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }
    }
}