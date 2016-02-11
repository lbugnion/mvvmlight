using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;
using UIKit;

namespace GalaSoft.MvvmLight.Test.ObservableTable
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ReuseIdTest
    {
        public TestViewModel Vm
        {
            get;
            private set;
        }

        [Test]
        public void ObservableTableViewController_WithCollectionAndDefaultReuseId()
        {
            Vm = GetViewModel();

            var table = Vm.ItemsCollection.GetController(CreateCell, BindCell);
            table.TableView = new UITableView();
            Assert.AreEqual(null, table.ReuseId);
        }

        [Test]
        public void ObservableTableViewController_WithCollectionAndSetReuseId()
        {
            Vm = GetViewModel();

            const string reuseId = "1234";

            var table = Vm.ItemsCollection.GetController(CreateCell, BindCell, reuseId);
            table.TableView = new UITableView();
            Assert.AreEqual(reuseId, table.ReuseId);
        }

        [Test]
        public void ObservableTableViewController_WithListAndDefaultReuseId()
        {
            Vm = GetViewModel();

            var table = Vm.ItemsList.GetController(CreateCell, BindCell);
            table.TableView = new UITableView();
            Assert.AreEqual(null, table.ReuseId);
        }

        [Test]
        public void ObservableTableViewController_WithListAndSetReuseId()
        {
            Vm = new TestViewModel
            {
                ItemsCollection = new ObservableCollection<TestItem>()
            };

            const string reuseId = "1234";

            var table = Vm.ItemsList.GetController(CreateCell, BindCell, reuseId);
            table.TableView = new UITableView();
            Assert.AreEqual(reuseId, table.ReuseId);
        }

        private void BindCell(UITableViewCell cell, TestItem item, NSIndexPath path)
        {
            item.RowIndexPath = path;
            cell.TextLabel.Text = item.Title;
        }

        private UITableViewCell CreateCell(NSString reuseId)
        {
            return new TestUiTableViewCell(reuseId);
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
                    new TestItem("456"),
                },
                ItemsList = new List<TestItem>
                {
                    new TestItem("123"),
                    new TestItem("234"),
                    new TestItem("345"),
                    new TestItem("456"),
                }
            };
        }
    }
}