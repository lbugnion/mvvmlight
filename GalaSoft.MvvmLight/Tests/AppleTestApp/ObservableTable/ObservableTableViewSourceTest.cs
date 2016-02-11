using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;
using UIKit;

namespace GalaSoft.MvvmLight.Test.ObservableTable
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ObservableTableViewSourceTest
    {
        private UITableView _tableView;

        public TestViewModel Vm
        {
            get;
            private set;
        }

        [Test]
        public void ObservableTableViewSource_GetSourceWithCollectionCheckingItemCount()
        {
            Vm = GetViewModel();
            _tableView = new UITableView();

            var source = Vm.ItemsCollection.GetTableViewSource(
                CreateCell,
                BindCell);

            _tableView.Source = source;

            Assert.AreEqual(
                Vm.ItemsCollection.Count,
                _tableView.NumberOfRowsInSection(0));

            Vm.ItemsCollection.Add(new TestItem("New one"));

            Assert.AreEqual(
                Vm.ItemsCollection.Count,
                _tableView.NumberOfRowsInSection(0));
        }

        [Test]
        public void ObservableTableViewSource_GetSourceWithCollectionGettingLastItem()
        {
            Vm = new TestViewModel
            {
                ItemsCollection = new ObservableCollection<TestItem>()
            };

            _tableView = new UITableView();

            var source = Vm.ItemsCollection.GetTableViewSource(
                CreateCell,
                BindCell);

            _tableView.Source = source;

            Assert.AreEqual(
                Vm.ItemsCollection.Count,
                _tableView.NumberOfRowsInSection(0));

            // In unit tests, GetCell only gets called for the first inserted row (no layout pass)
            Vm.ItemsCollection.Add(new TestItem("One"));

            var lastCell = _tableView.CellAt(Vm.ItemsCollection.First().RowIndexPath);

            Assert.AreEqual(
                Vm.ItemsCollection.Last().Title,
                lastCell.TextLabel.Text);
        }

        [Test]
        public void ObservableTableViewSource_GetSourceWithListCheckingItemCount()
        {
            Vm = GetViewModel();
            _tableView = new UITableView();

            var source = Vm.ItemsList.GetTableViewSource(
                CreateCell,
                BindCell);

            _tableView.Source = source;

            Assert.AreEqual(
                Vm.ItemsList.Count,
                _tableView.NumberOfRowsInSection(0));
        }

        [Test]
        public void ObservableTableViewSource_NewSourceWithCollectionCheckingItemCount()
        {
            Vm = GetViewModel();
            _tableView = new UITableView();

            var source = new ObservableTableViewSource<TestItem>
            {
                CreateCellDelegate = CreateCell,
                BindCellDelegate = BindCell,
                DataSource = Vm.ItemsCollection,
            };

            _tableView.Source = source;

            Assert.AreEqual(
                Vm.ItemsCollection.Count,
                _tableView.NumberOfRowsInSection(0));

            Vm.ItemsCollection.Add(new TestItem("New one"));

            Assert.AreEqual(
                Vm.ItemsCollection.Count,
                _tableView.NumberOfRowsInSection(0));
        }

        [Test]
        public void ObservableTableViewSource_NewSourceWithCollectionGettingLastItem()
        {
            Vm = new TestViewModel
            {
                ItemsCollection = new ObservableCollection<TestItem>()
            };

            _tableView = new UITableView();

            var source = new ObservableTableViewSource<TestItem>
            {
                CreateCellDelegate = CreateCell,
                BindCellDelegate = BindCell,
                DataSource = Vm.ItemsCollection,
            };

            _tableView.Source = source;

            Assert.AreEqual(
                Vm.ItemsCollection.Count,
                _tableView.NumberOfRowsInSection(0));

            // In unit tests, GetCell only gets called for the first inserted row (no layout pass)
            Vm.ItemsCollection.Add(new TestItem("One"));

            var lastCell = _tableView.CellAt(Vm.ItemsCollection.First().RowIndexPath);

            Assert.AreEqual(
                Vm.ItemsCollection.Last().Title,
                lastCell.TextLabel.Text);
        }

        [Test]
        public void ObservableTableViewSource_NewSourceWithListCheckingItemCount()
        {
            Vm = GetViewModel();
            _tableView = new UITableView();

            var source = new ObservableTableViewSource<TestItem>
            {
                CreateCellDelegate = CreateCell,
                BindCellDelegate = BindCell,
                DataSource = Vm.ItemsList,
            };

            _tableView.Source = source;

            Assert.AreEqual(
                Vm.ItemsList.Count,
                _tableView.NumberOfRowsInSection(0));
        }

        private void BindCell(UITableViewCell cell, TestItem item, NSIndexPath path)
        {
            item.RowIndexPath = path;
            cell.TextLabel.Text = item.Title;
        }

        private UITableViewCell CreateCell(NSString reuseId)
        {
            return new UITableViewCell(UITableViewCellStyle.Default, reuseId);
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
                    new TestItem("456"),
                }
            };
        }
    }
}