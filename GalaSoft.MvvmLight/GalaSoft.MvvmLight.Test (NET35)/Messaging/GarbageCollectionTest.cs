using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Test.Helpers;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Messaging
{
    [TestClass]
    public class GarbageCollectionTest
    {
        private TestRecipient _recipient;
        private TestRecipientInternal _recipientInternal;
        private TestRecipientPrivate _recipientPrivate;
        private WeakReference _recipientReference;

        [TestMethod]
        public void TestGarbageCollectionForNamedMethod()
        {
            Messenger.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.PublicNamedMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, _recipient.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipient.Content);

            _recipient = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedStaticMethod()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.PublicStaticMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, TestRecipient.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipient.ContentStatic);

            _recipient = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedPrivateMethod()
        {
            Messenger.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.PrivateNamedMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, _recipient.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipient.Content);

            _recipient = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the internal method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipient = (TestRecipient)_recipientReference.Target;
            Messenger.Default.Unregister(_recipient);
            _recipient = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);
#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedPrivateStaticMethod()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.PrivateStaticMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, TestRecipient.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipient.ContentStatic);

            _recipient = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedInternalMethod()
        {
            Messenger.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.InternalNamedMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, _recipient.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipient.Content);

            _recipient = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the internal method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipient = (TestRecipient)_recipientReference.Target;
            Messenger.Default.Unregister(_recipient);
            _recipient = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);

#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedInternalStaticMethod()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.InternalStaticMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, TestRecipient.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipient.ContentStatic);

            _recipient = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForAnonymousMethod()
        {
            Messenger.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.AnonymousMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, _recipient.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipient.Content);

            _recipient = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the anonymous method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipient = (TestRecipient)_recipientReference.Target;
            Messenger.Default.Unregister(_recipient);
            _recipient = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);

#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForAnonymousStaticMethod()
        {
            Messenger.Reset();
            TestRecipient.Reset();

            _recipient = new TestRecipient(WeakActionTestCase.AnonymousStaticMethod);
            _recipientReference = new WeakReference(_recipient);

            Assert.AreEqual(null, TestRecipient.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipient.ContentStatic);

            _recipient = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedMethodInternal()
        {
            Messenger.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.PublicNamedMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, _recipientInternal.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientInternal.Content);

            _recipientInternal = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the internal method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientInternal = (TestRecipientInternal)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientInternal);
            _recipientInternal = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);
#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedStaticMethodInternal()
        {
            Messenger.Reset();
            TestRecipientInternal.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.PublicStaticMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, TestRecipientInternal.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientInternal.ContentStatic);

            _recipientInternal = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedPrivateMethodInternal()
        {
            Messenger.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.PrivateNamedMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, _recipientInternal.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientInternal.Content);

            _recipientInternal = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the internal method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientInternal = (TestRecipientInternal)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientInternal);
            _recipientInternal = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);
#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedPrivateStaticMethodInternal()
        {
            Messenger.Reset();
            TestRecipientInternal.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.PrivateStaticMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, TestRecipientInternal.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientInternal.ContentStatic);

            _recipientInternal = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedInternalMethodInternal()
        {
            Messenger.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.InternalNamedMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, _recipientInternal.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientInternal.Content);

            _recipientInternal = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the internal method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientInternal = (TestRecipientInternal)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientInternal);
            _recipientInternal = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);

#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedInternalStaticMethodInternal()
        {
            Messenger.Reset();
            TestRecipientInternal.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.InternalStaticMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, TestRecipientInternal.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientInternal.ContentStatic);

            _recipientInternal = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForAnonymousMethodInternal()
        {
            Messenger.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.AnonymousMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, _recipientInternal.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientInternal.Content);

            _recipientInternal = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the anonymous method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientInternal = (TestRecipientInternal)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientInternal);
            _recipientInternal = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);

#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForAnonymousStaticMethodInternal()
        {
            Messenger.Reset();
            TestRecipientInternal.Reset();

            _recipientInternal = new TestRecipientInternal(WeakActionTestCase.AnonymousStaticMethod);
            _recipientReference = new WeakReference(_recipientInternal);

            Assert.AreEqual(null, TestRecipientInternal.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientInternal.ContentStatic);

            _recipientInternal = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedMethodPrivate()
        {
            Messenger.Reset();
            TestRecipientPrivate.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.PublicNamedMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, _recipientPrivate.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientPrivate.Content);

            _recipientPrivate = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the internal method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientPrivate = (TestRecipientPrivate)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientPrivate);
            _recipientPrivate = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);
#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedStaticMethodPrivate()
        {
            Messenger.Reset();
            TestRecipientPrivate.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.PublicStaticMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, TestRecipientPrivate.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientPrivate.ContentStatic);

            _recipientPrivate = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedPrivateMethodPrivate()
        {
            Messenger.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.PrivateNamedMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, _recipientPrivate.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientPrivate.Content);

            _recipientPrivate = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the Private method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientPrivate = (TestRecipientPrivate)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientPrivate);
            _recipientPrivate = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);
#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedPrivateStaticMethodPrivate()
        {
            Messenger.Reset();
            TestRecipientPrivate.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.PrivateStaticMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, TestRecipientPrivate.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientPrivate.ContentStatic);

            _recipientPrivate = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedInternalMethodPrivate()
        {
            Messenger.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.InternalNamedMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, _recipientPrivate.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientPrivate.Content);

            _recipientPrivate = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the Private method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientPrivate = (TestRecipientPrivate)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientPrivate);
            _recipientPrivate = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);

#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForNamedInternalStaticMethodPrivate()
        {
            Messenger.Reset();
            TestRecipientPrivate.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.InternalStaticMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, TestRecipientPrivate.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientPrivate.ContentStatic);

            _recipientPrivate = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        [TestMethod]
        public void TestGarbageCollectionForAnonymousMethodPrivate()
        {
            Messenger.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.AnonymousMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, _recipientPrivate.Content);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, _recipientPrivate.Content);

            _recipientPrivate = null;
            GC.Collect();

#if SILVERLIGHT
            // Cannot GC the anonymous method reference in Silverlight
            Assert.IsTrue(_recipientReference.IsAlive);

            _recipientPrivate = (TestRecipientPrivate)_recipientReference.Target;
            Messenger.Default.Unregister(_recipientPrivate);
            _recipientPrivate = null;
            GC.Collect();
            Assert.IsFalse(_recipientReference.IsAlive);

#else
            Assert.IsFalse(_recipientReference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestGarbageCollectionForAnonymousStaticMethodPrivate()
        {
            Messenger.Reset();
            TestRecipientPrivate.Reset();

            _recipientPrivate = new TestRecipientPrivate(WeakActionTestCase.AnonymousStaticMethod);
            _recipientReference = new WeakReference(_recipientPrivate);

            Assert.AreEqual(null, TestRecipientPrivate.ContentStatic);
            Assert.IsTrue(_recipientReference.IsAlive);

            const string message = "Hello world";

            Messenger.Default.Send(message);

            Assert.AreEqual(message, TestRecipientPrivate.ContentStatic);

            _recipientPrivate = null;
            GC.Collect();

            Assert.IsFalse(_recipientReference.IsAlive);
        }

        public void Reset()
        {
            _recipient = null;
            _recipientInternal = null;
            _recipientPrivate = null;
            _recipientReference = null;
        }

        public class TestRecipient
        {
            public string Content
            {
                get;
                private set;
            }

            public static string ContentStatic
            {
                get;
                private set;
            }

            internal static string ContentInternalStatic
            {
                get;
                private set;
            }

            private static string ContentPrivateStatic
            {
                get;
                set;
            }

            private string ContentPrivate
            {
                get;
                set;
            }

            internal string ContentInternal
            {
                get;
                private set;
            }

            public TestRecipient(WeakActionTestCase testCase)
            {
                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuff);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffPrivate);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffInternal);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffStatic);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffPrivateStatic);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffInternalStatic);
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        Messenger.Default.Register<string>(
                            this,
                            msg => Content = msg);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            msg => ContentStatic = msg);
                        break;
                }
            }

            public void DoStuff(string message)
            {
                Content = message;
            }

            private void DoStuffPrivate(string message)
            {
                Content = message;
                ContentPrivate = message;
            }

            internal void DoStuffInternal(string message)
            {
                Content = message;
                ContentInternal = message;
            }

            public static void DoStuffStatic(string message)
            {
                ContentStatic = message;
            }

            internal static void DoStuffInternalStatic(string message)
            {
                ContentStatic = message;
                ContentInternalStatic = message;
            }

            private static void DoStuffPrivateStatic(string message)
            {
                ContentStatic = message;
                ContentPrivateStatic = message;
            }

            public static void Reset()
            {
                ContentStatic = null;
                ContentPrivateStatic = null;
                ContentInternalStatic = null;
            }
        }

        internal class TestRecipientInternal
        {
            public string Content
            {
                get;
                private set;
            }

            public static string ContentStatic
            {
                get;
                private set;
            }

            internal static string ContentInternalStatic
            {
                get;
                private set;
            }

            private static string ContentPrivateStatic
            {
                get;
                set;
            }

            private string ContentPrivate
            {
                get;
                set;
            }

            internal string ContentInternal
            {
                get;
                private set;
            }

            public TestRecipientInternal(WeakActionTestCase testCase)
            {
                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuff);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffPrivate);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffInternal);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffStatic);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffPrivateStatic);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffInternalStatic);
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        Messenger.Default.Register<string>(
                            this,
                            msg => Content = msg);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            msg => ContentStatic = msg);
                        break;
                }
            }

            public void DoStuff(string message)
            {
                Content = message;
            }

            private void DoStuffPrivate(string message)
            {
                Content = message;
                ContentPrivate = message;
            }

            internal void DoStuffInternal(string message)
            {
                Content = message;
                ContentInternal = message;
            }

            public static void DoStuffStatic(string message)
            {
                ContentStatic = message;
            }

            internal static void DoStuffInternalStatic(string message)
            {
                ContentStatic = message;
                ContentInternalStatic = message;
            }

            private static void DoStuffPrivateStatic(string message)
            {
                ContentStatic = message;
                ContentPrivateStatic = message;
            }

            public static void Reset()
            {
                ContentStatic = null;
                ContentPrivateStatic = null;
                ContentInternalStatic = null;
            }
        }

        private class TestRecipientPrivate
        {
            public string Content
            {
                get;
                private set;
            }

            public static string ContentStatic
            {
                get;
                private set;
            }

            internal static string ContentInternalStatic
            {
                get;
                private set;
            }

            private static string ContentPrivateStatic
            {
                get;
                set;
            }

            private string ContentPrivate
            {
                get;
                set;
            }

            internal string ContentInternal
            {
                get;
                private set;
            }

            public TestRecipientPrivate(WeakActionTestCase testCase)
            {
                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuff);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffPrivate);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffInternal);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffStatic);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffPrivateStatic);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            DoStuffInternalStatic);
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        Messenger.Default.Register<string>(
                            this,
                            msg => Content = msg);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        Messenger.Default.Register<string>(
                            this,
                            msg => ContentStatic = msg);
                        break;
                }
            }

            public void DoStuff(string message)
            {
                Content = message;
            }

            private void DoStuffPrivate(string message)
            {
                Content = message;
                ContentPrivate = message;
            }

            internal void DoStuffInternal(string message)
            {
                Content = message;
                ContentInternal = message;
            }

            public static void DoStuffStatic(string message)
            {
                ContentStatic = message;
            }

            internal static void DoStuffInternalStatic(string message)
            {
                ContentStatic = message;
                ContentInternalStatic = message;
            }

            private static void DoStuffPrivateStatic(string message)
            {
                ContentStatic = message;
                ContentPrivateStatic = message;
            }

            public static void Reset()
            {
                ContentStatic = null;
                ContentPrivateStatic = null;
                ContentInternalStatic = null;
            }
        }
    }
}
