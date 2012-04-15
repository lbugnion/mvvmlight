using System;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Helpers
{
    [TestClass]
    public class WeakFuncNestedTest
    {
#if !WP70 // Somehow these tests make all tests fail to run in WP7.0. Use WP7.1 to test.
        private PublicNestedTestClass _itemPublic;
#endif
        private InternalNestedTestClass _itemInternal;
        private PrivateNestedTestClass _itemPrivate;
        private WeakReference _reference;
        private WeakFunc<string> _action;

#if !WP70
        [TestMethod]
        public void TestPublicNestedClassPublicNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemPublic = new PublicNestedTestClass(index);

            _action = _itemPublic.GetFunc(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemPublic);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Public + index,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Public + index,
                result);

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

            _action = _itemPublic.GetFunc(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.PublicStatic,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.PublicStatic,
                result);

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

            _action = _itemPublic.GetFunc(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Internal + index,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Internal + index,
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
        public void TestPublicNestedClassInternalStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.InternalStatic,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.InternalStatic,
                result);

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

            _action = _itemPublic.GetFunc(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Private + index,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.Private + index,
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
        public void TestPublicNestedClassPrivateStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.PrivateStatic,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + PublicNestedTestClass.PrivateStatic,
                result);

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

            _action = _itemPublic.GetFunc(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected + index,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected + index,
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
        public void TestPublicNestedClassAnonymousStaticMethod()
        {
            Reset();

            _itemPublic = new PublicNestedTestClass();
            _reference = new WeakReference(_itemPublic);

            _action = _itemPublic.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PublicNestedTestClass.Expected,
                PublicNestedTestClass.Result);
            Assert.AreEqual(
                PublicNestedTestClass.Expected,
                result);

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

            _action = _itemInternal.GetFunc(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemInternal);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Public + index,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Public + index,
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
        public void TestInternalNestedClassPublicStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.PublicStatic,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.PublicStatic,
                result);

            _itemInternal = null;
            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalNestedClassInternalStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.InternalStatic,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.InternalStatic,
                result);

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

            _action = _itemInternal.GetFunc(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Internal + index,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Internal + index,
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
        public void TestInternalNestedClassPrivateNamedMethod()
        {
            Reset();

            const int index = 99;

            _itemInternal = new InternalNestedTestClass(index);
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Private + index,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.Private + index,
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
        public void TestInternalNestedClassPrivateStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.PrivateStatic,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + InternalNestedTestClass.PrivateStatic,
                result);

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

            _action = _itemInternal.GetFunc(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected + index,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected + index,
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
        public void TestInternalNestedClassAnonymousStaticMethod()
        {
            Reset();

            _itemInternal = new InternalNestedTestClass();
            _reference = new WeakReference(_itemInternal);

            _action = _itemInternal.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                InternalNestedTestClass.Expected,
                InternalNestedTestClass.Result);
            Assert.AreEqual(
                InternalNestedTestClass.Expected,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.PublicNamedMethod);

            _reference = new WeakReference(_itemPrivate);
            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Public + index,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Public + index,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.PublicStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.PublicStatic,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.PublicStatic,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.InternalNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Internal + index,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Internal + index,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.InternalStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.InternalStatic,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.InternalStatic,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.PrivateNamedMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Private + index,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.Private + index,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.PrivateStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.PrivateStatic,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + PrivateNestedTestClass.PrivateStatic,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.AnonymousMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected + index,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected + index,
                result);

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

            _action = _itemPrivate.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

            Assert.IsTrue(_reference.IsAlive);
            Assert.IsTrue(_action.IsAlive);

            var result = _action.Execute();

            Assert.AreEqual(
                PrivateNestedTestClass.Expected,
                PrivateNestedTestClass.Result);
            Assert.AreEqual(
                PrivateNestedTestClass.Expected,
                result);

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

            private string DoStuffPrivatelyWithResult()
            {
                Result = Expected + Private + _index;
                return Result;
            }

            internal string DoStuffInternallyWithResult()
            {
                Result = Expected + Internal + _index;
                return Result;
            }

            public string DoStuffPublicallyWithResult()
            {
                Result = Expected + Public + _index;
                return Result;
            }

            private static string DoStuffPrivatelyAndStaticallyWithResult()
            {
                Result = Expected + PrivateStatic;
                return Result;
            }

            public static string DoStuffPublicallyAndStaticallyWithResult()
            {
                Result = Expected + PublicStatic;
                return Result;
            }

            internal static string DoStuffInternallyAndStaticallyWithResult()
            {
                Result = Expected + InternalStatic;
                return Result;
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

            public WeakFunc<string> GetFunc(WeakActionTestCase testCase)
            {
                WeakFunc<string> action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPublicallyWithResult);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffInternallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPrivatelyWithResult);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPublicallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffInternallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPrivatelyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            () =>
                            {
                                Result = Expected;
                                return Result;
                            });
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakFunc<string>(
                            this,
                            () =>
                            {
                                Result = Expected + _index;
                                return Result;
                            });
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
            public const string InternalStatic = "InternalStatic";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
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

            private static void DoStuffInternallyAndStatically()
            {
                Result = Expected + InternalStatic;
            }

            public static void DoStuffPublicallyAndStatically()
            {
                Result = Expected + PublicStatic;
            }

            private string DoStuffPrivatelyWithResult()
            {
                Result = Expected + Private + _index;
                return Result;
            }

            internal string DoStuffInternallyWithResult()
            {
                Result = Expected + Internal + _index;
                return Result;
            }

            public string DoStuffPublicallyWithResult()
            {
                Result = Expected + Public + _index;
                return Result;
            }

            private static string DoStuffPrivatelyAndStaticallyWithResult()
            {
                Result = Expected + PrivateStatic;
                return Result;
            }

            internal static string DoStuffInternallyAndStaticallyWithResult()
            {
                Result = Expected + InternalStatic;
                return Result;
            }

            public static string DoStuffPublicallyAndStaticallyWithResult()
            {
                Result = Expected + PublicStatic;
                return Result;
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

            public WeakFunc<string> GetFunc(WeakActionTestCase testCase)
            {
                WeakFunc<string> action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPublicallyWithResult);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffInternallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPrivatelyWithResult);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPublicallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffInternallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPrivatelyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            () =>
                            {
                                Result = Expected;
                                return Result;
                            });
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakFunc<string>(
                            this,
                            () =>
                            {
                                Result = Expected + _index;
                                return Result;
                            });
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
            public const string InternalStatic = "InternalStatic";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
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

            public static void DoStuffPublicallyAndStatically()
            {
                Result = Expected + PublicStatic;
            }

            private string DoStuffPrivatelyWithResult()
            {
                Result = Expected + Private + _index;
                return Result;
            }

            internal string DoStuffInternallyWithResult()
            {
                Result = Expected + Internal + _index;
                return Result;
            }

            public string DoStuffPublicallyWithResult()
            {
                Result = Expected + Public + _index;
                return Result;
            }

            private static string DoStuffPrivatelyAndStaticallyWithResult()
            {
                Result = Expected + PrivateStatic;
                return Result;
            }

            internal static string DoStuffInternallyAndStaticallyWithResult()
            {
                Result = Expected + InternalStatic;
                return Result;
            }

            public static string DoStuffPublicallyAndStaticallyWithResult()
            {
                Result = Expected + PublicStatic;
                return Result;
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

            public WeakFunc<string> GetFunc(WeakActionTestCase testCase)
            {
                WeakFunc<string> action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPublicallyWithResult);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffInternallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPrivatelyWithResult);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPublicallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffInternallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            DoStuffPrivatelyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakFunc<string>(
                            this,
                            () =>
                            {
                                Result = Expected;
                                return Result;
                            });
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakFunc<string>(
                            this,
                            () =>
                            {
                                Result = Expected + _index;
                                return Result;
                            });
                        break;
                }

                return action;
            }
        }
    }
}