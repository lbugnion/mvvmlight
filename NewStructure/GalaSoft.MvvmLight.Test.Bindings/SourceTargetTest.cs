using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class SourceTargetTest
    {
        [TestMethod]
        public void TestSource()
        {
            var o1 = new ObservableObject
            {
                UniqueId = "topObject"
            };

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1);

            Assert.AreEqual(o1, binding.Source);
        }

        [TestMethod]
        public void TestTarget()
        {
            var o1 = new ObservableObject
            {
                UniqueId = "topObject"
            };

            var o2 = new ObservableObject
            {
                UniqueId = "topTarget"
            };

            var binding = new Binding<string>(
                o1,
                () => o1.SimpleProperty1,
                o2,
                () => o2.SimpleProperty2);

            Assert.AreEqual(o1, binding.Source);
            Assert.AreEqual(o2, binding.Target);
        }

        [TestMethod]
        public void TestSourceWithMultiLevel()
        {
            var o1 = new ObservableObject
            {
                UniqueId = "topObject"
            };

            var binding = new Binding<string>(
                o1,
                () => o1.ObjectProperty.SimpleProperty1);

            Assert.AreEqual(o1, binding.Source);
        }

        [TestMethod]
        public void TestTargetWithMultiLevel()
        {
            var o1 = new ObservableObject
            {
                UniqueId = "topObject"
            };

            var o2 = new ObservableObject
            {
                UniqueId = "topTarget"
            };

            var binding = new Binding<string>(
                o1,
                () => o1.ObjectProperty.SimpleProperty1,
                o2,
                () => o2.ObjectProperty.SimpleProperty2);

            Assert.AreEqual(o1, binding.Source);
            Assert.AreEqual(o2, binding.Target);
        }
    }
}
