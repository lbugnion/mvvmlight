using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Ioc
{
    [TestClass]
    public class SimpleIocTestContains
    {
        [TestMethod]
        public void TestContainsClass()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass>());
            SimpleIoc.Default.GetInstance<TestClass>();
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass>());
        }

        [TestMethod]
        public void TestContainsInstance()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "My key";
            var instance = new TestClass();
            SimpleIoc.Default.Register(() => instance, key1);
            SimpleIoc.Default.Register<TestClass2>();

            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass2>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass3>());

            SimpleIoc.Default.GetInstance<TestClass>(key1);

            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass2>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass3>());

            SimpleIoc.Default.GetInstance<TestClass2>();

            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass>());
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass2>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass3>());
        }

        [TestMethod]
        public void TestContainsInstanceForKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "My key";
            const string key2 = "My key2";
            var instance = new TestClass();
            SimpleIoc.Default.Register(() => instance, key1);
            SimpleIoc.Default.Register<TestClass2>();

            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass>(key2));

            SimpleIoc.Default.GetInstance<TestClass>(key1);

            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass>());
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass>(key2));
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass2>(key1));
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass3>(key1));
        }
    }
}