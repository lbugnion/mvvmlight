using System;
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
    public class SimpleIocTestSingleInstance
    {
        [TestMethod]
        public void TestConstructWithProperty()
        {
            var property = new TestClass1();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(
                () => new TestClass6
                {
                    MyProperty = property
                });

            var instance1 = new TestClass6();
            Assert.IsNotNull(instance1);
            Assert.IsNull(instance1.MyProperty);

            var instance2 = SimpleIoc.Default.GetInstance<TestClass6>();
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance2.MyProperty);
            Assert.AreSame(property, instance2.MyProperty);
        }

        [TestMethod]
        public void TestDefaultClassCreation()
        {
            SimpleIoc.Default.Reset();

            SimpleIoc.Default.Register<TestClass1>();
            SimpleIoc.Default.Register<TestClass2>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass1>();
            var instance2 = SimpleIoc.Default.GetInstance<TestClass2>();

            Assert.IsInstanceOfType(instance1, typeof (TestClass1));
            Assert.IsNotNull(instance1);
            Assert.IsInstanceOfType(instance2, typeof (TestClass2));
            Assert.IsNotNull(instance2);
        }

        [TestMethod]
        public void TestGetInstanceWithGenericInterface()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass1();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass1));
            Assert.AreSame(instanceOriginal, instance);
        }

        [TestMethod]
        public void TestGetInstanceWithGenericType()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            var instance = SimpleIoc.Default.GetInstance<TestClass1>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass1));
        }

        [TestMethod]
        public void TestGetInstanceWithInterface()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass1();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);

            var instance = SimpleIoc.Default.GetInstance(typeof (ITestClass));

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass1));
            Assert.AreSame(instanceOriginal, instance);
        }

        [TestMethod]
        public void TestGetInstanceWithParameters()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass1>();
            SimpleIoc.Default.Register<TestClass3>();

            var instance = SimpleIoc.Default.GetInstance<TestClass3>();
            var property = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass3));

            Assert.IsNotNull(instance.SavedProperty);
            Assert.AreSame(instance.SavedProperty, property);
        }

        [TestMethod]
        public void TestGetInstanceWithType()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            var instance = SimpleIoc.Default.GetInstance(typeof (TestClass1));

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass1));
        }

        [TestMethod]
        public void TestGetInstanceWithUnregisteredClass()
        {
            SimpleIoc.Default.Reset();

            try
            {
                SimpleIoc.Default.GetInstance<SimpleIocTestSingleInstance>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestRegisterInstanceWithMultiConstructors()
        {
            SimpleIoc.Default.Reset();

            try
            {
                SimpleIoc.Default.Register<TestClassWithMultiConstructors>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestRegisterInterfaceOnly()
        {
            try
            {
                SimpleIoc.Default.Register<ITestClass>();
                Assert.Fail("ArgumentException was expected");
            }
            catch (ArgumentException)
            {
            }
        }

        [TestMethod]
        public void TestReset()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass1();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);
            var instance = SimpleIoc.Default.GetInstance<ITestClass>();
            Assert.IsNotNull(instance);

            SimpleIoc.Default.Reset();

            try
            {
                SimpleIoc.Default.GetInstance<ITestClass>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException)
            {
            }
        }

        [TestMethod]
        public void TestGetDefaultWithoutCaching()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            var instance1 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>();
            var instance2 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>();

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());
            Assert.AreNotSame(instance1, instance2);
        }

        [TestMethod]
        public void TestGetFromFactoryWithoutCaching()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => new TestClass1());

            var instance1 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>();
            var instance2 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>();

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());
            Assert.AreNotSame(instance1, instance2);
        }

        [TestMethod]
        public void TestGetWithKeyWithoutCaching()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            const string key = "key1";

            var instance1 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>(key);
            var instance2 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>(key);

            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());
            Assert.AreNotSame(instance1, instance2);
        }

        [TestMethod]
        public void TestMixCacheAndNoCache()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>();

            var instance1 = SimpleIoc.Default.GetInstanceWithoutCaching<TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsFalse(SimpleIoc.Default.ContainsCreated<TestClass1>());

            var instance2 = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<TestClass1>());
            Assert.IsTrue(SimpleIoc.Default.ContainsCreated<TestClass1>());
            Assert.AreNotSame(instance1, instance2);
        }
    }
}