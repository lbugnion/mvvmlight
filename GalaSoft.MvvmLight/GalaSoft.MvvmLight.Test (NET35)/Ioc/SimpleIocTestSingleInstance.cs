using System;
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
    public class SimpleIocTestSingleInstance
    {
        [TestMethod]
        public void TestConstructWithProperty()
        {
            var property = new TestClass();

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

            SimpleIoc.Default.Register<TestClass>();
            SimpleIoc.Default.Register<TestClass2>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>();
            var instance2 = SimpleIoc.Default.GetInstance<TestClass2>();

            Assert.IsInstanceOfType(instance1, typeof (TestClass));
            Assert.IsNotNull(instance1);
            Assert.IsInstanceOfType(instance2, typeof (TestClass2));
            Assert.IsNotNull(instance2);
        }

        [TestMethod]
        public void TestGetInstanceWithGenericInterface()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass));
            Assert.AreSame(instanceOriginal, instance);
        }

        [TestMethod]
        public void TestGetInstanceWithGenericType()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            var instance = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass));
        }

        [TestMethod]
        public void TestGetInstanceWithInterface()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);

            var instance = SimpleIoc.Default.GetInstance(typeof (ITestClass));

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass));
            Assert.AreSame(instanceOriginal, instance);
        }

        [TestMethod]
        public void TestGetInstanceWithParameters()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();
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
            SimpleIoc.Default.Register<TestClass>();

            var instance = SimpleIoc.Default.GetInstance(typeof (TestClass));

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof (TestClass));
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
            var instanceOriginal = new TestClass();
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
    }
}