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
    public class SimpleIocTestMultipleConstructors
    {
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
        [ExpectedException(typeof(ActivationException))]
        public void TestBuildWithMultipleConstructorsNotMarkedWithAttribute()
        {
            var property = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<ITestClass>(() => property);
            SimpleIoc.Default.Register<TestClass6>();

            var instance1 = new TestClass6();
            Assert.IsNotNull(instance1);
            Assert.IsNull(instance1.MyProperty);

            var instance2 = SimpleIoc.Default.GetInstance<TestClass6>();
            Assert.IsNotNull(instance2);
            Assert.IsNotNull(instance2.MyProperty);
            Assert.AreSame(property, instance2.MyProperty);
        }

        [TestMethod]
        public void TestBuildInstanceWithMultipleConstructorsNotMarkedWithAttribute()
        {
            var property = new TestClass();

            SimpleIoc.Default.Reset();
            SimpleIoc.Default.Register<TestClass6>(() => new TestClass6(property));

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
