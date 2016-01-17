using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.ViewModel;

#if NETFX_CORE || (WINDOWS_PHONE && !WINDOWS_PHONE7)
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test
{
    [TestClass]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ViewModelBaseAndPropertyChangedTest
    {
        [TestMethod]
        public void RaisePropertyChanged_WithString_ShouldCallRaisePropertyChangedWithStringOnly()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithString")
                {
                    eventWasRaised = true;
                }
            };

            Assert.IsFalse(testObject.BoolPropertyWithString);
            testObject.BoolPropertyWithString = true;
            Assert.IsTrue(testObject.BoolPropertyWithString);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsFalse(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithExpression_ShouldCallRaisePropertyChangedWithStringAndWithExpression()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithExpression")
                {
                    eventWasRaised = true;
                }
            };

            Assert.IsFalse(testObject.BoolPropertyWithExpression);
            testObject.BoolPropertyWithExpression = true;
            Assert.IsTrue(testObject.BoolPropertyWithExpression);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsTrue(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithExpressionAndMessage_ShouldCallRaisePropertyChangedWithStringAndWithExpression()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            var messageWasReceived = false;

            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithExpressionAndMessage")
                {
                    eventWasRaised = true;
                }
            };

            Messenger.Default.Register<PropertyChangedMessage<bool>>(
                this,
                message =>
                {
                    if (message.PropertyName == "BoolPropertyWithExpressionAndMessage"
                        && message.Sender == testObject)
                    {
                        messageWasReceived = true;
                    }
                });

            Assert.IsFalse(testObject.BoolPropertyWithExpressionAndMessage);
            testObject.BoolPropertyWithExpressionAndMessage = true;
            Assert.IsTrue(testObject.BoolPropertyWithExpressionAndMessage);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(messageWasReceived);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsTrue(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithSetAndExpression_ShouldCallRaisePropertyChangedWithStringAndWithExpression()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithSetAndExpression")
                {
                    eventWasRaised = true;
                }
            };

            Assert.IsFalse(testObject.BoolPropertyWithSetAndExpression);
            testObject.BoolPropertyWithSetAndExpression = true;
            Assert.IsTrue(testObject.BoolPropertyWithSetAndExpression);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsTrue(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithSetAndExpressionAndMessage_ShouldCallRaisePropertyChangedWithStringAndWithExpression()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            var messageWasReceived = false;

            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithSetAndExpressionAndMessage")
                {
                    eventWasRaised = true;
                }
            };

            Messenger.Default.Register<PropertyChangedMessage<bool>>(
                this,
                message =>
                {
                    if (message.PropertyName == "BoolPropertyWithSetAndExpressionAndMessage"
                        && message.Sender == testObject)
                    {
                        messageWasReceived = true;
                    }
                });

            Assert.IsFalse(testObject.BoolPropertyWithSetAndExpressionAndMessage);
            testObject.BoolPropertyWithSetAndExpressionAndMessage = true;
            Assert.IsTrue(testObject.BoolPropertyWithSetAndExpressionAndMessage);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(messageWasReceived);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsTrue(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithSetAndString_ShouldCallRaisePropertyChangedWithStringOnly()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithSetAndString")
                {
                    eventWasRaised = true;
                }
            };

            Assert.IsFalse(testObject.BoolPropertyWithSetAndString);
            testObject.BoolPropertyWithSetAndString = true;
            Assert.IsTrue(testObject.BoolPropertyWithSetAndString);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsFalse(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithSetAndStringAndMessage_ShouldCallRaisePropertyChangedWithStringOnly()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            var messageWasReceived = false;

            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithSetAndStringAndMessage")
                {
                    eventWasRaised = true;
                }
            };

            Messenger.Default.Register<PropertyChangedMessage<bool>>(
                this,
                message =>
                {
                    if (message.PropertyName == "BoolPropertyWithSetAndStringAndMessage"
                        && message.Sender == testObject)
                    {
                        messageWasReceived = true;
                    }
                });

            Assert.IsFalse(testObject.BoolPropertyWithSetAndStringAndMessage);
            testObject.BoolPropertyWithSetAndStringAndMessage = true;
            Assert.IsTrue(testObject.BoolPropertyWithSetAndStringAndMessage);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(messageWasReceived);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsFalse(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithStringAndMessage_ShouldCallRaisePropertyChangedWithStringOnly()
        {
            var testObject = new TestViewModelForPropertyChanged();

            var eventWasRaised = false;
            var messageWasReceived = false;

            testObject.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "BoolPropertyWithStringAndMessage")
                {
                    eventWasRaised = true;
                }
            };

            Messenger.Default.Register<PropertyChangedMessage<bool>>(
                this,
                message =>
                {
                    if (message.PropertyName == "BoolPropertyWithStringAndMessage"
                        && message.Sender == testObject)
                    {
                        messageWasReceived = true;
                    }
                });

            Assert.IsFalse(testObject.BoolPropertyWithStringAndMessage);
            testObject.BoolPropertyWithStringAndMessage = true;
            Assert.IsTrue(testObject.BoolPropertyWithStringAndMessage);
            Assert.IsTrue(eventWasRaised);
            Assert.IsTrue(messageWasReceived);
            Assert.IsTrue(testObject.RaisePropertyChangedWithPropertyNameWasCalled);
            Assert.IsFalse(testObject.RaisePropertyChangedWithExpressionWasCalled);
        }
    }
}
