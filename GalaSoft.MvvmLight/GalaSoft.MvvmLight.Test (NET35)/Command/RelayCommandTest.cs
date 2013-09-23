using System;
using GalaSoft.MvvmLight.Command;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Command
{
    [TestClass]
    public class RelayCommandTest
    {
        private bool _canExecute = true;
        private WeakReference _reference;
        private TemporaryClass _tempoInstance;

        public RelayCommand TestCommand
        {
            get;
            private set;
        }

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

        [TestMethod]
        public void TestCanExecute()
        {
            var canExecute = true;

            var command = new RelayCommand(
                () =>
                {
                },
                () => canExecute);

            Assert.AreEqual(true, command.CanExecute(null));

            canExecute = false;

            Assert.AreEqual(false, command.CanExecute(null));
        }

        [TestMethod]
        public void TestCanExecuteChanged()
        {
            var command = new RelayCommand(
                () =>
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
#if NETFX_CORE
            Assert.AreEqual(1, canExecuteChangedCalled);
#else
            // In WPF, cannot trigger the CanExecuteChanged event like this
            Assert.AreEqual(0, canExecuteChangedCalled);
#endif
#endif

            command.CanExecuteChanged -= canExecuteChangedEventHandler;
            command.RaiseCanExecuteChanged();

#if SILVERLIGHT
             Assert.AreEqual(1, canExecuteChangedCalled);
#else
#if NETFX_CORE
            Assert.AreEqual(1, canExecuteChangedCalled);
#else
            // In WPF, cannot trigger the CanExecuteChanged event like this
            Assert.AreEqual(0, canExecuteChangedCalled);
#endif
#endif
        }

        [TestMethod]
        public void TestCanExecuteNull()
        {
            var command = new RelayCommand(
                () =>
                {
                });

            Assert.AreEqual(true, command.CanExecute(null));
        }

        [TestMethod]
        public void TestConstructorInvalidExecuteNull1()
        {
            try
            {
                new RelayCommand(null);
                Assert.Fail("ArgumentNullException was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void TestConstructorInvalidExecuteNull2()
        {
            try
            {
                new RelayCommand(null, null);
                Assert.Fail("ArgumentNullException was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestMethod]
        public void TestExecute()
        {
            var dummy = "Not executed";
            const string executed = "Executed";

            var command = new RelayCommand(
                () =>
                {
                    dummy = executed;
                });

            command.Execute(null);

            Assert.AreEqual(executed, dummy);
        }

        private static string _dummyStatic;
        
        [TestMethod]
        public void TestExecuteStatic()
        {
            _dummyStatic = "Not executed";
            const string executed = "Executed";

            var command = new RelayCommand(
                () =>
                {
                    _dummyStatic = executed;
                });

            command.Execute(null);

            Assert.AreEqual(executed, _dummyStatic);
        }

        [TestMethod]
        public void TestReleasingTargetForCanExecute()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            TestCommand = new RelayCommand(
                _tempoInstance.SetContent,
                _tempoInstance.CheckEnabled);

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestReleasingTargetForExecute()
        {
            _tempoInstance = new TemporaryClass();
            _reference = new WeakReference(_tempoInstance);

            TestCommand = new RelayCommand(
                _tempoInstance.SetContent);

            Assert.IsTrue(_reference.IsAlive);

            _tempoInstance = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }
    }
}