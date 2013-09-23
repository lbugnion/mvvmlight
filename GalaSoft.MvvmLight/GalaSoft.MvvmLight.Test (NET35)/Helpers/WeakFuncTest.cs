using System;
using GalaSoft.MvvmLight.Helpers;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Helpers
{
    [TestClass]
    public class WeakFuncTest
    {
#if !WP70 // Somehow these tests make all tests fail to run in WP7.0. Use WP7.1 to test.
        private PublicTestClass _itemPublic;
#endif
        private InternalTestClass _itemInternal;
        private CommonTestClass _common;
        private WeakReference _reference;
        private WeakFunc<string> _action;
        private string _local;

#if !WP70
        [TestMethod]
        public void TestPublicClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicTestClass(index);

            _action = _itemPublic.GetFunc(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemPublic);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.Public + index,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.Public + index,
                result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassPublicStaticMethod()
        {
            Reset();

            _itemPublic = new PublicTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.PublicStatic,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.PublicStatic,
                result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassInternalNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicTestClass(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.Internal + index,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.Internal + index,
                result);

            _itemPublic = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPublicClassInternalStaticMethod()
        {
            Reset();

            _itemPublic = new PublicTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.InternalStatic,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.InternalStatic,
                result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassPrivateNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicTestClass(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.Private + index,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.Private + index,
                result);

            _itemPublic = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPublicClassPrivateStaticMethod()
        {
            Reset();

            _itemPublic = new PublicTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.PrivateStatic,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + PublicTestClass.PrivateStatic,
                result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassAnonymousMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicTestClass(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected + index,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected + index,
                result);

            _itemPublic = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPublicClassAnonymousStaticMethod()
        {
            Reset();

            _itemPublic = new PublicTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicTestClass.Expected,
                PublicTestClass.Result);
            Assert.AreEqual(
                PublicTestClass.Expected,
                result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }
#endif

        [TestMethod]
        public void TestInternalClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalTestClass(index);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemInternal);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.Public + index,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.Public + index,
                result);

            _itemInternal = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassPublicStaticMethod()
        {
            Reset();

            _itemInternal = new InternalTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.PublicStatic,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.PublicStatic,
                result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassInternalNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.Internal + index,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.Internal + index,
                result);

            _itemInternal = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassInternalStaticMethod()
        {
            Reset();

            _itemInternal = new InternalTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.InternalStatic,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.InternalStatic,
                result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassPrivateNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.Private + index,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.Private + index,
                result);

            _itemInternal = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassPrivateStaticMethod()
        {
            Reset();

            _itemInternal = new InternalTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.PrivateStatic,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + InternalTestClass.PrivateStatic,
                result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassAnonymousMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected + index,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected + index,
                result);

            _itemInternal = null;
            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassAnonymousStaticMethod()
        {
            Reset();

            _itemInternal = new InternalTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalTestClass.Expected,
                InternalTestClass.Result);
            Assert.AreEqual(
                InternalTestClass.Expected,
                result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestNonStaticMethodWithNullTarget()
        {
            Reset();
            var func = new WeakFunc<string>(null, DoStuffWithResult);
            Assert.IsFalse(func.IsAlive);
        }

        [TestMethod]
        public void TestStaticMethodWithNullTarget()
        {
            Reset();
            var func = new WeakFunc<string>(null, DoStuffStaticWithResult);
            Assert.IsTrue(func.IsAlive);
        }

        [TestMethod]
        public void TestStaticMethodWithNonNullTarget()
        {
            Reset();

            _common = new CommonTestClass();
            _reference = new WeakReference(_common);
            Assert.IsTrue(_reference.IsAlive);

            var func = new WeakFunc<string>(_common, DoStuffStaticWithResult);
            Assert.IsTrue(func.IsAlive);

            _common = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
            Assert.IsFalse(func.IsAlive);
        }

        public static string DoStuffStaticWithResult()
        {
            return DateTime.Now.ToString();
        }

        public string DoStuffWithResult()
        {
            _local = DateTime.Now.ToString();
            return _local;
        }

        private void Reset()
        {
#if !WP70
            _itemPublic = null;
#endif
            _itemInternal = null;
            _reference = null;
        }
    }
}
