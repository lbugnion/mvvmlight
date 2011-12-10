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
    public class SimpleIocTestUnregistration
    {
        [TestMethod]
        public void TestUnregisterInstance()
        {
            var instanceOriginal1 = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.AreSame(instanceOriginal1, instance1);

            SimpleIoc.Default.Unregister(instanceOriginal1);

            var instance2 = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreNotSame(instanceOriginal1, instance2);
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

            var instance3 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            Assert.AreNotSame(instanceOriginal1, instance3);

            var instance4 = SimpleIoc.Default.GetInstance<TestClass>(key2);
            Assert.AreSame(instanceOriginal2, instance4);
        }

        [TestMethod]
        [ExpectedException(typeof(ActivationException))]
        public void TestUnregisterClass()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>();
            Assert.IsNotNull(instance1);

            SimpleIoc.Default.Unregister<TestClass>();
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>();
        }
    }
}
