using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class BindingWithEventTest
    {
        [TestMethod]
        public void TestOneWayBindingWithEvent()
        {
            var o1 = new UiElementFake
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
                BindingMode.OneWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            binding.SetSourceEvent(
                "SimpleEvent");

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            o1.RaiseSimpleEvent();

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneWaySameBindingWithEvent()
        {
            var o1 = new UiElementFake
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

            binding.SetSourceEvent(
                "SimpleEvent");

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            o1.RaiseSimpleEvent();

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);
        }
        
        [TestMethod]
        public void TestTwoWayBindingWithEvent()
        {
            var o1 = new UiElementFake
            {
                SimpleProperty1 = "value 1"
            };

            var o2 = new UiElementFake
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

            binding
                .SetSourceEvent("SimpleEvent")
                .SetTargetEvent("SimpleEvent");

            const string newValue1 = "New value 1";
            o1.SimpleProperty1 = newValue1;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
            o1.RaiseSimpleEvent();
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
            o2.RaiseSimpleEvent();
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWaySameBindingWithEvent()
        {
            var o1 = new UiElementFake
            {
                SimpleProperty1 = "value 1"
            };

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                () => o1.SimpleProperty2,
                BindingMode.TwoWay);

            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            binding
                .SetSourceEvent("SimpleEvent")
                .SetTargetEvent("SimpleEvent");

            const string newValue1 = "New value 1";
            o1.SimpleProperty1 = newValue1;

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);
            o1.RaiseSimpleEvent();
            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o1.SimpleProperty2 = newValue2;

            Assert.AreNotEqual(o1.SimpleProperty2, o1.SimpleProperty1);
            o1.RaiseSimpleEvent();
            Assert.AreEqual(o1.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWayMultiLevelBindingWithEvent()
        {
            var o1 = new ObservableObject
            {
                UiElement = new UiElementFake
                {
                    SimpleProperty1 = "value 1"
                }
            };

            var o2 = new ObservableObject
            {
                UiElement = new UiElementFake
                {
                    SimpleProperty2 = "value 2"
                }
            };

            Assert.AreNotEqual(o2.UiElement.SimpleProperty2, o1.UiElement.SimpleProperty1);

            var binding = new Binding<string>(
                o1,
                () => o1.UiElement.SimpleProperty1,
                o2,
                () => o2.UiElement.SimpleProperty2,
                BindingMode.TwoWay);

            Assert.AreEqual(o2.UiElement.SimpleProperty2, o1.UiElement.SimpleProperty1);

            binding
                .SetSourceEvent("SimpleEvent")
                .SetTargetEvent("SimpleEvent");

            const string newValue1 = "New value 1";
            o1.UiElement.SimpleProperty1 = newValue1;

            Assert.AreNotEqual(o2.UiElement.SimpleProperty2, o1.UiElement.SimpleProperty1);
            o1.UiElement.RaiseSimpleEvent();
            Assert.AreEqual(o2.UiElement.SimpleProperty2, o1.UiElement.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.UiElement.SimpleProperty2 = newValue2;

            Assert.AreNotEqual(o2.UiElement.SimpleProperty2, o1.UiElement.SimpleProperty1);
            o2.UiElement.RaiseSimpleEvent();
            Assert.AreEqual(o2.UiElement.SimpleProperty2, o1.UiElement.SimpleProperty1);
        }

        [TestMethod]
        public void TestOneWayBindingWithEventArgs()
        {
            var o1 = new UiElementFake
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
                BindingMode.OneWay);

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            binding.SetSourceEvent<UiElementFakeEventArgs>(
                "EventArgsEvent");

            const string newValue = "New value";
            o1.SimpleProperty1 = newValue;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            o1.RaiseEventArgsEvent();

            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWayBindingWithEventArgs()
        {
            var o1 = new UiElementFake
            {
                SimpleProperty1 = "value 1"
            };

            var o2 = new UiElementFake
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

            binding
                .SetSourceEvent<UiElementFakeEventArgs>("EventArgsEvent")
                .SetTargetEvent<UiElementFakeEventArgs>("EventArgsEvent");

            const string newValue1 = "New value 1";
            o1.SimpleProperty1 = newValue1;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
            o1.RaiseEventArgsEvent();
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);

            const string newValue2 = "New value 2";
            o2.SimpleProperty2 = newValue2;

            Assert.AreNotEqual(o2.SimpleProperty2, o1.SimpleProperty1);
            o2.RaiseEventArgsEvent();
            Assert.AreEqual(o2.SimpleProperty2, o1.SimpleProperty1);
        }
    }
}