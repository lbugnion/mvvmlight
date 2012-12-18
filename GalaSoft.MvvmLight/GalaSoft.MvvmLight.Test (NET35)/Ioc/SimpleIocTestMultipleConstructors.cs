using System;
using System.Diagnostics;
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
    public class SimpleIocTestMultipleOrPrivateConstructors
    {
        [TestMethod]
        public void TestBuildInstanceWithMultipleConstructorsNotMarkedWithAttribute()
        {
            var property = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register(() => new TestClass6(property));

            var instance1 = new TestClass6();
            Assert.IsNotNull(instance1);
            Assert.IsNull(instance1.MyProperty);

            var instance2 = SimpleIoc.Default.GetInstance<TestClass6>();
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance2.MyProperty);
            Assert.AreSame(property, instance2.MyProperty);
        }

        [TestMethod]
        public void TestBuildWithMultipleConstructors()
        {
            var property = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => property);
            SimpleIoc.Default.Register<TestClass5>();

            var instance1 = new TestClass5();
            Assert.IsNotNull(instance1);
            Assert.IsNull(instance1.MyProperty);

            var instance2 = SimpleIoc.Default.GetInstance<TestClass5>();
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance2.MyProperty);
            Assert.AreSame(property, instance2.MyProperty);
        }

        [TestMethod]
        public void TestBuildWithMultipleConstructorsNotMarkedWithAttribute()
        {
            var property = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => property);

            try
            {
                SimpleIoc.Default.Register<TestClass6>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [TestMethod]
        public void TestBuildWithPrivateConstructor()
        {
            SimpleIoc.Default.Reset();

            try
            {
                SimpleIoc.Default.Register<TestClass7>();
                Assert.Fail("ActivationException was expected");
            }
            catch (ActivationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        
        [TestMethod]
        public void TestBuildWithStaticConstructor()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass8>();
        }

        [TestMethod]
        public void TestPublicAndInternalConstructor()
        {
            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass9>();
        }
    }
}