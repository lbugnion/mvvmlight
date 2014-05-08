using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;

namespace GalaSoft.MvvmLight.Android.Helpers
{
    public class Binding<TProperty>
    {
        private readonly WeakReference _topSource;
        private readonly WeakReference _topTarget;
        private readonly string _sourcePropertyName;
        private readonly string _targetPropertyName;
        private readonly Expression<Func<TProperty>> _sourcePropertyExpression;
        private readonly Expression<Func<TProperty>> _targetPropertyExpression;
        private WeakReference _propertySource;
        private WeakReference _propertyTarget;
        private PropertyInfo _sourceProperty;
        private PropertyInfo _targetProperty;

        public event EventHandler ValueChanged;

        public BindingMode Mode
        {
            get;
            private set;
        }

        public object Source
        {
            get
            {
                return _topSource == null || !_topSource.IsAlive 
                    ? null 
                    : _topSource.Target;
            }
        }

        public object Target
        {
            get
            {
                return _topTarget == null || !_topTarget.IsAlive
                    ? null
                    : _topTarget.Target;
            }
        }

        public TProperty Value
        {
            get
            {
                if (_propertySource == null
                    || !_propertySource.IsAlive)
                {
                    return default(TProperty);
                }

                var type = _propertySource.Target.GetType();
                var property = type.GetProperty(_sourcePropertyName);
                return (TProperty)property.GetValue(_propertySource.Target, null);
            }
        }

        public Binding(
            object source,
            string sourcePropertyName,
            object target,
            string targetPropertyName,
            BindingMode mode = BindingMode.Default)
        {
            Mode = mode;

            _topSource = new WeakReference(source);
            _propertySource = new WeakReference(source);
            _sourcePropertyName = sourcePropertyName;

            if (target != null)
            {
                _topTarget = new WeakReference(target);
                _propertyTarget = new WeakReference(target);
            }

            _targetPropertyName = targetPropertyName;

            Attach();
        }

        public Binding(
            object source,
            Expression<Func<TProperty>> sourcePropertyExpression,
            object target = null,
            Expression<Func<TProperty>> targetPropertyExpression = null,
            BindingMode mode = BindingMode.Default)
        {
            Mode = mode;
            _sourcePropertyExpression = sourcePropertyExpression;
            _targetPropertyExpression = targetPropertyExpression;

            _topSource = new WeakReference(source);
            _topTarget = new WeakReference(target);

            _sourcePropertyName = GetPropertyName(sourcePropertyExpression);
            _targetPropertyName = GetPropertyName(targetPropertyExpression);

            Attach(
                _topSource.Target,
                _topTarget.Target,
                mode);
        }

        private void Attach(
            object source, 
            object target,
            BindingMode mode)
        {

            var sourceChain = GetPropertyChain(
                source,
                null,
                _sourcePropertyExpression.Body as MemberExpression,
                _sourcePropertyName);

            var lastSourceInChain = sourceChain.Last();
            sourceChain.Remove(lastSourceInChain);

            _propertySource = new WeakReference(lastSourceInChain.Instance);

            if (mode != BindingMode.OneTime)
            {
                foreach (var instance in sourceChain)
                {
                    var inpc = instance.Instance as INotifyPropertyChanged;
                    if (inpc != null)
                    {
                        var listener = new ObjectSwappedEventListener<TProperty>(
                            this,
                            inpc);

                        PropertyChangedEventManager.AddListener(inpc, listener, instance.Name);
                    }
                }
            }

            if (target != null
                && _targetPropertyExpression != null)
            {
                var targetChain = GetPropertyChain(
                    target,
                    null,
                    _targetPropertyExpression.Body as MemberExpression,
                    _targetPropertyName);

                var lastTargetInChain = targetChain.Last();
                targetChain.Remove(lastTargetInChain);

                _propertyTarget = new WeakReference(lastTargetInChain.Instance);

                if (mode != BindingMode.OneTime
                    && mode != BindingMode.OneWay)
                {
                    foreach (var instance in targetChain)
                    {
                        var inpc = instance.Instance as INotifyPropertyChanged;
                        if (inpc != null)
                        {
                            var listener = new ObjectSwappedEventListener<TProperty>(
                                this,
                                inpc);

                            PropertyChangedEventManager.AddListener(inpc, listener, instance.Name);
                        }
                    }
                }
            }
            
            Attach();
        }

        public Binding<TProperty> SetSourceEvent(string eventName)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                return this;
            }

            if (Mode == BindingMode.OneTime)
            {
                throw new InvalidOperationException("This method cannot be used with OneTime bindings");
            }

            if (_propertySource == null
                || !_propertySource.IsAlive
                || _propertySource.Target == null)
            {
                throw new InvalidOperationException("Source is not ready");
            }

            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException("eventName");
            }

            var type = _propertySource.Target.GetType();

            var ev = type.GetEvent(eventName);
            if (ev == null)
            {
                throw new ArgumentException(
                    "Event not found: " + eventName,
                    "eventName");
            }

            // TODO Do we need weak events here?
            EventHandler handler = (s, args) =>
            {
                if (_propertyTarget != null
                    && _propertyTarget.IsAlive
                    && _propertyTarget.Target != null
                    && _propertySource != null
                    && _propertySource.IsAlive
                    && _propertySource.Target != null)
                {
                    var valueLocal = _sourceProperty.GetValue(_propertySource.Target, null);
                    _targetProperty.SetValue(_propertyTarget.Target, valueLocal, null);
                }

                RaiseValueChanged();
            };

            ev.AddEventHandler(
                _propertySource.Target,
                handler);

            return this;
        }

        public Binding<TProperty> SetSourceEvent<TEventArgs>(string eventName)
            where TEventArgs : EventArgs
        {
            if (string.IsNullOrEmpty(eventName))
            {
                return this;
            }

            if (Mode == BindingMode.OneTime)
            {
                throw new InvalidOperationException("This method cannot be used with OneTime bindings");
            }

            if (_propertySource == null
                || !_propertySource.IsAlive
                || _propertySource.Target == null)
            {
                throw new InvalidOperationException("Source is not ready");
            }

            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException("eventName");
            }

            var type = _propertySource.Target.GetType();

            var ev = type.GetEvent(eventName);
            if (ev == null)
            {
                throw new ArgumentException(
                    "Event not found: " + eventName,
                    "eventName");
            }

            // TODO Do we need weak events here?
            EventHandler<TEventArgs> handler = (s, args) =>
            {
                if (_propertyTarget != null
                    && _propertyTarget.IsAlive
                    && _propertyTarget.Target != null
                    && _propertySource != null
                    && _propertySource.IsAlive
                    && _propertySource.Target != null)
                {
                    var valueLocal = _sourceProperty.GetValue(_propertySource.Target, null);
                    _targetProperty.SetValue(_propertyTarget.Target, valueLocal, null);
                }

                RaiseValueChanged();
            };

            ev.AddEventHandler(
                Source,
                handler);

            return this;
        }

        public Binding<TProperty> SetTargetEvent(string eventName)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                return this;
            }

            if (Mode == BindingMode.OneTime
                || Mode == BindingMode.OneWay)
            {
                throw new InvalidOperationException("This method cannot be used with OneTime or OneWay bindings");
            }

            // TODO Should also use the target chain

            if (_propertyTarget == null
                || !_propertyTarget.IsAlive
                || _propertyTarget.Target == null)
            {
                throw new InvalidOperationException("Target is not ready");
            }

            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException("eventName");
            }

            var type = _propertyTarget.Target.GetType();

            var ev = type.GetEvent(eventName);
            if (ev == null)
            {
                throw new ArgumentException(
                    "Event not found: " + eventName,
                    "eventName");
            }

            // TODO Do we need weak events here?
            EventHandler handler = (s, args) =>
            {
                if (_propertyTarget != null
                    && _propertyTarget.IsAlive
                    && _propertyTarget.Target != null
                    && _propertySource != null
                    && _propertySource.IsAlive
                    && _propertySource.Target != null)
                {
                    var valueLocal = _targetProperty.GetValue(_propertyTarget.Target, null);
                    _sourceProperty.SetValue(_propertySource.Target, valueLocal, null);
                }

                RaiseValueChanged();
            };

            ev.AddEventHandler(
                _propertyTarget.Target,
                handler);

            return this;
        }

        public Binding<TProperty> SetTargetEvent<TEventArgs>(string eventName)
            where TEventArgs : EventArgs
        {
            if (string.IsNullOrEmpty(eventName))
            {
                return this;
            }

            if (Mode == BindingMode.OneTime
                || Mode == BindingMode.OneWay)
            {
                throw new InvalidOperationException("This method cannot be used with OneTime or OneWay bindings");
            }

            if (_propertyTarget == null
                || !_propertyTarget.IsAlive
                || _propertyTarget.Target == null)
            {
                throw new InvalidOperationException("Target is not ready");
            }

            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException("eventName");
            }

            var type = _propertyTarget.Target.GetType();

            var ev = type.GetEvent(eventName);
            if (ev == null)
            {
                throw new ArgumentException(
                    "Event not found: " + eventName,
                    "eventName");
            }

            // TODO Do we need weak events here?
            EventHandler<TEventArgs> handler = (s, args) =>
            {
                if (_propertyTarget != null
                    && _propertyTarget.IsAlive
                    && _propertyTarget.Target != null
                    && _propertySource != null
                    && _propertySource.IsAlive
                    && _propertySource.Target != null)
                {
                    var valueLocal = _targetProperty.GetValue(_propertyTarget.Target, null);
                    _sourceProperty.SetValue(_propertySource.Target, valueLocal, null);
                }

                RaiseValueChanged();
            };

            ev.AddEventHandler(
                _propertyTarget.Target,
                handler);

            return this;
        }

        private static IList<PropertyAndName> GetPropertyChain(
            object topInstance,
            IList<PropertyAndName> instances,
            MemberExpression expression,
            string propertyName,
            bool top = true)
        {
            if (instances == null)
            {
                instances = new List<PropertyAndName>();
            }

            var ex = expression.Expression as MemberExpression;

            if (ex == null)
            {
                if (top)
                {
                    instances.Add(
                        new PropertyAndName
                        {
                            Instance = topInstance,
                            Name = propertyName
                        });
                }

                return instances;
            }

            var list = GetPropertyChain(topInstance, instances, ex, propertyName, false);

            if (list.Count == 0)
            {
                list.Add(
                    new PropertyAndName
                    {
                        Instance = topInstance,
                    });
            }

            if (top
                && list.Count > 0
                && list.First().Instance != topInstance)
            {
                list.Insert(
                    0,
                    new PropertyAndName
                    {
                        Instance = topInstance
                    });
            }
            
            var lastInstance = list.Last();

            if (lastInstance.Instance != null)
            {
                var prop = ex.Member as PropertyInfo;

                if (prop != null)
                {
                    var newInstance = prop.GetGetMethod().Invoke(
                        lastInstance.Instance,
                        new object[]
                    {
                    });

                    lastInstance.Name = prop.Name;

                    list.Add(
                        new PropertyAndName
                        {
                            Instance = newInstance,
                        });
                }

                if (top)
                {
                    list.Last().Name = propertyName;
                }
            }

            return list;
        }

        public class PropertyAndName
        {
            public object Instance;
            public string Name;
        }

        private static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                return null;
            }

            var body = propertyExpression.Body as MemberExpression;

            if (body == null)
            {
                throw new ArgumentException("Invalid argument", "propertyExpression");
            }

            var property = body.Member as PropertyInfo;

            if (property == null)
            {
                throw new ArgumentException("Argument is not a property", "propertyExpression");
            }

            return property.Name;
        }

        private void Attach()
        {
            if (_propertySource == null
                || !_propertySource.IsAlive
                || _propertySource.Target == null)
            {
                return;
            }

            if (_propertyTarget != null
                && _propertyTarget.IsAlive
                && _propertyTarget.Target != null
                && !string.IsNullOrEmpty(_targetPropertyName))
            {
                var targetType = _propertyTarget.Target.GetType();
                _targetProperty = targetType.GetProperty(_targetPropertyName);

                if (_targetProperty == null)
                {
                    throw new InvalidOperationException("Property not found: " + _targetPropertyName);
                }
            }

            var sourceType = _propertySource.Target.GetType();
            _sourceProperty = sourceType.GetProperty(_sourcePropertyName);

            if (_sourceProperty == null)
            {
                throw new InvalidOperationException("Property not found: " + _sourcePropertyName);
            }

            // OneTime binding
            var value = _sourceProperty.GetValue(_propertySource.Target, null);

            if (_targetProperty != null
                && _propertyTarget != null
                && _propertyTarget.IsAlive
                && _propertyTarget.Target != null)
            {
                _targetProperty.SetValue(_propertyTarget.Target, value, null);
            }

            if (Mode == BindingMode.OneTime)
            {
                return;
            }

            // Check OneWay binding
            var inpc = _propertySource.Target as INotifyPropertyChanged;

            if (inpc != null)
            {
                var listener = new PropertyChangedEventListener<TProperty>(
                    this,
                    true);

                PropertyChangedEventManager.AddListener(inpc, listener, _sourcePropertyName);
            }

            if (Mode == BindingMode.OneWay
                || Mode == BindingMode.Default)
            {
                return;
            }

            // Check TwoWay binding
            if (_propertyTarget != null
                && _propertyTarget.IsAlive
                && _propertyTarget.Target != null)
            {
                var inpc2 = _propertyTarget.Target as INotifyPropertyChanged;

                if (inpc2 != null)
                {
                    var listener = new PropertyChangedEventListener<TProperty>(
                        this,
                        false);

                    PropertyChangedEventManager.AddListener(inpc2, listener, _targetPropertyName);
                }
            }
        }

        public void ForceUpdateValueFromTargetToSource()
        {
            if (_propertyTarget == null
                || !_propertyTarget.IsAlive
                || _propertyTarget.Target == null
                || _propertySource == null
                || !_propertySource.IsAlive
                || _propertySource.Target == null)
            {
                return;
            }

            if (_targetProperty != null)
            {
                var valueLocal = _targetProperty.GetValue(Target, null);
                _sourceProperty.SetValue(_propertySource.Target, valueLocal, null);
            }

            RaiseValueChanged();
        }

        public void ForceUpdateValueFromSourceToTarget()
        {
            if (_propertyTarget == null
                || !_propertyTarget.IsAlive
                || _propertyTarget.Target == null
                || _propertySource == null
                || !_propertySource.IsAlive
                || _propertySource.Target == null)
            {
                return;
            }

            if (_targetProperty != null)
            {
                var valueLocal = _sourceProperty.GetValue(_propertySource.Target, null);
                _targetProperty.SetValue(Target, valueLocal, null);
            }

            RaiseValueChanged();
        }

        private void RaiseValueChanged()
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public class ObjectSwappedEventListener<T> : IWeakEventListener
        {
            private readonly WeakReference _bindingReference;
            private readonly WeakReference _instanceReference;

            public ObjectSwappedEventListener(
                Binding<T> binding,
                INotifyPropertyChanged instance)
            {
                _bindingReference = new WeakReference(binding);
                _instanceReference = new WeakReference(instance);
            }

            public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
            {
                var propArgs = e as PropertyChangedEventArgs;

                if (_instanceReference.Target == sender
                    && propArgs != null
                    && _bindingReference != null
                    && _bindingReference.IsAlive
                    && _bindingReference.Target != null)
                {
                    var binding = ((Binding<T>)_bindingReference.Target);
                    binding.Attach(
                        binding.Source,
                        binding.Target,
                        binding.Mode);
                    return true;
                }

                return false;
            }
        }

        public class PropertyChangedEventListener<T> : IWeakEventListener
        {
            private readonly WeakReference _bindingReference;
            private readonly bool _updateFromSourceToTarget;

            public PropertyChangedEventListener(
                Binding<T> binding, 
                bool updateFromSourceToTarget)
            {
                _updateFromSourceToTarget = updateFromSourceToTarget;
                _bindingReference = new WeakReference(binding);
            }

            public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
            {
                if (_bindingReference != null
                    && _bindingReference.IsAlive
                    && _bindingReference.Target != null)
                {
                    var binding = ((Binding<T>)_bindingReference.Target);

                    if (_updateFromSourceToTarget)
                    {
                        binding.ForceUpdateValueFromSourceToTarget();
                    }
                    else
                    {
                        binding.ForceUpdateValueFromTargetToSource();
                    }

                    return true;
                }

                return false;
            }
        }
    }

    public enum BindingMode
    {
        Default = 0,
        OneTime = 1,
        OneWay = 2,
        TwoWay = 3
    }
}