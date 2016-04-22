using System.IO;
using System.Web;

using NUnit.Framework;

namespace HermaFx.Mvc.Grid.Pagination
{
	[TestFixture]
	public class GridPagerTests
	{
		private GridPager _pager;

		[OneTimeSetUp]
		public void Init()
		{
			HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""), new HttpResponse(new StringWriter()));
			_pager = new GridPager();
		}

		[Test]
		public void PagerPageCountTest()
		{
			_pager.ItemsCount = 1200;
			_pager.PageSize = 13;

			Assert.AreEqual(_pager.PageCount, 93);
		}

		[Test]
		public void PagerDisplayingPagesTest()
		{
			_pager.ItemsCount = 1200;
			_pager.PageSize = 13;

			_pager.MaxDisplayedPages = 5;
			_pager.CurrentPage = 40;

			Assert.AreEqual(_pager.TemplateName, "_GridPager");
			Assert.AreEqual(_pager.StartDisplayedPage, 38);
			Assert.AreEqual(_pager.EndDisplayedPage, 42);
		}

		[Test]
		public void PagerCurrentPageTest()
		{
			_pager.ItemsCount = 1200;
			_pager.PageSize = 13;
			_pager.CurrentPage = 1000;

			Assert.AreEqual(_pager.PageCount, _pager.CurrentPage);
		}


	}
}
