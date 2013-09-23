using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using System;

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class EventToCommandEventArgsTest
    {
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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
            trigger.CommandParameter = bindingParameter;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
            trigger.CommandParameter = bindingParameter;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

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

#if SL3
            trigger.Command = binding;
            trigger.CommandParameter = bindingParameter;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);
#endif

            var args = new StringEventArgs("StringEventArgs");
            trigger.InvokeWithEventArgs(args);
            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(textBox.Text, vm.ParameterReceived);
        }
    }
}
