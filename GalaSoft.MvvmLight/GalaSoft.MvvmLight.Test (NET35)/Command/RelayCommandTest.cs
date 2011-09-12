using System;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class RelayCommandTest
    {
        [TestMethod]
        public void TestCanExecuteChanged()
        {
            var command = new RelayCommand(() =>
            {
            },
                                           () => true);

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
        public void TestCanExecute()
        {
            var canExecute = true;

            var command = new RelayCommand(() =>
            {
            },
                                           () => canExecute);

            Assert.AreEqual(true, command.CanExecute(null));

            canExecute = false;

            Assert.AreEqual(false, command.CanExecute(null));
        }

        [TestMethod]
        public void TestCanExecuteNull()
        {
            var command = new RelayCommand(() =>
            {
            });

            Assert.AreEqual(true, command.CanExecute(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorInvalidExecuteNull1()
        {
            var command = new RelayCommand(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorInvalidExecuteNull2()
        {
            var command = new RelayCommand(null, null);
        }

        [TestMethod]
        public void TestExecute()
        {
            var dummy = "Not executed";
            const string executed = "Executed";

            var command = new RelayCommand(() =>
            {
                dummy = executed;
            });

            command.Execute(null);

            Assert.AreEqual(executed, dummy);
        }

        private bool _canExecute = true;

        [TestMethod]
        public void TestCallingExecuteWhenCanExecuteIsFalse()
        {
            var counter = 0;

            var command = new RelayCommand(
                () => counter++,
                () => _canExecute);

            command.Execute(null);
            Assert.AreEqual(1, counter);
            _canExecute = false;
            command.Execute(null);
            Assert.AreEqual(1, counter);
            _canExecute = true;
            command.Execute(null);
            Assert.AreEqual(2, counter);
        }
    }
}