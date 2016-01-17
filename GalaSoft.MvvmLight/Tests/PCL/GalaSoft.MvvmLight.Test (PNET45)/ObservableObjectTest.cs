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
    public class ObservableObjectTest
    {
        [TestMethod]
        public void RaisePropertyChanged_WithString_ShouldCallRaisePropertyChangedWithStringOnly()
        {
            var testObject = new TestObservableObject();

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
            var testObject = new TestObservableObject();

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
        public void RaisePropertyChanged_WithSetAndExpression_ShouldCallRaisePropertyChangedWithStringAndWithExpression()
        {
            var testObject = new TestObservableObject();

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
        public void RaisePropertyChanged_WithSetAndString_ShouldCallRaisePropertyChangedWithStringOnly()
        {
            var testObject = new TestObservableObject();

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
    }
}
