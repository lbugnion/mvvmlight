using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;

#if NEWUNITTEST
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

            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>());
            SimpleIoc.Default.Register<TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());

            SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());

            SimpleIoc.Default.Unregister<TestClass1>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>());
        }

        [TestMethod]
        public void TestIsClassRegisteredWithFactory()
        {
            SimpleIoc.Default.Reset();

            var instance = new TestClass1();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>());
            SimpleIoc.Default.Register(() => instance);
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());

            SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());

            SimpleIoc.Default.Unregister<TestClass1>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>());
        }

        [TestMethod]
        public void TestIsClassRegisteredWithFactoryAndKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "My key 1";
            const string key2 = "My key 2";

            var instance = new TestClass1();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>(key2));

            SimpleIoc.Default.Register(() => instance, key1);
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>(key2));

            SimpleIoc.Default.GetInstance<TestClass1>(key1);
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>(key1));

            SimpleIoc.Default.Unregister<TestClass1>(key1);
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass1>(key2));
        }

        [TestMethod]
        public void TestIsInterfaceRegistered()
        {
            SimpleIoc.Default.Reset();

            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());
            SimpleIoc.Default.Register<ITestClass, TestClass1>();
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

            SimpleIoc.Default.Register<ITestClass, TestClass1>();

            // Previous versions of SimpleIoc would throw an exception. Instead
            // new versions just ignore and continue. This fixes issues with Expression Blend,
            // for instance.
            SimpleIoc.Default.Register<ITestClass, TestClass1>();
        }
    }
}