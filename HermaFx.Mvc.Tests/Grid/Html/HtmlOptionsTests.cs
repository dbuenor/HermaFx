using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using NUnit.Framework;
using Moq;

namespace HermaFx.Mvc.Grid.Html
{
	[TestFixture]
	public class HtmlOptionsTests
	{
		private TestGrid _grid;
		private GridHtmlOptions<TestModel> _opt;

		[OneTimeSetUp]
		public void Init()
		{
			HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
			_grid = new TestGrid(Enumerable.Empty<TestModel>());
			var viewContextMock = new Mock<ViewContext>();
			_opt = new GridHtmlOptions<TestModel>(_grid, viewContextMock.Object, "_Grid");
		}

		[Test]
		public void TestMainMethods()
		{
			_opt.WithPaging(5);
			Assert.IsTrue(_grid.EnablePaging);
			Assert.AreEqual(_grid.Pager.PageSize, 5);

			_opt.WithMultipleFilters();
			Assert.IsTrue(_grid.RenderOptions.AllowMultipleFilters);

			_opt.Named("test");
			Assert.AreEqual(_grid.RenderOptions.GridName, "test");

			_opt.Selectable(true);
			Assert.IsTrue(_grid.RenderOptions.Selectable);
		}
	}
}
