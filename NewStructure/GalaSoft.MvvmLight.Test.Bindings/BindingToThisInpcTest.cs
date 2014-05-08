using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Helpers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    [TestClass]
    public class BindingToThisInpcTest : INotifyPropertyChanged
    {
        public ObservableObject ObjectProperty
        {
            get;
            private set;
        }

        public string SimpleProperty
        {
            get;
            private set;
        }

        public SimpleObject TargetSimpleObject
        {
            get;
            private set;
        }

        public const string ObservablePropertyPropertyName = "ObservableProperty";

        private string _observableProperty;

        public string ObservableProperty
        {
            get
            {
                return _observableProperty;
            }

            set
            {
                if (_observableProperty == value)
                {
                    return;
                }

                _observableProperty = value;
                RaisePropertyChanged();
            }
        }

        public const string ObservableObjectPropertyPropertyName = "ObservableObjectProperty";

        private ObservableObject _observableObjectProperty;

        public ObservableObject ObservableObjectProperty
        {
            get
            {
                return _observableObjectProperty;
            }

            set
            {
                if (_observableObjectProperty == value)
                {
                    return;
                }

                _observableObjectProperty = value;
                RaisePropertyChanged();
            }
        }

        [TestMethod]
        public void TestBindingToThisNonObservableProperty()
        {
            SimpleProperty = "TestBindingToThisInpc";

            var target = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => SimpleProperty,
                target,
                () => target.SimpleProperty2);

            var oldValue = target.SimpleProperty2;
            Assert.AreEqual(target.SimpleProperty2, SimpleProperty);
            SimpleProperty = "Another";
            Assert.AreEqual(oldValue, target.SimpleProperty2);
            Assert.AreNotEqual(target.SimpleProperty2, SimpleProperty);
        }

        [TestMethod]
        public void TestBindingToSameThisNonObservableProperty()
        {
            SimpleProperty = "TestBindingToThisInpc";

            TargetSimpleObject = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => SimpleProperty,
                () => TargetSimpleObject.SimpleProperty2);

            var oldValue = TargetSimpleObject.SimpleProperty2;
            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, SimpleProperty);
            SimpleProperty = "Another";
            Assert.AreEqual(oldValue, TargetSimpleObject.SimpleProperty2);
            Assert.AreNotEqual(TargetSimpleObject.SimpleProperty2, SimpleProperty);
        }

        [TestMethod]
        public void TestBindingToThisObservableProperty()
        {
            ObservableProperty = "TestBindingToThisInpcAndObserve";

            var target = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => ObservableProperty,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, ObservableProperty);
            ObservableProperty = "Another";
            Assert.AreEqual(target.SimpleProperty2, ObservableProperty);
        }

        [TestMethod]
        public void TestBindingToSameThisObservableProperty()
        {
            ObservableProperty = "TestBindingToThisInpcAndObserve";

            TargetSimpleObject = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => ObservableProperty,
                () => TargetSimpleObject.SimpleProperty2);

            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, ObservableProperty);
            ObservableProperty = "Another";
            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, ObservableProperty);
        }

        [TestMethod]
        public void TestBindingToThisObservableObjectProperty()
        {
            ObjectProperty = new ObservableObject
            {
                SimpleProperty1 = "TestBindingToThisProperty"
            };

            var target = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => ObjectProperty.SimpleProperty1,
                target,
                () => target.SimpleProperty2);

            Assert.AreEqual(target.SimpleProperty2, ObjectProperty.SimpleProperty1);
            ObjectProperty.SimpleProperty1 = "New value";
            Assert.AreEqual(target.SimpleProperty2, ObjectProperty.SimpleProperty1);
        }

        [TestMethod]
        public void TestBindingToSameThisObservableObjectProperty()
        {
            ObjectProperty = new ObservableObject
            {
                SimpleProperty1 = "TestBindingToThisProperty"
            };

            TargetSimpleObject = new SimpleObject();

            var binding = new Binding<string>(
                this,
                () => ObjectProperty.SimpleProperty1,
                () => TargetSimpleObject.SimpleProperty2);

            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, ObjectProperty.SimpleProperty1);
            ObjectProperty.SimpleProperty1 = "New value";
            Assert.AreEqual(TargetSimpleObject.SimpleProperty2, ObjectProperty.SimpleProperty1);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}