using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class MultiLevelBindingTest
    {
        public ObservableObject TopObjectAsProperty
        {
            get;
            private set;
        }

        [TestMethod]
        public void TestMultiLevelBinding()
        {
            var source = new ObservableObject
            {
                UniqueId = "topObject",
                ObjectProperty = new ObservableObject
                {
                    UniqueId = "innerObject",
                    SimpleProperty1 = "initial"
                }
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                source,
                () => source.ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty1);

            Assert.AreEqual(target.SimpleProperty1, source.ObjectProperty.SimpleProperty1);
            source.ObjectProperty.SimpleProperty1 = "abcd";
            Assert.AreEqual(target.SimpleProperty1, source.ObjectProperty.SimpleProperty1);
        }

        [TestMethod]
        public void TestMultiLevelBindingWithProperty()
        {
            TopObjectAsProperty = new ObservableObject
            {
                UniqueId = "topObject",
                ObjectProperty = new ObservableObject
                {
                    UniqueId = "innerObject",
                    SimpleProperty1 = "initial"
                }
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => TopObjectAsProperty.ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty1);

            Assert.AreEqual(target.SimpleProperty1, TopObjectAsProperty.ObjectProperty.SimpleProperty1);
            TopObjectAsProperty.ObjectProperty.SimpleProperty1 = "abcd";
            Assert.AreEqual(target.SimpleProperty1, TopObjectAsProperty.ObjectProperty.SimpleProperty1);
        }

        [TestMethod]
        public void TestMultiLevelBindingWithObjectSwap()
        {
            var source1 = new ObservableObject
            {
                UniqueId = "topObject",
                ObjectProperty = new ObservableObject
                {
                    UniqueId = "innerObject1",
                    SimpleProperty1 = "initial"
                }
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                source1,
                () => source1.ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, source1.ObjectProperty.SimpleProperty1);

            var source2 = new ObservableObject
            {
                UniqueId = "innerObject2",
                SimpleProperty1 = "new"
            };

            source1.ObjectProperty = source2;

            Assert.AreEqual(target.SimpleProperty2, source2.SimpleProperty1);
        }

        [TestMethod]
        public void TestMultiLevelBindingWithObjectCreation()
        {
            var source1 = new ObservableObject
            {
                UniqueId = "topObject"
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                source1,
                () => source1.ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, null);

            source1.ObjectProperty = new ObservableObject
            {
                UniqueId = "innerObject",
                SimpleProperty1 = "new"
            };;

            Assert.AreEqual(target.SimpleProperty2, source1.ObjectProperty.SimpleProperty1);
            source1.ObjectProperty.SimpleProperty1 = "another";
            Assert.AreEqual(target.SimpleProperty2, source1.ObjectProperty.SimpleProperty1);
        }

        [TestMethod]
        public void TestDeepLevelBindingWithObjectCreation()
        {
            var source1 = new ObservableObject
            {
                UniqueId = "topObject"
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                source1,
                () => source1.ObjectProperty.ObjectProperty.ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, null);

            source1.ObjectProperty = new ObservableObject
            {
                UniqueId = "innerObject1",
            }; ;

            Assert.AreEqual(target.SimpleProperty2, null);

            source1.ObjectProperty.ObjectProperty = new ObservableObject
            {
                UniqueId = "innerObject2",
            }; ;

            Assert.AreEqual(target.SimpleProperty2, null);

            source1.ObjectProperty.ObjectProperty.ObjectProperty = new ObservableObject
            {
                SimpleProperty1 = "hello",
                UniqueId = "innerObject2",
            }; ;

            Assert.AreEqual(target.SimpleProperty2, source1.ObjectProperty.ObjectProperty.ObjectProperty.SimpleProperty1);
            source1.ObjectProperty.ObjectProperty.ObjectProperty.SimpleProperty1 = "world";
            Assert.AreEqual(target.SimpleProperty2, source1.ObjectProperty.ObjectProperty.ObjectProperty.SimpleProperty1);
        }

        [TestMethod]
        public void TestBindingWithEventWithObjectSwapping()
        {
            var source = new ObservableObject
            {
                UiElement = new UiElementFake
                {
                    SimpleProperty1 = "Initial value"
                }
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                source,
                () => source.UiElement.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            binding.SetSourceEvent("SimpleEvent");

            Assert.AreEqual(target.SimpleProperty2, source.UiElement.SimpleProperty1);

            source.UiElement = new UiElementFake
            {
                SimpleProperty1 = "New value"
            };

            Assert.AreEqual(target.SimpleProperty2, source.UiElement.SimpleProperty1);

            var oldValue = source.UiElement.SimpleProperty1;
            source.UiElement.SimpleProperty1 = "Third value";

            Assert.AreEqual(oldValue, target.SimpleProperty2);

            source.UiElement.RaiseSimpleEvent();

            Assert.AreEqual(target.SimpleProperty2, source.UiElement.SimpleProperty1);
        }

        [TestMethod]
        public void TestBindingWithEventArgsWithObjectSwapping()
        {
            var source = new ObservableObject
            {
                UiElement = new UiElementFake
                {
                    SimpleProperty1 = "Initial value"
                }
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                source,
                () => source.UiElement.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            binding.SetSourceEvent<UiElementFakeEventArgs>("EventArgsEvent");

            Assert.AreEqual(target.SimpleProperty2, source.UiElement.SimpleProperty1);

            source.UiElement = new UiElementFake
            {
                SimpleProperty1 = "New value"
            };

            Assert.AreEqual(target.SimpleProperty2, source.UiElement.SimpleProperty1);

            var oldValue = source.UiElement.SimpleProperty1;
            source.UiElement.SimpleProperty1 = "Third value";

            Assert.AreEqual(oldValue, target.SimpleProperty2);

            source.UiElement.RaiseEventArgsEvent();

            Assert.AreEqual(target.SimpleProperty2, source.UiElement.SimpleProperty1);
        }

        [TestMethod]
        public void TestTwoWayBindingWithEventWithObjectSwapping()
        {
            var source = new ObservableObject
            {
                UiElement = new UiElementFake
                {
                    SimpleProperty1 = "Initial value"
                }
            };

            var target = new ObservableObject
            {
                UiElement = new UiElementFake()
            };

            var binding = new Binding<string>(
                source,
                () => source.UiElement.SimpleProperty1,
                target,
                () => target.UiElement.SimpleProperty2,
                BindingMode.TwoWay);

            binding.SetTargetEvent("SimpleEvent");

            Assert.AreEqual(target.UiElement.SimpleProperty2, source.UiElement.SimpleProperty1);

            target.UiElement = new UiElementFake
            {
                SimpleProperty1 = "New value"
            };

            Assert.AreEqual(source.UiElement.SimpleProperty1, target.UiElement.SimpleProperty2);

            var oldValue = target.UiElement.SimpleProperty2;
            target.UiElement.SimpleProperty2 = "Third value";

            Assert.AreEqual(oldValue, source.UiElement.SimpleProperty1);

            target.UiElement.RaiseSimpleEvent();

            Assert.AreEqual(source.UiElement.SimpleProperty1, target.UiElement.SimpleProperty2);
        }

        [TestMethod]
        public void TestTwoWayBindingWithEventArgsWithObjectSwapping()
        {
            var source = new ObservableObject
            {
                UiElement = new UiElementFake
                {
                    SimpleProperty1 = "Initial value"
                }
            };

            var target = new ObservableObject
            {
                UiElement = new UiElementFake()
            };

            var binding = new Binding<string>(
                source,
                () => source.UiElement.SimpleProperty1,
                target,
                () => target.UiElement.SimpleProperty2,
                BindingMode.TwoWay);

            binding.SetTargetEvent<UiElementFakeEventArgs>("EventArgsEvent");

            Assert.AreEqual(target.UiElement.SimpleProperty2, source.UiElement.SimpleProperty1);

            target.UiElement = new UiElementFake
            {
                SimpleProperty1 = "New value"
            };

            Assert.AreEqual(source.UiElement.SimpleProperty1, target.UiElement.SimpleProperty2);

            var oldValue = target.UiElement.SimpleProperty2;
            target.UiElement.SimpleProperty2 = "Third value";

            Assert.AreEqual(oldValue, source.UiElement.SimpleProperty1);

            target.UiElement.RaiseEventArgsEvent();

            Assert.AreEqual(source.UiElement.SimpleProperty1, target.UiElement.SimpleProperty2);
        }
    }
}
