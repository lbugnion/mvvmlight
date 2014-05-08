using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class OneTimeBindingTest
    {
        [TestMethod]
        public void TestOneTimeBindingWithStrings()
        {
            var o1 = new SimpleObject
            {
                SimpleProperty1 = "value 1"
            };
            var o2 = new SimpleObject
            {
                SimpleProperty2 = "value2"
            };

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                "SimpleProperty1",
                o2,
                "SimpleProperty2");

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneTimeBindingWithExpressions()
        {
            var o1 = new SimpleObject
            {
                SimpleProperty1 = "value 1"
            };
            var o2 = new SimpleObject
            {
                SimpleProperty2 = "value2"
            };

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                o2,
                () => o2.SimpleProperty2);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneTimeBindingWithObject()
        {
            var o1 = new SimpleObject
            {
                ObjectProperty1 = new SimpleObject
                {
                    SimpleProperty1 = "value 1"
                }
            };
            var o2 = new SimpleObject
            {
                ObjectProperty2 = new SimpleObject
                {
                    SimpleProperty2 = "value 2"
                }
            };

            Assert.AreNotEqual(o2.ObjectProperty2, o1.ObjectProperty1);

            var binding = new Binding<SimpleObject>(
                o1,
                () => o1.ObjectProperty1,
                o2,
                () => o2.ObjectProperty2);

            Assert.AreEqual(o2.ObjectProperty2.SimpleProperty1, o1.ObjectProperty1.SimpleProperty1);
            Assert.AreEqual(o2.ObjectProperty2, o1.ObjectProperty1);

            o1.ObjectProperty1 = new SimpleObject
            {
                SimpleProperty1 = "new value"
            };

            Assert.AreNotEqual(o2.ObjectProperty2.SimpleProperty1, o1.ObjectProperty1.SimpleProperty1);
            Assert.AreNotEqual(o2.ObjectProperty2, o1.ObjectProperty1);
        }

        [TestMethod]
        public void TestOneTimeBindingForObservable()
        {
            var o1 = new ObservableObject
            {
                SimpleProperty1 = "value 1"
            };
            var o2 = new ObservableObject
            {
                SimpleProperty2 = "value2"
            };

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                o2,
                () => o2.SimpleProperty2,
                BindingMode.OneTime);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }
    }
}
