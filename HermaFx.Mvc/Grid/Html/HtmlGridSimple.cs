using System.Collections.Generic;
using System.Web.Mvc;
using HermaFx.Mvc.Grid.Columns;
using HermaFx.Mvc.Grid.Pagination;

namespace HermaFx.Mvc.Grid.Html
{
	/// <summary>
	///     Grid adapter for html helper
	/// </summary>
	public class HtmlGridSimple<T> : GridSimpleHtmlOptions<T>, IGridBase where T : class
	{
		private readonly GridSimple<T> _source;


		public HtmlGridSimple(GridSimple<T> source, ViewContext viewContext, string viewName)
			: base(source, viewContext, viewName)
		{
			_source = source;
		}

		public GridRenderOptions RenderOptions
		{
			get { return _source.RenderOptions; }
		}

		IGridColumnCollection IGridBase.Columns
		{
			get { return _source.Columns; }
		}

		IEnumerable<object> IGridBase.ItemsToDisplay
		{
			get { return (_source as IGridBase).ItemsToDisplay; }
		}

		//int IGrid.ItemsCount
		//{
		//    get { return _source.ItemsCount; }
		//    set { _source.ItemsCount = value; }
		//}

		int IGridBase.DisplayingItemsCount
		{
			get { return _source.DisplayingItemsCount; }
		}

		IGridPager IGridBase.Pager
		{
			get { return _source.Pager; }
		}

		bool IGridBase.EnablePaging
		{
			get { return _source.EnablePaging; }
		}

		string IGridBase.EmptyGridText
		{
			get { return _source.EmptyGridText; }
		}

		string IGridBase.Language
		{
			get { return _source.Language; }
		}

		public ISanitizer Sanitizer
		{
			get { return _source.Sanitizer; }
		}

		string IGridBase.GetRowCssClasses(object item)
		{
			return _source.GetRowCssClasses(item);
		}

		/// <summary>
		///     To show Grid Items count
		///     - Author by Jeeva
		/// </summary>
		int IGridBase.ItemsCount
		{
			get { return _source.ItemsCount; }
		}

		IGridSettingsProvider IGridBase.Settings
		{
			get { return _source.Settings; }
		}
	}
}