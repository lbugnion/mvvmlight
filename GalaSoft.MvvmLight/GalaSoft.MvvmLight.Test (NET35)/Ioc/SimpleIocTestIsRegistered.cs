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
    public class SimpleIocTestIsRegistered
    {
        [TestMethod]
        public void TestIsClassRegistered()
        {
            SimpleIoc.Default.Reset();

            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>());
            SimpleIoc.Default.Register<TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass>());

            SimpleIoc.Default.GetInstance<TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass>());

            SimpleIoc.Default.Unregister<TestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>());
        }

        [TestMethod]
        public void TestIsClassRegisteredWithFactory()
        {
            SimpleIoc.Default.Reset();

            var instance = new TestClass();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>());
            SimpleIoc.Default.Register(() => instance);
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass>());

            SimpleIoc.Default.GetInstance<TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass>());

            SimpleIoc.Default.Unregister<TestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>());
        }

        [TestMethod]
        public void TestIsClassRegisteredWithFactoryAndKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "My key 1";
            const string key2 = "My key 2";

            var instance = new TestClass();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key2));

            SimpleIoc.Default.Register(() => instance, key1);
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key2));

            SimpleIoc.Default.GetInstance<TestClass>(key1);
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass>(key1));

            SimpleIoc.Default.Unregister<TestClass>(key1);
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key2));
        }

        [TestMethod]
        public void TestIsInterfaceRegistered()
        {
            SimpleIoc.Default.Reset();

            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());
            SimpleIoc.Default.Register<ITestClass, TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());

            SimpleIoc.Default.GetInstance<ITestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());

            SimpleIoc.Default.Unregister<ITestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());
        }

        [TestMethod]
        public void TestIsRegisteredThenContinue()
        {
            SimpleIoc.Default.Reset();

            SimpleIoc.Default.Register<ITestClass, TestClass>();

            // Previous versions of SimpleIoc would throw an exception. Instead
            // new versions just ignore and continue. This fixes issues with Expression Blend,
            // for instance.
            SimpleIoc.Default.Register<ITestClass, TestClass>();
        }
    }
}