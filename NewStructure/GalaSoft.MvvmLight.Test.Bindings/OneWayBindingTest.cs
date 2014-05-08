using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class OneWayBindingTest
    {
        [TestMethod]
        public void TestOneWayBindingForSimpleObject()
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
                () => o2.SimpleProperty2,
                BindingMode.OneWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneWayBindingForSimpleSameObject()
        {
            var o1 = new SimpleObject
            {
                SimpleProperty1 = "value 1"
            };

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                () => o1.SimpleProperty2,
                BindingMode.OneWay);

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestDefaultBindingForObservable()
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
                () => o2.SimpleProperty2);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestDefaultBindingForSameObservable()
        {
            var o1 = new ObservableObject
            {
                SimpleProperty1 = "value 1"
            };

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                () => o1.SimpleProperty2);

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneWayBindingForObservable()
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
                BindingMode.OneWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneWayBindingForSameObservable()
        {
            var o1 = new ObservableObject
            {
                SimpleProperty1 = "value 1"
            };

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                () => o1.SimpleProperty2,
                BindingMode.OneWay);

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);
        }
    }
}
