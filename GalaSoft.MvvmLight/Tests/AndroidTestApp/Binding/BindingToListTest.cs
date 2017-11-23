using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;

#if ANDROID
using Android.Widget;

#elif __IOS__
using UIKit;

#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    public class BindingToListTest
    {
        private Helpers.Binding _binding1;

#if ANDROID
        public EditText OutputText
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextView OutputText
        {
            get;
            private set;
        }
#endif

        public TestViewModel Vm
        {
            get;
            private set;
        }

        [Test]
        public void TestBindingToList()
        {
            Vm = GetViewModel();

            _binding1 = this.SetBinding(
                () => Vm.ItemsList[0].Title,
                () => OutputText.Text);

            Assert.AreEqual(Vm.ItemsList[0].Title, OutputText.Text);
            const string newValue = "abc";
            Vm.ItemsList[0].Title = newValue;
            Assert.AreEqual(newValue, OutputText.Text);
        }

        [Test]
        public void TestBindingToCollection()
        {
            Vm = GetViewModel();

            _binding1 = this.SetBinding(
                () => Vm.ItemsCollection[0].Title,
                () => OutputText.Text);

            Assert.AreEqual(Vm.ItemsCollection[0].Title, OutputText.Text);
            const string newValue = "abc";
            Vm.ItemsCollection[0].Title = newValue;
            Assert.AreEqual(newValue, OutputText.Text);
        }

        private TestViewModel GetViewModel()
        {
            return new TestViewModel
            {
                ItemsCollection = new ObservableCollection<TestItem>
                {
                    new TestItem("123"),
                    new TestItem("234"),
                    new TestItem("345"),
                },
                ItemsList = new List<TestItem>
                {
                    new TestItem("123"),
                    new TestItem("234"),
                    new TestItem("345"),
                }
            };
        }
    }
}