using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class TwoWayBindingTest
    {
        [TestMethod]
        public void TestTwoWayBindingForSimpleObjects()
        {
            var o1 = new SimpleObject
            {
                SimpleProperty1 = "value 1"
            };

            var o2 = new SimpleObject
            {
                SimpleProperty2 = "value 2"
            };

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                o2,
                () => o2.SimpleProperty2,
                BindingMode.TwoWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value 1";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestDefaultBindingForOneSimpleAndOneObservable()
        {
            var o1 = new ObservableObject
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
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;
            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWayBindingForOneObservableAndOneSimple()
        {
            var o1 = new ObservableObject
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
                BindingMode.TwoWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;
            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestDefaultBindingForTwoObservables()
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

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;
            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWayBindingForTwoObservables()
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
                BindingMode.TwoWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWayBindingForOneSimpleAndOneObservable()
        {
            var o1 = new SimpleObject
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
                BindingMode.TwoWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;
            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }
    }
}
