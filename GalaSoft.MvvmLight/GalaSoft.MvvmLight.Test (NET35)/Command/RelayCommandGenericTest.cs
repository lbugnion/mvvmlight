using System;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class RelayCommandGenericTest
    {
        [TestMethod]
        public void CanExecuteChangedTest()
        {
            var command = new RelayCommand<string>(p =>
            {
            },
                                                   p => true);

            var canExecuteChangedCalled = 0;

            var canExecuteChangedEventHandler = new EventHandler((s, e) => canExecuteChangedCalled++);

            command.CanExecuteChanged += canExecuteChangedEventHandler;

            command.RaiseCanExecuteChanged();

            Assert.AreEqual(1, canExecuteChangedCalled);

            command.CanExecuteChanged -= canExecuteChangedEventHandler;

            command.RaiseCanExecuteChanged();

            Assert.AreEqual(1, canExecuteChangedCalled);
        }

        [TestMethod]
        public void CanExecuteTest()
        {
            var command = new RelayCommand<string>(p =>
            {
            },
                                                   p => p == "CanExecute");

            Assert.AreEqual(true, command.CanExecute("CanExecute"));
            Assert.AreEqual(false, command.CanExecute("Hello"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void CanExecuteTestInvalidParameterType()
        {
            var command = new RelayCommand<string>(p =>
            {
            },
                                                   p => p == "CanExecute");

            command.CanExecute(DateTime.Now);
        }

        [TestMethod]
        public void CanExecuteTestNull()
        {
            var command = new RelayCommand<string>(p =>
            {
            });

            Assert.AreEqual(true, command.CanExecute("Hello"));
        }

        [TestMethod]
        public void CanExecuteTestNullParameter()
        {
            var command = new RelayCommand<string>(p =>
            {
            },
                                                   p => false);

            Assert.AreEqual(false, command.CanExecute(null));

            var command2 = new RelayCommand<string>(p =>
            {
            },
                                                   p => true);

            Assert.AreEqual(true, command2.CanExecute(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestInvalidExecuteNull1()
        {
            var command = new RelayCommand<string>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestInvalidExecuteNull2()
        {
            var command = new RelayCommand<string>(null, null);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            var dummy = "Not executed";
            const string executed = "Executed";
            const string parameter = "Parameter";

            var command = new RelayCommand<string>(p =>
            {
                dummy = executed + p;
            });

            command.Execute(parameter);

            Assert.AreEqual(executed + parameter, dummy);
        }
    }
}