using System.ComponentModel;

namespace GalaSoft.MvvmLight.Test.Bindings
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public const string SimpleProperty1PropertyName = "SimpleProperty1";

        private string _simpleProperty1;

        public string SimpleProperty1
        {
            get
            {
                return _simpleProperty1;
            }

            set
            {
                if (_simpleProperty1 == value)
                {
                    return;
                }

                _simpleProperty1 = value;
                RaisePropertyChanged(SimpleProperty1PropertyName);
            }
        }

        public const string SimpleProperty2PropertyName = "SimpleProperty2";

        private string _simpleProperty2;

        public string SimpleProperty2
        {
            get
            {
                return _simpleProperty2;
            }

            set
            {
                if (_simpleProperty2 == value)
                {
                    return;
                }

                _simpleProperty2 = value;
                RaisePropertyChanged(SimpleProperty2PropertyName);
            }
        }

        public const string ObjectPropertyPropertyName = "ObjectProperty";

        private ObservableObject _objectProperty;

        public ObservableObject ObjectProperty
        {
            get
            {
                return _objectProperty;
            }
            set
            {
                if (_objectProperty == value)
                {
                    return;
                }

                _objectProperty = value;
                RaisePropertyChanged(ObjectPropertyPropertyName);
            }
        }
        
        protected virtual void RaisePropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string UniqueId
        {
            get;
            set;
        }

        public UiElementFake UiElement
        {
            get;
            set;
        }
    }
}