using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using System;

#if NEWUNITTEST
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class EventToCommandEventArgsTest
    {
#if !WPSL81 && !WPSL80
        [TestMethod]
        public void TestInvokeSimpleCommandWithEventArgs()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            trigger.PassEventArgsToCommand = true;

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.SimpleCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(null, vm.ParameterReceived);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestInvokeParameterCommandWithEventArgs()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            trigger.PassEventArgsToCommand = true;

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(args.Parameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndNoParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            trigger.PassEventArgsToCommand = true;

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.CommandWithEventArgs
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(args.Parameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndParameterValue()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            trigger.PassEventArgsToCommand = true;

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            const string CommandParameter = "CommandParameter";
            trigger.CommandParameterValue = CommandParameter;

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(CommandParameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndBoundParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            trigger.PassEventArgsToCommand = true;

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            var textBox = new TextBox
            {
                Text = "BoundParameter"
            };

            var bindingParameter = new Binding
            {
                Source = textBox,
                Path = new PropertyPath("Text")
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(textBox.Text, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeSimpleCommandWithEventArgsAndConverter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.SimpleCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(null, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeParameterCommandWithEventArgsAndConverter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(prefix + args.Parameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndNoParameterAndConverter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.CommandWithEventArgsConverted
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(prefix + args.Parameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndParameterValueAndConverter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            const string commandParameter = "CommandParameter";
            trigger.CommandParameterValue = commandParameter;

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(commandParameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndBoundParameterAndConverter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            var textBox = new TextBox
            {
                Text = "BoundParameter"
            };

            var bindingParameter = new Binding
            {
                Source = textBox,
                Path = new PropertyPath("Text")
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(textBox.Text, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeSimpleCommandWithEventArgsAndConverterAndConverterParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };
            trigger.EventArgsConverterParameter = "Suffix";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.SimpleCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(null, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeParameterCommandWithEventArgsAndConverterAndConverterParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };
            trigger.EventArgsConverterParameter = "Suffix";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(prefix + args.Parameter + trigger.EventArgsConverterParameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndNoParameterAndConverterAndConverterParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };
            trigger.EventArgsConverterParameter = "Suffix";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.CommandWithEventArgsConverted
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(prefix + args.Parameter + trigger.EventArgsConverterParameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndParameterValueAndConverterAndConverterParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };
            trigger.EventArgsConverterParameter = "Suffix";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            const string commandParameter = "CommandParameter";
            trigger.CommandParameterValue = commandParameter;

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(commandParameter, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithEventArgsAndBoundParameterAndConverterAndConverterParameter()
        {
            var trigger = new EventToCommandStub();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string prefix = "Test";
            trigger.PassEventArgsToCommand = true;
            trigger.EventArgsConverter = new TestEventArgsConverter
            {
                TestPrefix = prefix
            };
            trigger.EventArgsConverterParameter = "Suffix";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            var textBox = new TextBox
            {
                Text = "BoundParameter"
            };

            var bindingParameter = new Binding
            {
                Source = textBox,
                Path = new PropertyPath("Text")
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(textBox.Text, vm.ParameterReceived);
        }
#endif
    }
}
