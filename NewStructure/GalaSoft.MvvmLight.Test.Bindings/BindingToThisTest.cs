using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class BindingToThisTest
    {
        public ObservableObject ObjectProperty
        {
            get;
            private set;
        }

        public string SimpleProperty
        {
            get;
            private set;
        }

        public SimpleObject TargetSimpleObject
        {
            get;
            private set;
        }

        [TestMethod]
        public void TestBindingToThis()
        {
            SimpleProperty = "TestBindingToThis";
            
            var target = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => SimpleProperty,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, SimpleProperty);
        }

        [TestMethod]
        public void TestBindingToSameThis()
        {
            SimpleProperty = "TestBindingToThis";

            TargetSimpleObject = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => SimpleProperty,
                () => TargetSimpleObject.SimpleProperty2);

            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, SimpleProperty);
        }

        [TestMethod]
        public void TestBindingToThisObjectProperty()
        {
            ObjectProperty = new ObservableObject
            {
                SimpleProperty1 = "TestBindingToThisProperty"
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, ObjectProperty.SimpleProperty1);
        }

        [TestMethod]
        public void TestBindingToSameThisObjectProperty()
        {
            ObjectProperty = new ObservableObject
            {
                SimpleProperty1 = "TestBindingToThisProperty"
            };

            TargetSimpleObject = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => ObjectProperty.SimpleProperty1,
                () => TargetSimpleObject.SimpleProperty2);

            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, ObjectProperty.SimpleProperty1);
        }
    }
}
