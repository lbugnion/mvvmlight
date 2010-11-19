using System;
using GalaSoft.MvvmLight.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class RelayCommandTest
    {
        [TestMethod]
        public void CanExecuteChangedTest()
        {
            var command = new RelayCommand(() =>
            {
            },
                                           () => true);

            var canExecuteChangedCalled = 0;

            var canExecuteChangedEventHandler = new EventHandler((s, e) => canExecuteChangedCalled++);

            command.CanExecuteChanged += canExecuteChangedEventHandler;

            command.RaiseCanExecuteChanged();

#if SILVERLIGHT
            Assert.AreEqual(1, canExecuteChangedCalled);
#else
            // In WPF, cannot trigger the CanExecuteChanged event like this
            Assert.AreEqual(0, canExecuteChangedCalled);
#endif

            command.CanExecuteChanged -= canExecuteChangedEventHandler;
            command.RaiseCanExecuteChanged();

#if SILVERLIGHT
            Assert.AreEqual(1, canExecuteChangedCalled);
#else
            // In WPF, cannot trigger the CanExecuteChanged event like this
            Assert.AreEqual(0, canExecuteChangedCalled);
#endif
        }

        [TestMethod]
        public void CanExecuteTest()
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
        public void CanExecuteTestNull()
        {
            var command = new RelayCommand(() =>
            {
            });

            Assert.AreEqual(true, command.CanExecute(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestInvalidExecuteNull1()
        {
            var command = new RelayCommand(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestInvalidExecuteNull2()
        {
            var command = new RelayCommand(null, null);
        }

        [TestMethod]
        public void ExecuteTest()
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
    }
}