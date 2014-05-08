using System.Linq;
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
    public class SimpleIocTestAutoCreation
    {
        [TestMethod]
        public void TestAutoCreationWithDefaultClass()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass1>(true);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass1>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactory()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(
                () => new TestClass1(),
                true);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass1>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactoryAndKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "key1";
            SimpleIoc.Default.Register(
                () => new TestClass1(),
                key1,
                true);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass1>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<TestClass1>(key1);
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactoryForInterface()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(
                () => new TestClass1(),
                true);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<ITestClass>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactoryForInterfaceAndKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "key1";
            SimpleIoc.Default.Register<ITestClass>(
                () => new TestClass1(),
                key1,
                true);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithInterface()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass1>(true);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<ITestClass>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithDefaultClass()
        {
            SimpleIoc.Default.Reset();

            TestClass1.Reset();

            SimpleIoc.Default.Register<TestClass1>();
            Assert.AreEqual(0, TestClass1.InstancesCount);

            SimpleIoc.Default.GetInstance<TestClass1>();

            Assert.AreEqual(1, TestClass1.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass1>();

            var instance = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactory()
        {
            SimpleIoc.Default.Reset();
            TestClass1.Reset();
            SimpleIoc.Default.Register(() => new TestClass1());

            Assert.AreEqual(0, TestClass1.InstancesCount);

            SimpleIoc.Default.GetInstance<TestClass1>();

            Assert.AreEqual(1, TestClass1.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass1>();

            var instance = SimpleIoc.Default.GetInstance<TestClass1>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactoryAndKey()
        {
            SimpleIoc.Default.Reset();
            TestClass1.Reset();

            const string key1 = "key1";
            SimpleIoc.Default.Register(
                () => new TestClass1(),
                key1);

            Assert.AreEqual(0, TestClass1.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<TestClass1>(key1);

            Assert.AreEqual(1, TestClass1.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass1>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactoryForInterface()
        {
            SimpleIoc.Default.Reset();
            TestClass1.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => new TestClass1());

            Assert.AreEqual(0, TestClass1.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreEqual(1, TestClass1.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactoryForInterfaceAndKey()
        {
            SimpleIoc.Default.Reset();
            TestClass1.Reset();

            const string key1 = "key1";
            SimpleIoc.Default.Register<ITestClass>(
                () => new TestClass1(),
                key1);

            Assert.AreEqual(0, TestClass1.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>(key1);

            Assert.AreEqual(1, TestClass1.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithInterface()
        {
            SimpleIoc.Default.Reset();
            TestClass1.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass1>();

            Assert.AreEqual(0, TestClass1.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreEqual(1, TestClass1.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }
    }
}