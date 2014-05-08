using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestCustomTypeDescriptor : ViewModelBase, ICustomTypeDescriptor
    {
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            throw new NotImplementedException();
        }

        public TypeConverter GetConverter()
        {
            throw new NotImplementedException();
        }

        public EventDescriptor GetDefaultEvent()
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            throw new NotImplementedException();
        }

        public object GetEditor(Type editorBaseType)
        {
            throw new NotImplementedException();
        }

        public EventDescriptorCollection GetEvents()
        {
            throw new NotImplementedException();
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(null);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var originalProperties = TypeDescriptor.GetProperties(this, true);
            var originalArray = new PropertyDescriptor[originalProperties.Count];
            originalProperties.CopyTo(originalArray, 0);
            var result = new PropertyDescriptorCollection(originalArray, false);

            foreach (PropertyDescriptor descriptor in originalProperties)
            {
                if (descriptor.Name == TestPropertyPropertyName)
                {
                    var newDescriptor = new TestPropertyDescriptor(
                        descriptor.Name + PropertyNameSuffix,
                        typeof(string),
                        descriptor);
                    result.Add(newDescriptor);
                }
                else
                {
                    result.Add(descriptor);
                }
            }

            return result;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        public const string PropertyNameSuffix = "TestSuffix";

        /// <summary>
        /// The <see cref="TestProperty" /> property's name.
        /// </summary>
        public const string TestPropertyPropertyName = "TestProperty";

        private string _testProperty = "This is a test property";

        /// <summary>
        /// Sets and gets the TestProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TestProperty
        {
            get
            {
                return _testProperty;
            }

            set
            {
                if (_testProperty == value)
                {
                    return;
                }

                _testProperty = value;
                RaisePropertyChanged(TestPropertyPropertyName);
            }
        }

        public void RaisePropertyChangedPublic(string propertyname)
        {
            RaisePropertyChanged(propertyname);
        }
    }
}
