using GalaSoft.MvvmLight.Ioc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GalaSoft.MvvmLight.Test.Ioc
{
    [TestClass]
    public class SimpleIocTestExceptions
    {
        [TestMethod]
        public void TestViewModelExceptionsInConstructor()
        {
            Exception error = null;
            TestViewModelForExceptions vm = null;

            if (!SimpleIoc.Default.IsRegistered<TestViewModelForExceptions>())
            {
                SimpleIoc.Default.Register<TestViewModelForExceptions>();
            }

            try
            {
                vm = SimpleIoc.Default.GetInstance<TestViewModelForExceptions>();
            }
            catch (Exception ex)
            {
                error = ex;
            }

            Assert.IsNotNull(error);
        }

        [TestMethod]
        public void TestViewModelWithMultipleConstructors()
        {
            TestViewModelForMultiConstructors vm = null;

            if (!SimpleIoc.Default.IsRegistered<TestViewModelForMultiConstructors>())
            {
                SimpleIoc.Default.Register<TestViewModelForMultiConstructors>();
            }

            if (!SimpleIoc.Default.IsRegistered<IService>())
            {
                SimpleIoc.Default.Register<IService, Service>();
            }

            vm = SimpleIoc.Default.GetInstance<TestViewModelForMultiConstructors>();
        }

        [TestMethod]
        public void TestViewModelWithStaticConstructor()
        {
            TestViewModelForStaticConstructor vm = null;

            if (!SimpleIoc.Default.IsRegistered<TestViewModelForStaticConstructor>())
            {
                SimpleIoc.Default.Register<TestViewModelForStaticConstructor>();
            }

            if (!SimpleIoc.Default.IsRegistered<IService>())
            {
                SimpleIoc.Default.Register<IService, Service>();
            }

            vm = SimpleIoc.Default.GetInstance<TestViewModelForStaticConstructor>();
        }

        public class TestViewModelForExceptions
        {
            public TestViewModelForExceptions()
            {
                throw new Exception("This is a test exception");
            }
        }

        public class TestViewModelForMultiConstructors
        {
            private IService _service;

            public TestViewModelForMultiConstructors()
            {
            }

            [PreferredConstructor]
            public TestViewModelForMultiConstructors(IService service)
            {
                _service = service;
            }
        }

        public class TestViewModelForStaticConstructor
        {
            private IService _service;

            static TestViewModelForStaticConstructor()
            {
            }

            public TestViewModelForStaticConstructor(IService service)
            {
                _service = service;
            }
        }

        public interface IService
        {
        }

        public class Service : IService
        {
        }
    }
}
