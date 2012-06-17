using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;
using Microsoft.Practices.ServiceLocation;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Ioc
{
    [TestClass]
    public class SimpleIocTestUnregistration
    {
        [TestMethod]
        public void TestUnregisterClass()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.IsNotNull(instance1);

            SimpleIoc.Default.Unregister<TestClass>();

            try
            {
                SimpleIoc.Default.GetInstance<TestClass>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestUnregisterInstance()
        {
            var instanceOriginal1 = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.AreSame(instanceOriginal1, instance1);

            SimpleIoc.Default.Unregister(instanceOriginal1);

            try
            {
                SimpleIoc.Default.GetInstance<TestClass>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestUnregisterInstanceWithKey()
        {
            var instanceOriginal1 = new TestClass();
            var instanceOriginal2 = new TestClass();
            const string key1 = "My key 1";
            const string key2 = "My key 2";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1, key1);
            SimpleIoc.Default.Register(() => instanceOriginal2, key2);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            Assert.AreSame(instanceOriginal1, instance1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key2);
            Assert.AreSame(instanceOriginal2, instance2);

            SimpleIoc.Default.Unregister<TestClass>(key1);

            try
            {
                SimpleIoc.Default.GetInstance<TestClass>(key1);
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestUnregisterAndImmediateRegisterWithInterface()
        {
            SimpleIoc.Default.Reset();

            SimpleIoc.Default.Register<ITestClass, TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());

            SimpleIoc.Default.Unregister<ITestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());

            SimpleIoc.Default.Register<ITestClass, TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());
        }
    }
}