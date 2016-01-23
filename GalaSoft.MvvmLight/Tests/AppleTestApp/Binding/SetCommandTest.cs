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
    public class SetCommandTest
    {
        [Test]
        public void SetCommand_OnBarButtonNoValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var control = new UIBarButtonItemEx();

            control.SetCommand("Clicked", vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnBarButtonNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var control = new UIBarButtonItemEx();

            control.SetCommand(vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnBarButtonWithBinding_ParameterShouldUpdate()
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

            var control = new UIBarButtonItemEx();

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                "Clicked",
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnBarButtonWithBindingNoEventName_ParameterShouldUpdate()
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

            var control = new UIBarButtonItemEx();

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnBarButtonWithSimpleValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var control = new UIBarButtonItemEx();

            control.SetCommand(
                "Clicked",
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnBarButtonWithSimpleValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var control = new UIBarButtonItemEx();

            control.SetCommand(
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonNoValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var control = new UIButtonEx();

            control.SetCommand("TouchUpInside", vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();
            vmTarget.Configure(value);

            var control = new UIButtonEx();

            control.SetCommand(vmTarget.SetPropertyWithoutValueCommand);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
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

            var control = new UIButtonEx();

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                "TouchUpInside",
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            control.PerformEvent();
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

            var control = new UIButtonEx();

            var binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                vmTarget.SetPropertyCommand,
                binding);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);

            value += "Test";
            vmSource.Model.MyProperty = value;
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonWithSimpleValue_NoError()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var control = new UIButtonEx();

            control.SetCommand(
                "TouchUpInside",
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_OnButtonWithSimpleValueNoEventName_ClickEventShouldBeUsed()
        {
            var value = DateTime.Now.Ticks.ToString();
            var vmTarget = new TestViewModel();

            var control = new UIButtonEx();

            control.SetCommand(
                vmTarget.SetPropertyCommand,
                value);

            Assert.IsNull(vmTarget.TargetProperty);
            control.PerformEvent();
            Assert.AreEqual(value, vmTarget.TargetProperty);
        }

        [Test]
        public void SetCommand_WithICommandOnBarButtonNoValue_NoError()
        {
            var vmTarget = new TestViewModel();
            var control = new UIBarButtonItemEx();

            control.SetCommand("Clicked", vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            control.PerformEvent();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        [Test]
        public void SetCommand_WithICommandOnBarButtonNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var vmTarget = new TestViewModel();
            var control = new UIBarButtonItemEx();

            control.SetCommand(vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            control.PerformEvent();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        [Test]
        public void SetCommand_WithICommandOnButtonNoValue_NoError()
        {
            var vmTarget = new TestViewModel();
            var control = new UIButtonEx();

            control.SetCommand("TouchUpInside", vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            control.PerformEvent();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        [Test]
        public void SetCommand_WithICommandOnButtonNoValueNoEventName_ClickEventShouldBeUsed()
        {
            var vmTarget = new TestViewModel();
            var control = new UIButtonEx();

            control.SetCommand(vmTarget.TestCommandImpl);

            var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

            Assert.IsNull(castedCommand.Parameter);
            control.PerformEvent();
            Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        }

        //            () => vmSource.Model.MyProperty);
        //            vmSource,

        //        var binding = new Binding<string, string>(

        //        var checkBox = new CheckBox(Application.Context);

        //        var vmTarget = new TestViewModel();
        //        };
        //            }
        //                MyProperty = value
        //            {
        //            Model = new TestModel
        //        {

        //        var vmSource = new TestViewModel
        //        var value = DateTime.Now.Ticks.ToString();
        //    {
        //    public void SetCommand_OnCheckBoxWithBinding_ParameterShouldUpdate()

        //    [Test]

        //        checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
        //            "CheckedChange",
        //            vmTarget.SetPropertyCommand,
        //            binding);

        //        Assert.IsNull(vmTarget.TargetProperty);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);

        //        value += "Test";
        //        vmSource.Model.MyProperty = value;
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);
        //    }

        //    [Test]
        //    public void SetCommand_OnCheckBoxWithBindingNoEventName_ParameterShouldUpdate()
        //    {
        //        var value = DateTime.Now.Ticks.ToString();

        //        var vmSource = new TestViewModel
        //        {
        //            Model = new TestModel
        //            {
        //                MyProperty = value
        //            }
        //        };

        //        var vmTarget = new TestViewModel();

        //        var checkBox = new CheckBox(Application.Context);

        //        var binding = new Binding<string, string>(
        //            vmSource,
        //            () => vmSource.Model.MyProperty);

        //        checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
        //            vmTarget.SetPropertyCommand,
        //            binding);

        //        Assert.IsNull(vmTarget.TargetProperty);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);

        //        value += "Test";
        //        vmSource.Model.MyProperty = value;
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);
        //    }

        //    [Test]
        //    public void SetCommand_OnCheckBoxWithSimpleValue_NoError()
        //    {
        //        var value = DateTime.Now.Ticks.ToString();
        //        var vmTarget = new TestViewModel();

        //        var checkBox = new CheckBox(Application.Context);

        //        checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
        //            "CheckedChange",
        //            vmTarget.SetPropertyCommand,
        //            value);

        //        Assert.IsNull(vmTarget.TargetProperty);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);
        //    }

        //    [Test]
        //    public void SetCommand_OnCheckBoxWithSimpleValueNoEventName_ClickEventShouldBeUsed()
        //    {
        //        var value = DateTime.Now.Ticks.ToString();
        //        var vmTarget = new TestViewModel();

        //        var checkBox = new CheckBox(Application.Context);

        //        checkBox.SetCommand<string, CompoundButton.CheckedChangeEventArgs>(
        //            vmTarget.SetPropertyCommand,
        //            value);

        //        Assert.IsNull(vmTarget.TargetProperty);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);
        //    }

        //    [Test]
        //    public void SetCommand_OnCheckBoxNoValue_NoError()
        //    {
        //        var value = DateTime.Now.Ticks.ToString();
        //        var vmTarget = new TestViewModel();
        //        vmTarget.Configure(value);

        //        var checkBox = new CheckBox(Application.Context);

        //        checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>("CheckedChange", vmTarget.SetPropertyWithoutValueCommand);

        //        Assert.IsNull(vmTarget.TargetProperty);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);
        //    }

        //    [Test]
        //    public void SetCommand_OnCheckBoxNoValueNoEventName_ClickEventShouldBeUsed()
        //    {
        //        var value = DateTime.Now.Ticks.ToString();
        //        var vmTarget = new TestViewModel();
        //        vmTarget.Configure(value);

        //        var checkBox = new CheckBox(Application.Context);

        //        checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>(vmTarget.SetPropertyWithoutValueCommand);

        //        Assert.IsNull(vmTarget.TargetProperty);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(value, vmTarget.TargetProperty);
        //    }

        //    [Test]
        //    public void SetCommand_WithICommandOnCheckBoxNoValue_NoError()
        //    {
        //        var vmTarget = new TestViewModel();
        //        var checkBox = new CheckBox(Application.Context);

        //        checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>("CheckedChange", vmTarget.TestCommandImpl);

        //        var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

        //        Assert.IsNull(castedCommand.Parameter);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        //    }

        //    [Test]
        //    public void SetCommand_WithICommandOnCheckBoxNoValueNoEventName_ClickEventShouldBeUsed()
        //    {
        //        var vmTarget = new TestViewModel();
        //        var checkBox = new CheckBox(Application.Context);

        //        checkBox.SetCommand<CompoundButton.CheckedChangeEventArgs>(vmTarget.TestCommandImpl);

        //        var castedCommand = (CommandImpl)vmTarget.TestCommandImpl;

        //        Assert.IsNull(castedCommand.Parameter);
        //        checkBox.PerformClick();
        //        Assert.AreEqual(TestViewModel.ValueForCommand, castedCommand.Parameter);
        //    }
    }
}