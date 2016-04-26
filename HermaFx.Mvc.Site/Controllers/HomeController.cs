using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

using HermaFx.Mvc.Site.Models;
using HermaFx.Mvc.Site.Models.Grids;
using System;

namespace HermaFx.Mvc.Site.Controllers
{
	public class HomeController : ApplicationController
	{
		public ActionResult Index()
		{
			ViewBag.ActiveMenuTitle = "Demo";
			return View();
		}

		public ActionResult Grid()
		{
			var repository = new OrdersRepository();
			var grid = new OrdersGrid(repository.GetAll());
			return PartialView("_OrdersGrid", grid);
		}

		public ActionResult About()
		{
			ViewBag.ActiveMenuTitle = "About";
			return View();
		}

		#region Test
		public ActionResult Test()
		{
			ViewBag.ActiveMenuTitle = "Test";
			return View();
		}

		public ActionResult TestGrid()
		{
			var repository = new OrdersRepository();
			var allRows = repository.GetAll().ToList();
			var currentPage = Int32.Parse(Request.QueryString["grid-page"] ?? "1");
			var columnSort = Request.QueryString["grid-column"];
			var alreadyPaged = repository.GetAll().Skip(15 * (currentPage - 1));

			//SORTING
			if (!string.IsNullOrEmpty(columnSort))
				alreadyPaged = alreadyPaged.OrderBy(columnSort);

			//PAGING
			alreadyPaged = alreadyPaged.Take(15);

			var grid = new OrdersGridTest(alreadyPaged.ToList(), currentPage, allRows.Count);
			return PartialView("_OrdersGridTest", grid);
		}
		#endregion

		[HttpPost]
		public JsonResult GetOrder(int id)
		{
			var repository = new OrdersRepository();
			Order order = repository.GetById(id);
			if (order == null)
				return Json(new { Status = 0, Message = "Not found" });

			return Json(new { Status = 1, Message = "Ok", Content = RenderPartialViewToString("_OrderInfo", order) });
		}

		[HttpPost]
		public JsonResult GetCustomersNames()
		{
			var repository = new CustomersRepository();
			var allItems = repository.GetAll().Select(c => c.CompanyName);
			return Json(new { Items = allItems });
		}

		[HttpGet]
		public ActionResult AjaxPaging()
		{
			var repository = new OrdersRepository();
			ViewBag.ActiveMenuTitle = "AjaxPaging";

			return View("Index", new OrdersAjaxPagingGrid(repository.GetAll(), 1, false));
		}

		public JsonResult GetOrdersGridRows(int page)
		{
			var repository = new OrdersRepository();
			var grid = new OrdersAjaxPagingGrid(repository.GetAll(), page, true);

			return Json(new
			{
				Html = RenderPartialViewToString("_OrdersGrid", grid),
				HasItems = grid.DisplayingItemsCount >= grid.Pager.PageSize
			}, JsonRequestBehavior.AllowGet);
		}
	}
}