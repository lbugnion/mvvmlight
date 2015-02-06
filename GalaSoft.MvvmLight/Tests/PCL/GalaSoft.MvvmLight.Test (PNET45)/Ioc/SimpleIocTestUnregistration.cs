using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;
using Microsoft.Practices.ServiceLocation;

#if NEWUNITTEST
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
            SimpleIoc.Default.Register<TestClass1>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.IsNotNull(instance1);

            SimpleIoc.Default.Unregister<TestClass1>();

            try
            {
                SimpleIoc.Default.GetInstance<TestClass1>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestUnregisterInstance()
        {
            var instanceOriginal1 = new TestClass1();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instanceOriginal1, instance1);

            SimpleIoc.Default.Unregister(instanceOriginal1);

            try
            {
                var instance2 = SimpleIoc.Default.GetInstance<TestClass1>();
                Assert.AreSame(instance1, instance2);
            }
            catch (ActivationException)
            {
                Assert.Fail("ActivationException was thrown");
            }
        }

        [TestMethod]
        public void TestUnregisterInstanceWithKey()
        {
            var instanceOriginal1 = new TestClass1();
            var instanceOriginal2 = new TestClass1();
            const string key1 = "My key 1";
            const string key2 = "My key 2";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1, key1);
            SimpleIoc.Default.Register(() => instanceOriginal2, key2);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>(key1);
            Assert.AreSame(instanceOriginal1, instance1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass1>(key2);
            Assert.AreSame(instanceOriginal2, instance2);

            SimpleIoc.Default.Unregister<TestClass1>(key1);

            try
            {
                SimpleIoc.Default.GetInstance<TestClass1>(key1);
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

            SimpleIoc.Default.Register<ITestClass, TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());

            SimpleIoc.Default.Unregister<ITestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());

            SimpleIoc.Default.Register<ITestClass, TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());
        }

        public void TestUnregisterInstanceAndGetNewInstance()
        {
            SimpleIoc.Default.Reset();

            SimpleIoc.Default.Register<TestClass1>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>();
            SimpleIoc.Default.Unregister(instance1);

            var instance2 = SimpleIoc.Default.GetInstance<TestClass1>();

            Assert.AreNotEqual(instance1.Identifier, instance2.Identifier);
        }

        [TestMethod]
        public void TestUnregisterFactoryInstance()
        {
            SimpleIoc.Default.Reset();

            var instance0 = new TestClass1();

            SimpleIoc.Default.Register(() => instance0);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instance0, instance1);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance2 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instance0, instance2);

            SimpleIoc.Default.Unregister(instance0);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance3 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instance0, instance3);
        }

        [TestMethod]
        public void TestUnregisterDefaultInstance()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>();

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance2 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instance1, instance2);

            SimpleIoc.Default.Unregister(instance1);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance3 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreNotSame(instance1, instance3);
        }

        [TestMethod]
        public void TestUnregisterKeyedInstance()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            const string key = "key1";
            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>(key);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance2 = SimpleIoc.Default.GetInstance<TestClass1>(key);
            Assert.AreSame(instance1, instance2);

            SimpleIoc.Default.Unregister(instance1);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance3 = SimpleIoc.Default.GetInstance<TestClass1>(key);
            Assert.AreNotSame(instance1, instance3);
        }
    }
}