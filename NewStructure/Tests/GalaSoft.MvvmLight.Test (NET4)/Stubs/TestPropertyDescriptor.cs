using System;
using System.ComponentModel;
using System.Reflection;

namespace GalaSoft.MvvmLight.Test.Stubs
{
    public class TestPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor _originalDescriptor;
        private readonly Type _propertyType;

        public TestPropertyDescriptor(
            string name, 
            Type propertyType,
            PropertyDescriptor originalDescriptor)
            : base(name, null)
        {
            _propertyType = propertyType;
            _originalDescriptor = originalDescriptor;
        }

        public override bool CanResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(object component)
        {
            return _originalDescriptor.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(object component, object value)
        {
            _originalDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            throw new NotImplementedException();
        }

        public override Type ComponentType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return _propertyType;
            }
        }
    }
}
