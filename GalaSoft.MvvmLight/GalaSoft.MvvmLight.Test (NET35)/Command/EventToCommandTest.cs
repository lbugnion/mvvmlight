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
    public class EventToCommandTest
    {
        [TestMethod]
        public void TestInvokeWithoutParameter()
        {
            var trigger = new EventToCommand();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.SimpleCommand
            };

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            trigger.Invoke();
            Assert.IsTrue(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestInvokeWithValueParameter()
        {
            var rectangle = new Rectangle();
            var trigger = new EventToCommand();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string ParameterSent = "Hello world";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            trigger.CommandParameterValue = ParameterSent;
            trigger.Invoke();

            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(ParameterSent, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithValueParameterNull()
        {
            var rectangle = new Rectangle();
            var trigger = new EventToCommandStub();
            ((IAttachedObject)trigger).Attach(rectangle);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            trigger.CommandParameterValue = null;
            trigger.InvokeWithEventArgs(new StringEventArgs("Test"));

            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(null, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithBoundParameter()
        {
            var rectangle = new Rectangle();
            var trigger = new EventToCommand();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string ParameterSent = "Hello world";

            var vm = new TestViewModel();
            var bindingCommand = new Binding
            {
                Source = vm.ParameterCommand
            };

            var textBox = new TextBox
            {
                Text = ParameterSent
            };

            var bindingParameter = new Binding
            {
                Source = textBox,
                Path = new PropertyPath("Text")
            };

#if SILVERLIGHT3
            trigger.Command = bindingCommand;
            trigger.CommandParameter = bindingParameter;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, bindingCommand);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);
#endif

            trigger.Invoke();

            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(ParameterSent, vm.ParameterReceived);
        }

        [TestMethod]
        public void TestInvokeWithValueParameterInWrongProperty()
        {
#if !SILVERLIGHT
            var rectangle = new Rectangle();
            var trigger = new EventToCommand();
            ((IAttachedObject)trigger).Attach(rectangle);

            const string ParameterSent = "Hello world";

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ParameterCommand
            };

            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);

            trigger.CommandParameter = ParameterSent;
            trigger.Invoke();

            Assert.IsTrue(vm.CommandExecuted);
            Assert.AreEqual(ParameterSent, vm.ParameterReceived);
#endif
        }

        [TestMethod]
        public void TestDisableCommandOnly()
        {
            var trigger = new EventToCommand();
            var rectangle = new Rectangle();
            ((IAttachedObject)trigger).Attach(rectangle);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommand
            };

            vm.EnableToggledCommand = true;

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            trigger.Invoke();
            Assert.IsTrue(vm.CommandExecuted);

            vm.CommandExecuted = false;
            vm.EnableToggledCommand = false;

            trigger.Invoke();
            Assert.IsFalse(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestEnableCommandAndControl()
        {
            var trigger = new EventToCommand
            {
                MustToggleIsEnabledValue = true
            };

            var button = new Button
            {
                IsEnabled = false
            };

            ((IAttachedObject)trigger).Attach(button);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommand
            };

            vm.EnableToggledCommand = true;

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            Assert.IsTrue(button.IsEnabled);
            trigger.Invoke();
            Assert.IsTrue(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestDisableCommandAndControl()
        {
            var trigger = new EventToCommand
            {
                MustToggleIsEnabledValue = true
            };

            var button = new Button();
            ((IAttachedObject)trigger).Attach(button);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommand
            };

            vm.EnableToggledCommand = false;

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            Assert.IsFalse(button.IsEnabled);
            trigger.Invoke();
            Assert.IsFalse(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestEnableCommandAndRectangle()
        {
            var trigger = new EventToCommand
            {
                MustToggleIsEnabledValue = true
            };

#if SILVERLIGHT
            var rectangle = new Rectangle();
#else
            var rectangle = new Rectangle
            {
                IsEnabled = false
            };
#endif

            ((IAttachedObject)trigger).Attach(rectangle);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommand
            };

            vm.EnableToggledCommand = true;

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

#if !SILVERLIGHT
            Assert.IsTrue(rectangle.IsEnabled);
#endif
            trigger.Invoke();
            Assert.IsTrue(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestDisableCommandAndRectangle()
        {
            var trigger = new EventToCommand
            {
                MustToggleIsEnabledValue = true
            };

            var rectangle = new Rectangle();

            ((IAttachedObject)trigger).Attach(rectangle);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommand
            };

            vm.EnableToggledCommand = false;

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

#if !SILVERLIGHT
            Assert.IsFalse(rectangle.IsEnabled);
#endif
            trigger.Invoke();
            Assert.IsFalse(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestEnableAndDisableControlWithValueParameter()
        {
            var trigger = new EventToCommand
            {
                MustToggleIsEnabledValue = true
            };

            var button = new Button();
            ((IAttachedObject)trigger).Attach(button);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommandWithParameter
            };

            trigger.CommandParameterValue = "Hel";

#if SILVERLIGHT3
            trigger.Command = binding;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
#endif

            Assert.IsFalse(button.IsEnabled);
            trigger.Invoke();
            Assert.IsFalse(vm.CommandExecuted);

            trigger.CommandParameterValue = "Hello world";

            Assert.IsTrue(button.IsEnabled);
            trigger.Invoke();
            Assert.IsTrue(vm.CommandExecuted);
        }

        [TestMethod]
        public void TestEnableAndDisableControlWithBoundParameter()
        {
            var trigger = new EventToCommand
            {
                MustToggleIsEnabledValue = true
            };

            var button = new Button();
            ((IAttachedObject)trigger).Attach(button);

            var vm = new TestViewModel();
            var binding = new Binding
            {
                Source = vm.ToggledCommandWithParameter
            };

            var textBox = new TextBox
            {
                Text = "Hel"
            };

            var bindingParameter = new Binding
            {
                Source = textBox,
                Path = new PropertyPath("Text")
            };

#if SILVERLIGHT3
            trigger.Command = binding;
            trigger.CommandParameter = bindingParameter;
#else
            BindingOperations.SetBinding(trigger, EventToCommand.CommandProperty, binding);
            BindingOperations.SetBinding(trigger, EventToCommand.CommandParameterProperty, bindingParameter);
#endif

            Assert.IsFalse(button.IsEnabled);
            trigger.Invoke();
            Assert.IsFalse(vm.CommandExecuted);

            textBox.Text = "Hello world";

#if SILVERLIGHT
            // Invoking CommandManager from unit tests fails in WPF
            Assert.IsTrue(button.IsEnabled);
            trigger.Invoke();
            Assert.IsTrue(vm.CommandExecuted);
#endif
        }

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

#if SILVERLIGHT3
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

#if SILVERLIGHT3
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

#if SILVERLIGHT3
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

#if SILVERLIGHT3
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

#if SILVERLIGHT3
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

        private class StringEventArgs : EventArgs
        {
            public string Parameter
            {
                get;
                private set;
            }

            public StringEventArgs(string parameter)
            {
                Parameter = parameter;
            }
        }

        private class EventToCommandStub : EventToCommand
        {
            public void InvokeWithEventArgs(EventArgs args)
            {
                base.Invoke(args);
            }
        }

        private class TestViewModel : ViewModelBase
        {
            public bool CommandExecuted
            {
                get;
                set;
            }

            public string ParameterReceived
            {
                get;
                private set;
            }

            public ICommand SimpleCommand
            {
                get;
                private set;
            }

            public ICommand ParameterCommand
            {
                get;
                private set;
            }

            public ICommand ToggledCommand
            {
                get;
                private set;
            }

            public ICommand ToggledCommandWithParameter
            {
                get;
                private set;
            }

            public readonly RelayCommand<EventArgs> CommandWithEventArgs;

            private bool _enableToggledCommand;
            public bool EnableToggledCommand
            {
                private get
                {
                    return _enableToggledCommand;
                }
                set
                {
                    _enableToggledCommand = value;
                    ((RelayCommand)ToggledCommand).RaiseCanExecuteChanged();
                }
            }

            public TestViewModel()
            {
                SimpleCommand = new RelayCommand(() => CommandExecuted = true);

                ParameterCommand = new RelayCommand<string>(p =>
                {
                    CommandExecuted = true;
                    ParameterReceived = p;
                });

                ToggledCommand = new RelayCommand(
                    () => CommandExecuted = true,
                    () => EnableToggledCommand);

                ToggledCommandWithParameter = new RelayCommand<string>(
                    p =>
                    {
                        CommandExecuted = true;
                        ParameterReceived = p;
                    },
                    p => (p != null && p.StartsWith("Hello")));

                CommandWithEventArgs = new RelayCommand<EventArgs>(e =>
                    {
                        CommandExecuted = true;
                        ParameterReceived = ((StringEventArgs)e).Parameter;
                    });
            }
        }
    }
}
