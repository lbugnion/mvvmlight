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
        private Helpers.Binding _binding;

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

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                "Clicked",
                vmTarget.SetPropertyCommand,
                _binding);

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

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                vmTarget.SetPropertyCommand,
                _binding);

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

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                "TouchUpInside",
                vmTarget.SetPropertyCommand,
                _binding);

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

            _binding = new Binding<string, string>(
                vmSource,
                () => vmSource.Model.MyProperty);

            control.SetCommand(
                vmTarget.SetPropertyCommand,
                _binding);

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
    }
}