using System;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Helpers
{
    [TestClass]
    public class WeakActionNestedTest
    {
#if !WP70 // Somehow these tests make all tests fail to run in WP7.0. Use WP7.1 to test.
        private PublicNestedTestClass _itemPublic;
#endif
        private InternalNestedTestClass _itemInternal;
        private PrivateNestedTestClass _itemPrivate;
        private WeakReference _reference;
        private WeakAction _action;

#if !WP70
        [TestMethod]
        public void TestPublicNestedClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicNestedTestClass(index);

            _action = _itemPublic.GetAction(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemPublic);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Public + index,
                PublicNestedTestClass.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicNestedClassPublicStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.PublicStatic,
                PublicNestedTestClass.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicNestedClassInternalNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicNestedTestClass(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Internal + index,
                PublicNestedTestClass.Result);

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
        public void TestPublicNestedClassInternalStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.InternalStatic,
                PublicNestedTestClass.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicNestedClassPrivateNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicNestedTestClass(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Private + index,
                PublicNestedTestClass.Result);

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
        public void TestPublicNestedClassPrivateStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.PrivateStatic,
                PublicNestedTestClass.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicNestedClassAnonymousMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicNestedTestClass(index);
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + index,
                PublicNestedTestClass.Result);

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
        public void TestPublicNestedClassAnonymousStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetAction(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected,
                PublicNestedTestClass.Result);

            _itemPublic = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }
#endif

        [TestMethod]
        public void TestInternalNestedClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalNestedTestClass(index);

            _action = _itemInternal.GetAction(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemInternal);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Public + index,
                InternalNestedTestClass.Result);

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
        public void TestInternalNestedClassPublicStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.PublicStatic,
                InternalNestedTestClass.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalNestedClassInternalNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalNestedTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Internal + index,
                InternalNestedTestClass.Result);

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
        public void TestInternalNestedClassInternalStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.InternalStatic,
                InternalNestedTestClass.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalNestedClassPrivateNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalNestedTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Private + index,
                InternalNestedTestClass.Result);

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
        public void TestInternalNestedClassPrivateStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.PrivateStatic,
                InternalNestedTestClass.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalNestedClassAnonymousMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalNestedTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + index,
                InternalNestedTestClass.Result);

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
        public void TestInternalNestedClassAnonymousStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetAction(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected,
                InternalNestedTestClass.Result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateNestedClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPrivate = new PrivateNestedTestClass(index);

            _action = _itemPrivate.GetAction(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemPrivate);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Public + index,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
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
        public void TestPrivateNestedClassPublicStaticMethod()
        {
            Reset();

            _itemPrivate = new PrivateNestedTestClass();
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.PublicStatic,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateNestedClassInternalNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPrivate = new PrivateNestedTestClass(index);
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Internal + index,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
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
        public void TestPrivateNestedClassInternalStaticMethod()
        {
            Reset();

            _itemPrivate = new PrivateNestedTestClass();
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.InternalStatic,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateNestedClassPrivateNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPrivate = new PrivateNestedTestClass(index);
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Private + index,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
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
        public void TestPrivateNestedClassPrivateStaticMethod()
        {
            Reset();

            _itemPrivate = new PrivateNestedTestClass();
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.PrivateStatic,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateNestedClassAnonymousMethod()
        {
            Reset();

            const int index = 99;

            _itemPrivate = new PrivateNestedTestClass(index);
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + index,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
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
        public void TestPrivateNestedClassAnonymousStaticMethod()
        {
            Reset();

            _itemPrivate = new PrivateNestedTestClass();
            _reference = new WeakReference(_itemPrivate);

            _action = _itemPrivate.GetAction(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected,
                PrivateNestedTestClass.Result);

            _itemPrivate = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        private void Reset()
        {
#if !WP70
            _itemPublic = null;
#endif
            _itemInternal = null;
            _itemPrivate = null;
            _reference = null;
        }

        public class PublicNestedTestClass
        {
            private int _index; // Just here to force instance methods

            public const string Expected = "Hello";
            public const string Public = "Public";
            public const string Internal = "Internal";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
            public const string InternalStatic = "InternalStatic";
            public const string PrivateStatic = "PrivateStatic";

            public static string Result
            {
                get;
                private set;
            }

            public PublicNestedTestClass()
            {

            }

            public PublicNestedTestClass(int index)
            {
                _index = index;
            }

            private void DoStuffPrivately()
            {
                Result = Expected + Private + _index;
            }

            internal void DoStuffInternally()
            {
                Result = Expected + Internal + _index;
            }

            public void DoStuffPublically()
            {
                Result = Expected + Public + _index;
            }

            private static void DoStuffPrivatelyAndStatically()
            {
                Result = Expected + PrivateStatic;
            }

            public static void DoStuffPublicallyAndStatically()
            {
                Result = Expected + PublicStatic;
            }

            internal static void DoStuffInternallyAndStatically()
            {
                Result = Expected + InternalStatic;
            }

            public WeakAction GetAction(WeakActionTestCase testCase)
            {
                WeakAction action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPublically);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffInternally);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPrivately);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPublicallyAndStatically);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffInternallyAndStatically);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPrivatelyAndStatically);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakAction(
                            this,
                            () => Result = Expected);
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakAction(
                            this,
                            () => Result = Expected + _index);
                        break;
                }

                return action;
            }
        }

        internal class InternalNestedTestClass
        {
            private int _index; // Just here to force instance methods

            public const string Expected = "Hello";
            public const string Public = "Public";
            public const string Internal = "Internal";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
            public const string InternalStatic = "InternalStatic";
            public const string PrivateStatic = "PrivateStatic";

            public static string Result
            {
                get;
                private set;
            }

            public InternalNestedTestClass()
            {

            }

            public InternalNestedTestClass(int index)
            {
                _index = index;
            }

            private void DoStuffPrivately()
            {
                Result = Expected + Private + _index;
            }

            internal void DoStuffInternally()
            {
                Result = Expected + Internal + _index;
            }

            public void DoStuffPublically()
            {
                Result = Expected + Public + _index;
            }

            private static void DoStuffPrivatelyAndStatically()
            {
                Result = Expected + PrivateStatic;
            }

            internal static void DoStuffInternallyAndStatically()
            {
                Result = Expected + InternalStatic;
            }

            public static void DoStuffPublicallyAndStatically()
            {
                Result = Expected + PublicStatic;
            }

            public WeakAction GetAction(WeakActionTestCase testCase)
            {
                WeakAction action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPublically);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffInternally);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPrivately);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPublicallyAndStatically);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffInternallyAndStatically);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPrivatelyAndStatically);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakAction(
                            this,
                            () => Result = Expected);
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakAction(
                            this,
                            () => Result = Expected + _index);
                        break;
                }

                return action;
            }
        }

        private class PrivateNestedTestClass
        {
            private int _index; // Just here to force instance methods

            public const string Expected = "Hello";
            public const string Public = "Public";
            public const string Internal = "Internal";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
            public const string InternalStatic = "InternalStatic";
            public const string PrivateStatic = "PrivateStatic";

            public static string Result
            {
                get;
                private set;
            }

            public PrivateNestedTestClass()
            {

            }

            public PrivateNestedTestClass(int index)
            {
                _index = index;
            }

            private void DoStuffPrivately()
            {
                Result = Expected + Private + _index;
            }

            internal void DoStuffInternally()
            {
                Result = Expected + Internal + _index;
            }

            public void DoStuffPublically()
            {
                Result = Expected + Public + _index;
            }

            private static void DoStuffPrivatelyAndStatically()
            {
                Result = Expected + PrivateStatic;
            }

            internal static void DoStuffInternallyAndStatically()
            {
                Result = Expected + InternalStatic;
            }

            public static void DoStuffPublicallyAndStatically()
            {
                Result = Expected + PublicStatic;
            }

            public WeakAction GetAction(WeakActionTestCase testCase)
            {
                WeakAction action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPublically);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffInternally);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPrivately);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPublicallyAndStatically);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffInternallyAndStatically);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakAction(
                            this,
                            DoStuffPrivatelyAndStatically);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakAction(
                            this,
                            () => Result = Expected);
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakAction(
                            this,
                            () => Result = Expected + _index);
                        break;
                }

                return action;
            }
        }
    }
}