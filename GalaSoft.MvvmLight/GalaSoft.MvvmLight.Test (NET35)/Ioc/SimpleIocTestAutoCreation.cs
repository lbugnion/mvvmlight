using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Ioc
{
    [TestClass]
    public class SimpleIocTestAutoCreation
    {
        [TestMethod]
        public void TestAutoCreationWithDefaultClass()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>(true);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactory()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(
                () => new TestClass(),
                true);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactoryAndKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "key1";
            SimpleIoc.Default.Register(
                () => new TestClass(),
                key1,
                true);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<TestClass>(key1);
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestAutoCreationWithFactoryForInterface()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(
                () => new TestClass(),
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
                () => new TestClass(),
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
            SimpleIoc.Default.Register<ITestClass, TestClass>(true);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreEqual(1, instances.Count());

            var defaultInstance = SimpleIoc.Default.GetInstance<ITestClass>();
            Assert.AreSame(defaultInstance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithDefaultClass()
        {
            SimpleIoc.Default.Reset();

            TestClass.Reset();

            SimpleIoc.Default.Register<TestClass>();
            Assert.AreEqual(0, TestClass.InstancesCount);

            SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreEqual(1, TestClass.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass>();

            var instance = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactory()
        {
            SimpleIoc.Default.Reset();
            TestClass.Reset();
            SimpleIoc.Default.Register(() => new TestClass());

            Assert.AreEqual(0, TestClass.InstancesCount);

            SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreEqual(1, TestClass.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass>();

            var instance = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactoryAndKey()
        {
            SimpleIoc.Default.Reset();
            TestClass.Reset();

            const string key1 = "key1";
            SimpleIoc.Default.Register(
                () => new TestClass(),
                key1);

            Assert.AreEqual(0, TestClass.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<TestClass>(key1);

            Assert.AreEqual(1, TestClass.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<TestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactoryForInterface()
        {
            SimpleIoc.Default.Reset();
            TestClass.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => new TestClass());

            Assert.AreEqual(0, TestClass.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreEqual(1, TestClass.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithFactoryForInterfaceAndKey()
        {
            SimpleIoc.Default.Reset();
            TestClass.Reset();

            const string key1 = "key1";
            SimpleIoc.Default.Register<ITestClass>(
                () => new TestClass(),
                key1);

            Assert.AreEqual(0, TestClass.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>(key1);

            Assert.AreEqual(1, TestClass.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }

        [TestMethod]
        public void TestDelayedCreationWithInterface()
        {
            SimpleIoc.Default.Reset();
            TestClass.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();

            Assert.AreEqual(0, TestClass.InstancesCount);

            var instance = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.AreEqual(1, TestClass.InstancesCount);

            var instances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreSame(instance, instances.ElementAt(0));
        }
    }
}