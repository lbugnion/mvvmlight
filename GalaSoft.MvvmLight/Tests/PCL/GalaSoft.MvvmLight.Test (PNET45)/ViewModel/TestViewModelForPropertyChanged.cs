using System;
using System.Linq.Expressions;

namespace GalaSoft.MvvmLight.Test.ViewModel
{
    public class TestViewModelForPropertyChanged : ViewModelBase
    {
        public bool RaisePropertyChangedWithExpressionWasCalled
        {
            get;
            private set;
        }

        public bool RaisePropertyChangedWithPropertyNameWasCalled
        {
            get;
            private set;
        }

        public override void RaisePropertyChanged(string propertyName = null)
        {
            // ReSharper disable once ExplicitCallerInfoArgument
            base.RaisePropertyChanged(propertyName);
            RaisePropertyChangedWithPropertyNameWasCalled = true;
        }

        public override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            base.RaisePropertyChanged(propertyExpression);
            RaisePropertyChangedWithExpressionWasCalled = true;
        }

        private bool _boolPropertyWithString;

        public bool BoolPropertyWithString
        {
            get
            {
                return _boolPropertyWithString;
            }

            set
            {
                if (_boolPropertyWithString == value)
                {
                    return;
                }

                _boolPropertyWithString = value;
                RaisePropertyChanged("BoolPropertyWithString");
            }
        }

        private bool _boolPropertyWithExpression;

        public bool BoolPropertyWithExpression
        {
            get
            {
                return _boolPropertyWithExpression;
            }

            set
            {
                if (_boolPropertyWithExpression == value)
                {
                    return;
                }

                _boolPropertyWithExpression = value;
                RaisePropertyChanged(() => BoolPropertyWithExpression);
            }
        }

        private bool _boolPropertyWithExpressionAndMessage;

        public bool BoolPropertyWithExpressionAndMessage
        {
            get
            {
                return _boolPropertyWithExpressionAndMessage;
            }

            set
            {
                if (_boolPropertyWithExpressionAndMessage == value)
                {
                    return;
                }

                var oldValue = _boolPropertyWithExpressionAndMessage;
                _boolPropertyWithExpressionAndMessage = value;
                RaisePropertyChanged(() => BoolPropertyWithExpressionAndMessage, oldValue, value, true);
            }
        }


        private bool _boolPropertyWithStringAndMessage;

        public bool BoolPropertyWithStringAndMessage
        {
            get
            {
                return _boolPropertyWithStringAndMessage;
            }

            set
            {
                if (_boolPropertyWithStringAndMessage == value)
                {
                    return;
                }

                var oldValue = _boolPropertyWithStringAndMessage;
                _boolPropertyWithStringAndMessage = value;
                // ReSharper disable once RedundantArgumentDefaultValue
                RaisePropertyChanged("BoolPropertyWithStringAndMessage", oldValue, value, true);
            }
        }

        private bool _boolPropertyWithSetAndString;

        public bool BoolPropertyWithSetAndString
        {
            get
            {
                return _boolPropertyWithSetAndString;
            }
            set
            {
                Set("BoolPropertyWithSetAndString", ref _boolPropertyWithSetAndString, value);
            }
        }


        private bool _boolPropertyWithSetAndExpression;

        public bool BoolPropertyWithSetAndExpression
        {
            get
            {
                return _boolPropertyWithSetAndExpression;
            }
            set
            {
                Set(() => BoolPropertyWithSetAndExpression, ref _boolPropertyWithSetAndExpression, value);
            }
        }

        private bool _boolPropertyWithSetAndExpressionAndMessage;

        public bool BoolPropertyWithSetAndExpressionAndMessage
        {
            get
            {
                return _boolPropertyWithSetAndExpressionAndMessage;
            }
            set
            {
                Set(() => BoolPropertyWithSetAndExpressionAndMessage, ref _boolPropertyWithSetAndExpressionAndMessage, value, true);
            }
        }


        private bool _boolPropertyWithSetAndStringAndMessage;

        public bool BoolPropertyWithSetAndStringAndMessage
        {
            get
            {
                return _boolPropertyWithSetAndStringAndMessage;
            }
            set
            {
                Set("BoolPropertyWithSetAndStringAndMessage", ref _boolPropertyWithSetAndStringAndMessage, value, true);
            }
        }
    }
}
