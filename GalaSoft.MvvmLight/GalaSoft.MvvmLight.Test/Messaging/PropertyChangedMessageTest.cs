using System;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class PropertyChangedMessageTest
    {
        [TestMethod]
        public void TestPropertyChangedMessage()
        {
            ExecuteTest(null, null);
        }

        [TestMethod]
        public void TestPropertyChangedMessageBaseFromViewModelBase()
        {
            var previousDateTime = DateTime.Now - TimeSpan.FromDays(1);
            var currentDateTime = DateTime.Now + TimeSpan.FromDays(1);
            const Exception PreviousException = null;
            var currentException = new InvalidOperationException();

            var receivedPreviousDateTime = DateTime.MinValue;
            var receivedCurrentDateTime = DateTime.MinValue;
            Exception receivedPreviousException = null;
            Exception receivedCurrentException = null;

            object receivedSender = null;
            object receivedTarget = null;

            var messageWasReceived = false;

            var testViewModel = new TestViewModel(previousDateTime, (InvalidOperationException) PreviousException);

            Messenger.Reset();

            Messenger.Default.Register<PropertyChangedMessageBase>(this,
                                                                   true,
                                                                   m =>
                                                                   {
                                                                       receivedSender = m.Sender;
                                                                       receivedTarget = m.Target;
                                                                       messageWasReceived = true;

                                                                       var exceptionMessage =
                                                                           m as
                                                                           PropertyChangedMessage
                                                                               <InvalidOperationException>;

                                                                       if (exceptionMessage != null
                                                                           &&
                                                                           exceptionMessage.PropertyName
                                                                           == TestViewModel.MyExceptionPropertyName)
                                                                       {
                                                                           receivedPreviousException =
                                                                               exceptionMessage.OldValue;
                                                                           receivedCurrentException =
                                                                               exceptionMessage.NewValue;
                                                                           return;
                                                                       }

                                                                       var dateMessage =
                                                                           m as PropertyChangedMessage<DateTime>;

                                                                       if (dateMessage != null
                                                                           &&
                                                                           dateMessage.PropertyName
                                                                           == TestViewModel.MyDatePropertyName)
                                                                       {
                                                                           receivedPreviousDateTime =
                                                                               dateMessage.OldValue;
                                                                           receivedCurrentDateTime =
                                                                               dateMessage.NewValue;
                                                                           return;
                                                                       }
                                                                   });

            Assert.AreEqual(DateTime.MinValue, receivedPreviousDateTime);
            Assert.AreEqual(DateTime.MinValue, receivedCurrentDateTime);
            Assert.AreEqual(null, receivedPreviousException);
            Assert.AreEqual(null, receivedCurrentException);

            testViewModel.MyDate = currentDateTime;

            Assert.IsTrue(messageWasReceived);
            Assert.AreEqual(testViewModel, receivedSender);
            Assert.AreEqual(null, receivedTarget);
            Assert.AreEqual(previousDateTime, receivedPreviousDateTime);
            Assert.AreEqual(currentDateTime, receivedCurrentDateTime);
            Assert.AreEqual(null, receivedPreviousException);
            Assert.AreEqual(null, receivedCurrentException);

            receivedSender = null;
            receivedTarget = null;
            messageWasReceived = false;

            testViewModel.MyException = currentException;

            Assert.IsTrue(messageWasReceived);
            Assert.AreEqual(testViewModel, receivedSender);
            Assert.AreEqual(null, receivedTarget);
            Assert.AreEqual(previousDateTime, receivedPreviousDateTime);
            Assert.AreEqual(currentDateTime, receivedCurrentDateTime);
            Assert.AreEqual(PreviousException, receivedPreviousException);
            Assert.AreEqual(currentException, receivedCurrentException);

            receivedSender = null;
            receivedTarget = null;
            messageWasReceived = false;

            testViewModel.AnotherDate = currentDateTime + TimeSpan.FromDays(3);

            Assert.IsTrue(messageWasReceived);
            Assert.AreEqual(testViewModel, receivedSender);
            Assert.AreEqual(null, receivedTarget);
            Assert.AreEqual(previousDateTime, receivedPreviousDateTime);
            Assert.AreEqual(currentDateTime, receivedCurrentDateTime);
            Assert.AreEqual(PreviousException, receivedPreviousException);
            Assert.AreEqual(currentException, receivedCurrentException);
        }

        [TestMethod]
        public void TestPropertyChangedMessageFomViewModelBase()
        {
            var previousDateTime = DateTime.Now - TimeSpan.FromDays(1);
            var currentDateTime = DateTime.Now + TimeSpan.FromDays(1);
            const Exception PreviousException = null;
            var currentException = new InvalidOperationException();

            var receivedPreviousDateTime = DateTime.MinValue;
            var receivedCurrentDateTime = DateTime.MinValue;
            Exception receivedPreviousException = null;
            Exception receivedCurrentException = null;

            object receivedSender = null;
            object receivedTarget = null;

            var messageWasReceived = false;

            var testViewModel = new TestViewModel(previousDateTime, (InvalidOperationException) PreviousException);

            Messenger.Reset();

            Messenger.Default.Register<PropertyChangedMessage<DateTime>>(this,
                                                                         m =>
                                                                         {
                                                                             receivedSender = m.Sender;
                                                                             receivedTarget = m.Target;
                                                                             messageWasReceived = true;

                                                                             if (m.PropertyName
                                                                                 == TestViewModel.MyDatePropertyName)
                                                                             {
                                                                                 receivedPreviousDateTime = m.OldValue;
                                                                                 receivedCurrentDateTime = m.NewValue;
                                                                                 return;
                                                                             }
                                                                         });

            Messenger.Default.Register<PropertyChangedMessage<InvalidOperationException>>(this,
                                                                                          m =>
                                                                                          {
                                                                                              receivedSender = m.Sender;
                                                                                              receivedTarget = m.Target;
                                                                                              messageWasReceived = true;

                                                                                              if (m.PropertyName
                                                                                                  ==
                                                                                                  TestViewModel.
                                                                                                      MyExceptionPropertyName)
                                                                                              {
                                                                                                  receivedPreviousException
                                                                                                      = m.OldValue;
                                                                                                  receivedCurrentException
                                                                                                      = m.NewValue;
                                                                                                  return;
                                                                                              }
                                                                                          });

            Assert.AreEqual(DateTime.MinValue, receivedPreviousDateTime);
            Assert.AreEqual(DateTime.MinValue, receivedCurrentDateTime);
            Assert.AreEqual(null, receivedPreviousException);
            Assert.AreEqual(null, receivedCurrentException);

            testViewModel.MyDate = currentDateTime;

            Assert.IsTrue(messageWasReceived);
            Assert.AreEqual(testViewModel, receivedSender);
            Assert.AreEqual(null, receivedTarget);
            Assert.AreEqual(previousDateTime, receivedPreviousDateTime);
            Assert.AreEqual(currentDateTime, receivedCurrentDateTime);
            Assert.AreEqual(null, receivedPreviousException);
            Assert.AreEqual(null, receivedCurrentException);

            receivedSender = null;
            receivedTarget = null;
            messageWasReceived = false;

            testViewModel.MyException = currentException;

            Assert.IsTrue(messageWasReceived);
            Assert.AreEqual(testViewModel, receivedSender);
            Assert.AreEqual(null, receivedTarget);
            Assert.AreEqual(previousDateTime, receivedPreviousDateTime);
            Assert.AreEqual(currentDateTime, receivedCurrentDateTime);
            Assert.AreEqual(PreviousException, receivedPreviousException);
            Assert.AreEqual(currentException, receivedCurrentException);

            receivedSender = null;
            receivedTarget = null;
            messageWasReceived = false;

            testViewModel.AnotherDate = currentDateTime + TimeSpan.FromDays(3);

            Assert.IsTrue(messageWasReceived);
            Assert.AreEqual(testViewModel, receivedSender);
            Assert.AreEqual(null, receivedTarget);
            Assert.AreEqual(previousDateTime, receivedPreviousDateTime);
            Assert.AreEqual(currentDateTime, receivedCurrentDateTime);
            Assert.AreEqual(PreviousException, receivedPreviousException);
            Assert.AreEqual(currentException, receivedCurrentException);
        }

        [TestMethod]
        public void TestPropertyChangedMessageWithSender()
        {
            ExecuteTest(this, null);
        }

        [TestMethod]
        public void TestPropertyChangedMessageWithSenderAndTarget()
        {
            ExecuteTest(this, this);
        }

        // Helpers

        private void ExecuteTest(object sender, object target)
        {
            const string PropertyName1 = "MyProperty1";
            const string PropertyName2 = "MyProperty2";
            const string TestNewContent1 = "abcd";
            const string TestNewContent2 = "efgh";
            const string TestOldContent1 = "ijkl";
            const string TestOldContent2 = "mnop";

            string receivedNewContent1 = null;
            string receivedNewContent2 = null;
            string receivedOldContent1 = null;
            string receivedOldContent2 = null;

            object receivedSender = null;
            object receivedTarget = null;

            Messenger.Reset();

            Messenger.Default.Register<PropertyChangedMessage<string>>(this,
                                                                       m =>
                                                                       {
                                                                           receivedSender = m.Sender;
                                                                           receivedTarget = m.Target;

                                                                           if (m.PropertyName == PropertyName1)
                                                                           {
                                                                               receivedNewContent1 = m.NewValue;
                                                                               receivedOldContent1 = m.OldValue;
                                                                               return;
                                                                           }

                                                                           if (m.PropertyName == PropertyName2)
                                                                           {
                                                                               receivedNewContent2 = m.NewValue;
                                                                               receivedOldContent2 = m.OldValue;
                                                                               return;
                                                                           }
                                                                       });

            Assert.AreEqual(null, receivedNewContent1);
            Assert.AreEqual(null, receivedOldContent1);
            Assert.AreEqual(null, receivedNewContent2);
            Assert.AreEqual(null, receivedOldContent2);

            PropertyChangedMessage<string> propertyMessage1;
            PropertyChangedMessage<string> propertyMessage2;

            if (sender == null)
            {
                propertyMessage1 = new PropertyChangedMessage<string>(TestOldContent1, TestNewContent1, PropertyName1);
                propertyMessage2 = new PropertyChangedMessage<string>(TestOldContent2, TestNewContent2, PropertyName2);
            }
            else
            {
                if (target == null)
                {
                    propertyMessage1 = new PropertyChangedMessage<string>(sender,
                                                                          TestOldContent1,
                                                                          TestNewContent1,
                                                                          PropertyName1);
                    propertyMessage2 = new PropertyChangedMessage<string>(sender,
                                                                          TestOldContent2,
                                                                          TestNewContent2,
                                                                          PropertyName2);
                }
                else
                {
                    propertyMessage1 = new PropertyChangedMessage<string>(sender,
                                                                          target,
                                                                          TestOldContent1,
                                                                          TestNewContent1,
                                                                          PropertyName1);
                    propertyMessage2 = new PropertyChangedMessage<string>(sender,
                                                                          target,
                                                                          TestOldContent2,
                                                                          TestNewContent2,
                                                                          PropertyName2);
                }
            }

            Messenger.Default.Send(propertyMessage1);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(TestOldContent1, receivedOldContent1);
            Assert.AreEqual(TestNewContent1, receivedNewContent1);
            Assert.AreEqual(null, receivedOldContent2);
            Assert.AreEqual(null, receivedNewContent2);

            receivedTarget = null;
            receivedSender = null;

            Messenger.Default.Send(propertyMessage2);

            Assert.AreEqual(sender, receivedSender);
            Assert.AreEqual(target, receivedTarget);
            Assert.AreEqual(TestOldContent1, receivedOldContent1);
            Assert.AreEqual(TestNewContent1, receivedNewContent1);
            Assert.AreEqual(TestOldContent2, receivedOldContent2);
            Assert.AreEqual(TestNewContent2, receivedNewContent2);
        }

        public class TestViewModel : ViewModelBase
        {
            /// <summary>
            /// The <see cref="AnotherDate" /> property's name.
            /// </summary>
            public const string AnotherDatePropertyName = "AnotherDate";

            /// <summary>
            /// The <see cref="MyDate" /> property's name.
            /// </summary>
            public const string MyDatePropertyName = "MyDate";

            /// <summary>
            /// The <see cref="MyException" /> property's name.
            /// </summary>
            public const string MyExceptionPropertyName = "MyException";

            private DateTime _anotherDate;

            private DateTime _myDate;

            private InvalidOperationException _myException;

            public TestViewModel(DateTime initialValueDateTime, InvalidOperationException initialValueException)
            {
                _myDate = initialValueDateTime;
                _myException = initialValueException;
            }

            /// <summary>
            /// Gets the AnotherDate property.
            /// Changes to that property's value raise the PropertyChanged event. 
            /// This property's value is broadcasted by the Messenger's default instance when it changes.
            /// </summary>
            public DateTime AnotherDate
            {
                get
                {
                    return _anotherDate;
                }

                set
                {
                    if (_anotherDate == value)
                    {
                        return;
                    }

                    var oldValue = _anotherDate;
                    _anotherDate = value;
                    RaisePropertyChanged(AnotherDatePropertyName, oldValue, value, true);
                }
            }

            /// <summary>
            /// Gets the MyDate property.
            /// Changes to that property's value raise the PropertyChanged event. 
            /// This property's value is broadcasted by the Messenger's default instance when it changes.
            /// </summary>
            public DateTime MyDate
            {
                get
                {
                    return _myDate;
                }

                set
                {
                    if (_myDate == value)
                    {
                        return;
                    }

                    var oldValue = _myDate;
                    _myDate = value;
                    RaisePropertyChanged(MyDatePropertyName, oldValue, value, true);
                }
            }

            /// <summary>
            /// Gets the MyException property.
            /// Changes to that property's value raise the PropertyChanged event. 
            /// This property's value is broadcasted by the Messenger's default instance when it changes.
            /// </summary>
            public InvalidOperationException MyException
            {
                get
                {
                    return _myException;
                }

                set
                {
                    if (_myException == value)
                    {
                        return;
                    }

                    var oldValue = _myException;
                    _myException = value;
                    RaisePropertyChanged(MyExceptionPropertyName, oldValue, value, true);
                }
            }
        }
    }
}