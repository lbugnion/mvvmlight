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
    public class WeakActionGenericTest
    {
#if !WP70 // Somehow these tests make all tests fail to run in WP7.0. Use WP7.1 to test.
        private PublicTestClass<string> _itemPublic;
#endif
        private InternalTestClass<string> _itemInternal;
        private CommonTestClass _common;
        private WeakReference _reference;
        private WeakAction<string> _action;
        private string _local;

#if !WP70
        [TestMethod]
        public void TestPublicClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;
            const string parameter = "My parameter";

            _itemPublic = new PublicTestClass<string>(index);

            _action = _itemPublic.GetAction(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemPublic);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + PublicTestClass<string>.Public + index + parameter,
                PublicTestClass<string>.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassPublicStaticMethod()
        {
            Reset();

            const string parameter = "My parameter";

            _itemPublic = new PublicTestClass<string>();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + PublicTestClass<string>.PublicStatic + parameter,
                PublicTestClass<string>.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassInternalNamedMethod()
        {
            Reset();

            const string parameter = "My parameter";
            const int index = 99;

            _itemPublic = new PublicTestClass<string>(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + PublicTestClass<string>.Internal + index + parameter,
                PublicTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemPublic = new PublicTestClass<string>();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + PublicTestClass<string>.InternalStatic + parameter,
                PublicTestClass<string>.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassPrivateNamedMethod()
        {
            Reset();

            const string parameter = "My parameter";
            const int index = 99;

            _itemPublic = new PublicTestClass<string>(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + PublicTestClass<string>.Private + index + parameter,
                PublicTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemPublic = new PublicTestClass<string>();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + PublicTestClass<string>.PrivateStatic + parameter,
                PublicTestClass<string>.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassAnonymousMethod()
        {
            Reset();

            const int index = 99;
            const string parameter = "My parameter";

            _itemPublic = new PublicTestClass<string>(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + index + parameter,
                PublicTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemPublic = new PublicTestClass<string>();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                PublicTestClass<string>.Expected + parameter,
                PublicTestClass<string>.Result);

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
            const string parameter = "My parameter";

            _itemInternal = new InternalTestClass<string>(index);

            _action = _itemInternal.GetAction(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemInternal);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + InternalTestClass<string>.Public + index + parameter,
                InternalTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemInternal = new InternalTestClass<string>();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + InternalTestClass<string>.PublicStatic + parameter,
                InternalTestClass<string>.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassInternalNamedMethod()
        {
            Reset();

            const string parameter = "My parameter";
            const int index = 99;

            _itemInternal = new InternalTestClass<string>(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + InternalTestClass<string>.Internal + index + parameter,
                InternalTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemInternal = new InternalTestClass<string>();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + InternalTestClass<string>.InternalStatic + parameter,
                InternalTestClass<string>.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassPrivateNamedMethod()
        {
            Reset();

            const string parameter = "My parameter";
            const int index = 99;

            _itemInternal = new InternalTestClass<string>(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + InternalTestClass<string>.Private + index + parameter,
                InternalTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemInternal = new InternalTestClass<string>();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + InternalTestClass<string>.PrivateStatic + parameter,
                InternalTestClass<string>.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassAnonymousMethod()
        {
            Reset();

            const int index = 99;
            const string parameter = "My parameter";

            _itemInternal = new InternalTestClass<string>(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + index + parameter,
                InternalTestClass<string>.Result);

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

            const string parameter = "My parameter";

            _itemInternal = new InternalTestClass<string>();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute(parameter);

            Assert.AreEqual(
                InternalTestClass<string>.Expected + parameter,
                InternalTestClass<string>.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestNonStaticMethodWithNullTarget()
        {
            Reset();
            var action = new WeakAction<string>(null, DoStuff);
            Assert.IsFalse(action.IsAlive);
        }

        [TestMethod]
        public void TestStaticMethodWithNullTarget()
        {
            Reset();
            var action = new WeakAction<string>(null, DoStuffStatic);
            Assert.IsTrue(action.IsAlive);
        }

        [TestMethod]
        public void TestStaticMethodWithNonNullTarget()
        {
            Reset();

            _common = new CommonTestClass();
            _reference = new WeakReference(_common);
            Assert.IsTrue(_reference.IsAlive);

            var action = new WeakAction<string>(_common, DoStuffStatic);
            Assert.IsTrue(action.IsAlive);

            _common = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
            Assert.IsFalse(action.IsAlive);
        }

        public static void DoStuffStatic(string p)
        {

        }

        public void DoStuff(string p)
        {
            _local = p;
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
