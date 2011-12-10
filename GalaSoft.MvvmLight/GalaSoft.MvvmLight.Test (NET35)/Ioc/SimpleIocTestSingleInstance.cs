using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;
using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Ioc
{
    [TestClass]
    public class SimpleIocTestSingleInstance
    {
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
        public void TestGetInstanceWithGenericType()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            var instance = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(TestClass));
        }

        [TestMethod]
        public void TestGetInstanceWithInterface()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);

            var instance = SimpleIoc.Default.GetInstance(typeof(ITestClass));

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(TestClass));
            Assert.AreSame(instanceOriginal, instance);
        }

        [TestMethod]
        public void TestGetInstanceWithGenericInterface()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.IsNotNull(instance);
            Assert.IsInstanceOfType(instance, typeof(TestClass));
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
            Assert.IsInstanceOfType(instance, typeof(TestClass3));

            Assert.IsNotNull(instance.SavedProperty);
            Assert.AreSame(instance.SavedProperty, property);
        }

        [TestMethod]
        public void TestOverwriteForInterface()
        {
            SimpleIoc.Default.Reset();

            SimpleIoc.Default.Register<ITestClass, TestClass>();
            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            SimpleIoc.Default.Register<ITestClass, TestClass>();
            var instance2 = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreSame(instance2, instance);

            SimpleIoc.Default.Register<ITestClass, TestClass4>();
            var instance3 = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreNotSame(instance2, instance3);
        }

        [TestMethod]
        public void TestOverwriteForClass()
        {
            SimpleIoc.Default.Reset();

            SimpleIoc.Default.Register<TestClass>();
            var instance = SimpleIoc.Default.GetInstance<TestClass>();

            SimpleIoc.Default.Register<TestClass>();
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreSame(instance2, instance);
        }

        [TestMethod]
        public void TestOverwriteForInstance()
        {
            SimpleIoc.Default.Reset();

            var instanceOriginal = new TestClass();

            SimpleIoc.Default.Register(() => instanceOriginal);
            var instance = SimpleIoc.Default.GetInstance<TestClass>();

            SimpleIoc.Default.Register(() => instanceOriginal);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreSame(instance2, instance);

            var instanceOriginal2 = new TestClass();
            SimpleIoc.Default.Register(() => instanceOriginal2);
            var instance3 = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreNotSame(instance3, instance);
        }

        [TestMethod]
        public void TestOverwriteMixed()
        {
            SimpleIoc.Default.Reset();

            var instanceOriginal1 = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal1);
            var instance1 = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreSame(instanceOriginal1, instance1);

            SimpleIoc.Default.Register<TestClass>();
            var instance2 = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreSame(instanceOriginal1, instance2);

            var instanceOriginal2 = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal2);
            var instance3 = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreSame(instanceOriginal2, instance3);
            Assert.AreNotSame(instanceOriginal1, instance3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRegisterInterfaceOnly()
        {
            SimpleIoc.Default.Register<ITestClass>();
        }

        [TestMethod]
        [ExpectedException(typeof(ActivationException))]
        public void TestGetInstanceWithMultiConstructors()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClassWithMultiConstructors>();
            var instance = SimpleIoc.Default.GetInstance<TestClassWithMultiConstructors>();
        }

        [TestMethod]
        [ExpectedException(typeof(ActivationException))]
        public void TestGetInstanceWithUnregisteredClass()
        {
            SimpleIoc.Default.Reset();
            var instance = SimpleIoc.Default.GetInstance<SimpleIocTestSingleInstance>();
        }

        [TestMethod]
        [ExpectedException(typeof(ActivationException))]
        public void TestReset()
        {
            SimpleIoc.Default.Reset();
            var instanceOriginal = new TestClass();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal);
            var instance = SimpleIoc.Default.GetInstance<ITestClass>();
            Assert.IsNotNull(instance);

            SimpleIoc.Default.Register<TestClass2>();
            var instance2 = SimpleIoc.Default.GetInstance<TestClass2>();
            Assert.IsNotNull(instance2);

            SimpleIoc.Default.Reset();

            instance = SimpleIoc.Default.GetInstance<ITestClass>();
            instance2 = SimpleIoc.Default.GetInstance<TestClass2>();
        }

        [TestMethod]
        public void TestConstructWithProperty()
        {
            var property = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass6>(() => new TestClass6()
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
    }
}
