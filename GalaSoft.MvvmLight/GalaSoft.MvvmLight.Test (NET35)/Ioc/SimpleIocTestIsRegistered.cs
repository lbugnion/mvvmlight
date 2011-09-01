using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            SimpleIoc.Default.Unregister<TestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>());
        }

        [TestMethod]
        public void TestIsInterfaceRegistered()
        {
            SimpleIoc.Default.Reset();

            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());
            SimpleIoc.Default.Register<ITestClass, TestClass>();
            Assert.IsTrue(SimpleIoc.Default.IsRegistered<ITestClass>());
            SimpleIoc.Default.Unregister<ITestClass>();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<ITestClass>());
        }

        [TestMethod]
        public void TestIsClassRegisteredWithFactory()
        {
            SimpleIoc.Default.Reset();

            var instance = new TestClass();
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>());
            SimpleIoc.Default.Register(() => instance);
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
            SimpleIoc.Default.Unregister<TestClass>(key1);
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.IsRegistered<TestClass>(key2));
        }
    }
}
