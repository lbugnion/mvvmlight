using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingDeepPathTest
    {
        private Helpers.Binding _binding;

        public TestViewModel VmSource
        {
            get;
            private set;
        }

        public TestViewModel VmTarget
        {
            get;
            private set;
        }

        [Test]
        public void BindingDeepPath_DeepSourceExistingPathChangingObjects_NoError()
        {
            VmSource = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Nested = new TestViewModel
                    {
                        Model = new TestModel
                        {
                            StringProperty = "Initial value"
                        }
                    }
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Nested.Nested.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Nested.Nested.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Nested.Nested.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Nested.Nested.Model.StringProperty, VmTarget.TargetProperty);

            const string value2 = "Value 2";

            VmSource.Nested = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Model = new TestModel
                    {
                        StringProperty = value2
                    }
                }
            };

            Assert.AreEqual(value2, VmTarget.TargetProperty);

            const string value3 = "Value 3";

            VmSource.Nested.Nested = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = value3
                }
            };

            Assert.AreEqual(value3, VmTarget.TargetProperty);

            const string value4 = "Value 4";

            VmSource.Nested.Nested.Model = new TestModel
            {
                StringProperty = value4
            };

            Assert.AreEqual(value4, VmTarget.TargetProperty);

            const string value5 = "Value 5";

            VmSource.Nested.Nested.Model.StringProperty = value5;

            Assert.AreEqual(value5, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingDeepPath_DeepSourceExistingPathGraduallySettingPath_NoError()
        {
            VmSource = new TestViewModel();
            VmTarget = new TestViewModel();

            const string fallback = "This is the fallback";
            const string targetNull = "Target is null";

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Nested.Nested.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty,
                fallbackValue: fallback,
                targetNullValue: targetNull);

            Assert.AreEqual(fallback, VmTarget.TargetProperty);
            VmSource.Nested = new TestViewModel();
            Assert.AreEqual(fallback, VmTarget.TargetProperty);
            VmSource.Nested.Nested = new TestViewModel();
            Assert.AreEqual(fallback, VmTarget.TargetProperty);
            VmSource.Nested.Nested.Model = new TestModel();
            Assert.AreEqual(targetNull, VmTarget.TargetProperty);
            var initialValue = "Initial value";
            VmSource.Nested.Nested.Model.StringProperty = initialValue;
            Assert.AreEqual(initialValue, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Nested.Nested.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingDeepPath_DeepSourceSetPath_NoError()
        {
            VmSource = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Nested = new TestViewModel
                    {
                        Model = new TestModel
                        {
                            StringProperty = "Initial value"
                        }
                    }
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Nested.Nested.Model.StringProperty,
                VmTarget,
                () => VmTarget.TargetProperty);

            Assert.AreEqual(VmSource.Nested.Nested.Model.StringProperty, VmTarget.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Nested.Nested.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Nested.Nested.Model.StringProperty, VmTarget.TargetProperty);
        }

        [Test]
        public void BindingDeepPath_DeepTargetExistingPathChangingObjects_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Nested = new TestViewModel
                    {
                        Nested = new TestViewModel()
                    }
                }
            };

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.Nested.Nested.Nested.TargetProperty);

            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.Nested.Nested.Nested.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, VmTarget.Nested.Nested.Nested.TargetProperty);

            VmTarget.Nested = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Nested = new TestViewModel()
                }
            };

            Assert.AreEqual(newValue, VmTarget.Nested.Nested.Nested.TargetProperty);

            VmTarget.Nested.Nested = new TestViewModel
            {
                Nested = new TestViewModel()
            };

            Assert.AreEqual(newValue, VmTarget.Nested.Nested.Nested.TargetProperty);

            VmTarget.Nested.Nested.Nested = new TestViewModel();

            Assert.AreEqual(newValue, VmTarget.Nested.Nested.Nested.TargetProperty);
        }

        [Test]
        public void BindingDeepPath_DeepTargetExistingPathGraduallySettingPath_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            VmTarget = new TestViewModel();

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.Nested.Nested.Nested.TargetProperty);

            VmTarget.Nested = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Nested = new TestViewModel()
                }
            };

            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.Nested.Nested.Nested.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, VmTarget.Nested.Nested.Nested.TargetProperty);
        }

        [Test]
        public void BindingDeepPath_DeepTargetSetPath_NoError()
        {
            VmTarget = new TestViewModel
            {
                Nested = new TestViewModel
                {
                    Nested = new TestViewModel
                    {
                        Nested = new TestViewModel()
                    }
                }
            };

            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                VmTarget,
                () => VmTarget.Nested.Nested.Nested.TargetProperty);

            Assert.AreEqual(VmSource.Model.StringProperty, VmTarget.Nested.Nested.Nested.TargetProperty);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, VmTarget.Nested.Nested.Nested.TargetProperty);
        }
    }
}