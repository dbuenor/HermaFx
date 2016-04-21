using System;
using System.IO;
using System.Linq;
using System.Web;

using NUnit.Framework;

using HermaFx.Mvc.Grid.Columns;
using HermaFx.Mvc.Grid.DataAnnotations;

namespace HermaFx.Mvc.Grid.Columns
{
    [TestFixture]
    public class ColumnTests
    {
        private TestGrid _grid;
        private GridColumnCollection<TestModel> _columns;

        [Test]
        public void Init()
        {
            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter()));

            var repo = new TestRepository();

            var items = repo.GetAll().ToList();

            _grid = new TestGrid(items);

            _columns = new GridColumnCollection<TestModel>(new DefaultColumnBuilder<TestModel>(_grid, new GridAnnotaionsProvider()), _grid.Settings.SortSettings);
        }

        [Test]
        public void TestColumnsRetriveByMemberExpression()
        {
            var addedColumn = _columns.Add(x => x.Created);
            var column = _columns.Get(x => x.Created);

            Assert.AreEqual(addedColumn, column);
        }

        [Test]
        public void TestColumnsRetriveByName()
        {
            var addedColumn = _columns.Add(x => x.Created);
            var column = _columns.GetByName("Created");

            Assert.AreEqual(addedColumn, column);
        }


        [Test]
        public void TestRenderingEmptyValueIfNullReferenceOccurs()
        {
            var addedColumn = _columns.Add(x => x.Child.ChildTitle);

            var cell = addedColumn.GetCell(new TestModel
            {
                Child = null
            });

            Assert.AreEqual(cell.Value, string.Empty);
        }

        [Test]
        public void TestColumnsRetriveByNameWithCustomName()
        {
            var addedColumn = _columns.Add(x => x.Created, "My_Column");
            var column = _columns.GetByName("My_Column");

            Assert.AreEqual(addedColumn, column);
        }

        [Test]
        public void TestColumnsCollection()
        {
            _columns.Add();
            _columns.Add();

            _columns.Add(x => x.List[0].ChildCreated);
            _columns.Add(x => x.List[1].ChildCreated, "t1");

            _columns.Add(x => x.Id);
            Assert.AreEqual(_columns.Count(), 5);
            try
            {
                _columns.Add(x => x.Id);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            _columns.Insert(0, x => x.Title);
            Assert.AreEqual(_columns.Count(), 6);
            Assert.AreEqual(_columns.ElementAt(0).Name, "Title");
            //test hidden columns

            _columns.Add(x => x.Created, true);
            Assert.AreEqual(_columns.Count(), 7);
        }

        [Test]
        public void TestColumnInternalNameSetup()
        {
            const string name = "MyId";
            var column = _columns.Add(x => x.Id, name);
            Assert.AreEqual(column.Name, name);
        }
    }
}