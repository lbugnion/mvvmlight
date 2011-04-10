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
    public class SimpleIocTestContains
    {
        [TestMethod]
        public void TestContainsClass()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            Assert.IsFalse(SimpleIoc.Default.Contains<TestClass>());
            SimpleIoc.Default.GetInstance<TestClass>();
            Assert.IsTrue(SimpleIoc.Default.Contains<TestClass>());
        }

        [TestMethod]
        public void TestContainsInstance()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "My key";
            var instance = new TestClass();
            SimpleIoc.Default.Register(() => instance, key1);
            SimpleIoc.Default.Register<TestClass2>();

            Assert.IsTrue(SimpleIoc.Default.Contains<TestClass>());
            Assert.IsFalse(SimpleIoc.Default.Contains<TestClass2>());
            Assert.IsFalse(SimpleIoc.Default.Contains<TestClass3>());
        }

        [TestMethod]
        public void TestContainsInstanceForKey()
        {
            SimpleIoc.Default.Reset();
            const string key1 = "My key";
            const string key2 = "My key2";
            var instance = new TestClass();
            SimpleIoc.Default.Register(() => instance, key1);
            SimpleIoc.Default.Register<TestClass2>();

            Assert.IsTrue(SimpleIoc.Default.Contains<TestClass>());
            Assert.IsTrue(SimpleIoc.Default.Contains<TestClass>(key1));
            Assert.IsFalse(SimpleIoc.Default.Contains<TestClass>(key2));

            Assert.IsFalse(SimpleIoc.Default.Contains<TestClass2>(key1));
            Assert.IsFalse(SimpleIoc.Default.Contains<TestClass3>(key1));
        }
    }
}
