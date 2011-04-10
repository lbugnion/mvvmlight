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
    public class SimpleIocTestMultipleInstances
    {
        [TestMethod]
        public void TestGetInstancesWithType()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance(typeof(TestClass), key1);
            var instance2 = SimpleIoc.Default.GetInstance(typeof(TestClass), key1);
            var instance3 = SimpleIoc.Default.GetInstance(typeof(TestClass), key2);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);

            Assert.IsInstanceOfType(instance1, typeof (TestClass));
            Assert.IsInstanceOfType(instance2, typeof(TestClass));
            Assert.IsInstanceOfType(instance3, typeof(TestClass));

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);
        }

        [TestMethod]
        public void TestGetInstancesWithTypeGeneric()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance3 = SimpleIoc.Default.GetInstance<TestClass>(key2);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);

            Assert.IsInstanceOfType(instance1, typeof(TestClass));
            Assert.IsInstanceOfType(instance2, typeof(TestClass));
            Assert.IsInstanceOfType(instance3, typeof(TestClass));

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);
        }

        [TestMethod]
        public void TestGetInstancesWithInterface()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key1);
            var instance2 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key1);
            var instance3 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key2);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);

            Assert.IsInstanceOfType(instance1, typeof(TestClass));
            Assert.IsInstanceOfType(instance2, typeof(TestClass));
            Assert.IsInstanceOfType(instance3, typeof(TestClass));

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);
        }

        [TestMethod]
        public void TestGetInstancesWithInterfaceGeneric()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            var instance3 = SimpleIoc.Default.GetInstance<ITestClass>(key2);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);

            Assert.IsInstanceOfType(instance1, typeof(TestClass));
            Assert.IsInstanceOfType(instance2, typeof(TestClass));
            Assert.IsInstanceOfType(instance3, typeof(TestClass));

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);
        }

        [TestMethod]
        public void TestGetInstancesWithInstance()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";

            var instanceOriginal1 = new TestClass();
            var instanceOriginal2 = new TestClass();
            var instanceOriginal3 = new TestClass4();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal1, key1);
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal2, key2);

            var instance1 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key1);
            var instance2 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key1);
            var instance3 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key2);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);

            Assert.IsInstanceOfType(instance1, typeof(TestClass));
            Assert.IsInstanceOfType(instance2, typeof(TestClass));
            Assert.IsInstanceOfType(instance3, typeof(TestClass));

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);

            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal3, key1);

            var instance4 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key1);
            Assert.IsNotNull(instance4);

            Assert.IsInstanceOfType(instance4, typeof(TestClass4));
            Assert.AreSame(instanceOriginal3, instance4);
            Assert.AreNotSame(instance1, instance4);
        }

        [TestMethod]
        public void TestGetInstancesWithInstanceGeneric()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";

            var instanceOriginal1 = new TestClass();
            var instanceOriginal2 = new TestClass();
            var instanceOriginal3 = new TestClass4();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal1, key1);
            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal2, key2);

            var instance1 = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            var instance3 = SimpleIoc.Default.GetInstance<ITestClass>(key2);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);

            Assert.IsInstanceOfType(instance1, typeof(TestClass));
            Assert.IsInstanceOfType(instance2, typeof(TestClass));
            Assert.IsInstanceOfType(instance3, typeof(TestClass));

            Assert.AreSame(instance1, instance2);
            Assert.AreNotSame(instance1, instance3);

            SimpleIoc.Default.Register<ITestClass>(() => instanceOriginal3, key1);

            var instance4 = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            Assert.IsNotNull(instance4);

            Assert.IsInstanceOfType(instance4, typeof(TestClass4));
            Assert.AreSame(instanceOriginal3, instance4);
            Assert.AreNotSame(instance1, instance4);
        }

        [TestMethod]
        public void TestGetAllInstancesWithType()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";
            const string key3 = "MyKey3";
            const string key4 = "MyKey4";
            const string key5 = "MyKey5";
            const string key6 = "MyKey6";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();
            SimpleIoc.Default.Register<TestClass2>();

            var instance1 = SimpleIoc.Default.GetInstance(typeof(TestClass), key1);
            var instance2 = SimpleIoc.Default.GetInstance(typeof(TestClass), key2);
            var instance3 = SimpleIoc.Default.GetInstance(typeof(TestClass), key3);
            var instance4 = SimpleIoc.Default.GetInstance(typeof(TestClass), key4);
            var instance5 = SimpleIoc.Default.GetInstance(typeof(TestClass2), key5);
            var instance6 = SimpleIoc.Default.GetInstance(typeof(TestClass2), key6);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);
            Assert.IsNotNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);

            var allInstances = SimpleIoc.Default.GetAllInstances(typeof (TestClass));
            Assert.AreEqual(4, allInstances.Count());

            foreach (var instance in allInstances)
            {
                Assert.IsNotNull(instance);

                if (instance.Equals(instance1))
                {
                    instance1 = null;
                }

                if (instance.Equals(instance2))
                {
                    instance2 = null;
                }

                if (instance.Equals(instance3))
                {
                    instance3 = null;
                }

                if (instance.Equals(instance4))
                {
                    instance4 = null;
                }

                if (instance.Equals(instance5))
                {
                    instance5 = null;
                }

                if (instance.Equals(instance6))
                {
                    instance6 = null;
                }
            }

            Assert.IsNull(instance1);
            Assert.IsNull(instance2);
            Assert.IsNull(instance3);
            Assert.IsNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);
        }

        [TestMethod]
        public void TestGetAllInstancesWithTypeGeneric()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";
            const string key3 = "MyKey3";
            const string key4 = "MyKey4";
            const string key5 = "MyKey5";
            const string key6 = "MyKey6";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();
            SimpleIoc.Default.Register<TestClass2>();

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key2);
            var instance3 = SimpleIoc.Default.GetInstance<TestClass>(key3);
            var instance4 = SimpleIoc.Default.GetInstance<TestClass>(key4);
            var instance5 = SimpleIoc.Default.GetInstance<TestClass2>(key5);
            var instance6 = SimpleIoc.Default.GetInstance<TestClass2>(key6);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);
            Assert.IsNotNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);

            var allInstances = SimpleIoc.Default.GetAllInstances <TestClass>();
            Assert.AreEqual(4, allInstances.Count());

            foreach (var instance in allInstances)
            {
                Assert.IsNotNull(instance);

                if (instance.Equals(instance1))
                {
                    instance1 = null;
                }

                if (instance.Equals(instance2))
                {
                    instance2 = null;
                }

                if (instance.Equals(instance3))
                {
                    instance3 = null;
                }

                if (instance.Equals(instance4))
                {
                    instance4 = null;
                }

                if (instance.Equals(instance5))
                {
                    instance5 = null;
                }

                if (instance.Equals(instance6))
                {
                    instance6 = null;
                }
            }

            Assert.IsNull(instance1);
            Assert.IsNull(instance2);
            Assert.IsNull(instance3);
            Assert.IsNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);
        }

        [TestMethod]
        public void TestGetAllInstancesWithInterface()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";
            const string key3 = "MyKey3";
            const string key4 = "MyKey4";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key1);
            var instance2 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key2);
            var instance3 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key3);
            var instance4 = SimpleIoc.Default.GetInstance(typeof(ITestClass), key4);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);
            Assert.IsNotNull(instance4);

            var allInstances = SimpleIoc.Default.GetAllInstances(typeof(ITestClass));
            Assert.AreEqual(4, allInstances.Count());

            foreach (var instance in allInstances)
            {
                Assert.IsNotNull(instance);

                if (instance.Equals(instance1))
                {
                    instance1 = null;
                }

                if (instance.Equals(instance2))
                {
                    instance2 = null;
                }

                if (instance.Equals(instance3))
                {
                    instance3 = null;
                }

                if (instance.Equals(instance4))
                {
                    instance4 = null;
                }
            }

            Assert.IsNull(instance1);
            Assert.IsNull(instance2);
            Assert.IsNull(instance3);
            Assert.IsNull(instance4);
        }

        [TestMethod]
        public void TestGetAllInstancesWithInterfaceGeneric()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";
            const string key3 = "MyKey3";
            const string key4 = "MyKey4";

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();

            var instance1 = SimpleIoc.Default.GetInstance<ITestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<ITestClass>(key2);
            var instance3 = SimpleIoc.Default.GetInstance<ITestClass>(key3);
            var instance4 = SimpleIoc.Default.GetInstance<ITestClass>(key4);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);
            Assert.IsNotNull(instance4);

            var allInstances = SimpleIoc.Default.GetAllInstances<ITestClass>();
            Assert.AreEqual(4, allInstances.Count());

            foreach (var instance in allInstances)
            {
                Assert.IsNotNull(instance);

                if (instance.Equals(instance1))
                {
                    instance1 = null;
                }

                if (instance.Equals(instance2))
                {
                    instance2 = null;
                }

                if (instance.Equals(instance3))
                {
                    instance3 = null;
                }

                if (instance.Equals(instance4))
                {
                    instance4 = null;
                }
            }

            Assert.IsNull(instance1);
            Assert.IsNull(instance2);
            Assert.IsNull(instance3);
            Assert.IsNull(instance4);
        }

        [TestMethod]
        public void TestGetAllInstancesWithInstance()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";
            const string key3 = "MyKey3";
            const string key4 = "MyKey4";
            const string key5 = "MyKey5";
            const string key6 = "MyKey6";

            var instanceOriginal1 = new TestClass();
            var instanceOriginal2 = new TestClass();
            var instanceOriginal3 = new TestClass();
            var instanceOriginal4 = new TestClass();
            var instanceOriginal5 = new TestClass4();
            var instanceOriginal6 = new TestClass4();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1, key1);
            SimpleIoc.Default.Register(() => instanceOriginal2, key2);
            SimpleIoc.Default.Register(() => instanceOriginal3, key3);
            SimpleIoc.Default.Register(() => instanceOriginal4, key4);
            SimpleIoc.Default.Register(() => instanceOriginal5, key5);
            SimpleIoc.Default.Register(() => instanceOriginal6, key6);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key2);
            var instance3 = SimpleIoc.Default.GetInstance<TestClass>(key3);
            var instance4 = SimpleIoc.Default.GetInstance<TestClass>(key4);
            var instance5 = SimpleIoc.Default.GetInstance<TestClass4>(key5);
            var instance6 = SimpleIoc.Default.GetInstance<TestClass4>(key6);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);
            Assert.IsNotNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);

            var allInstances = SimpleIoc.Default.GetAllInstances(typeof(TestClass));
            Assert.AreEqual(4, allInstances.Count());

            foreach (var instance in allInstances)
            {
                Assert.IsNotNull(instance);

                if (instance.Equals(instance1))
                {
                    instance1 = null;
                }

                if (instance.Equals(instance2))
                {
                    instance2 = null;
                }

                if (instance.Equals(instance3))
                {
                    instance3 = null;
                }

                if (instance.Equals(instance4))
                {
                    instance4 = null;
                }

                if (instance.Equals(instance5))
                {
                    instance5 = null;
                }

                if (instance.Equals(instance6))
                {
                    instance6 = null;
                }
            }

            Assert.IsNull(instance1);
            Assert.IsNull(instance2);
            Assert.IsNull(instance3);
            Assert.IsNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);
        }

        [TestMethod]
        public void TestGetAllInstancesWithInstanceGeneric()
        {
            const string key1 = "MyKey1";
            const string key2 = "MyKey2";
            const string key3 = "MyKey3";
            const string key4 = "MyKey4";
            const string key5 = "MyKey5";
            const string key6 = "MyKey6";

            var instanceOriginal1 = new TestClass();
            var instanceOriginal2 = new TestClass();
            var instanceOriginal3 = new TestClass();
            var instanceOriginal4 = new TestClass();
            var instanceOriginal5 = new TestClass4();
            var instanceOriginal6 = new TestClass4();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => instanceOriginal1, key1);
            SimpleIoc.Default.Register(() => instanceOriginal2, key2);
            SimpleIoc.Default.Register(() => instanceOriginal3, key3);
            SimpleIoc.Default.Register(() => instanceOriginal4, key4);
            SimpleIoc.Default.Register(() => instanceOriginal5, key5);
            SimpleIoc.Default.Register(() => instanceOriginal6, key6);

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key2);
            var instance3 = SimpleIoc.Default.GetInstance<TestClass>(key3);
            var instance4 = SimpleIoc.Default.GetInstance<TestClass>(key4);
            var instance5 = SimpleIoc.Default.GetInstance<TestClass4>(key5);
            var instance6 = SimpleIoc.Default.GetInstance<TestClass4>(key6);

            Assert.IsNotNull(instance1);
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance3);
            Assert.IsNotNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);

            var allInstances = SimpleIoc.Default.GetAllInstances<TestClass>();
            Assert.AreEqual(4, allInstances.Count());

            foreach (var instance in allInstances)
            {
                Assert.IsNotNull(instance);

                if (instance.Equals(instance1))
                {
                    instance1 = null;
                }

                if (instance.Equals(instance2))
                {
                    instance2 = null;
                }

                if (instance.Equals(instance3))
                {
                    instance3 = null;
                }

                if (instance.Equals(instance4))
                {
                    instance4 = null;
                }

                if (instance.Equals(instance5))
                {
                    instance5 = null;
                }

                if (instance.Equals(instance6))
                {
                    instance6 = null;
                }
            }

            Assert.IsNull(instance1);
            Assert.IsNull(instance2);
            Assert.IsNull(instance3);
            Assert.IsNull(instance4);
            Assert.IsNotNull(instance5);
            Assert.IsNotNull(instance6);
        }

        [TestMethod]
        public void TestGetInstancesWithParameters()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass, TestClass>();
            SimpleIoc.Default.Register<TestClass3>();

            const string key1 = "My key 1";
            const string key2 = "My key 2";

            var instance1 = SimpleIoc.Default.GetInstance<TestClass3>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass3>(key2);
            var property = SimpleIoc.Default.GetInstance<ITestClass>();

            Assert.IsNotNull(instance1);
            Assert.IsInstanceOfType(instance1, typeof(TestClass3));

            Assert.IsNotNull(instance2);
            Assert.IsInstanceOfType(instance2, typeof(TestClass3));

            Assert.AreNotSame(instance1, instance2);

            Assert.IsNotNull(instance1.SavedProperty);
            Assert.AreSame(instance1.SavedProperty, property);
            Assert.IsNotNull(instance2.SavedProperty);
            Assert.AreSame(instance2.SavedProperty, property);
        }

        [TestMethod]
        public void TestGetEmptyInstances()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            const string key1 = "My key 1";
            const string key2 = "My key 2";

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key2);

            var allInstances = SimpleIoc.Default.GetAllInstances(typeof (TestClass2));

            Assert.IsNotNull(allInstances);
            Assert.AreEqual(0, allInstances.Count());
        }

        [TestMethod]
        public void TestGetEmptyInstancesGeneric()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            const string key1 = "My key 1";
            const string key2 = "My key 2";

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);
            var instance2 = SimpleIoc.Default.GetInstance<TestClass>(key2);

            var allInstances = SimpleIoc.Default.GetAllInstances<TestClass2>();

            Assert.IsNotNull(allInstances);
            Assert.AreEqual(0, allInstances.Count());
        }

        [TestMethod]
        public void TestGetInstanceWithNullKey()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass>();

            const string key1 = "My key 1";

            var instance1 = SimpleIoc.Default.GetInstance<TestClass>(key1);

            var instance01 = SimpleIoc.Default.GetInstance<TestClass>(null);
            var instance02 = SimpleIoc.Default.GetInstance<TestClass>(string.Empty);
            var instance03 = SimpleIoc.Default.GetInstance<TestClass>();

            Assert.AreNotSame(instance1, instance01);
            Assert.AreSame(instance01, instance02);
            Assert.AreSame(instance01, instance03);
            Assert.AreSame(instance02, instance03);
        }
    }
}
