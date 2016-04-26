﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HermaFx.Mvc.Grid.Columns;
using HermaFx.Mvc.Grid.DataAnnotations;
using HermaFx.Mvc.Grid.Filtering;
using HermaFx.Mvc.Grid.Html;
using HermaFx.Mvc.Grid.Pagination;
using HermaFx.Mvc.Grid.Resources;
using HermaFx.Mvc.Grid.Sorting;

namespace HermaFx.Mvc.Grid
{
	/// <summary>
	///     Grid.Mvc base class
	/// </summary>
	public class GridSimple<T> : GridSimpleBase<T>, IGrid<T> where T : class
	{
		private readonly IGridAnnotationsProvider _annotations;
		private readonly IColumnBuilder<T> _columnBuilder;
		private readonly GridColumnCollection<T> _columnsCollection;

		private int _displayingItemsCount = -1; // count of displaying items (if using pagination)
		private bool _enablePaging;
		private int _rowCount = -1;
		private int _pageNumber = -1;
		private IGridPager _pager;

		private IGridItemsProcessor<T> _pagerProcessor;
		private IGridSettingsProvider _settings;

		public GridSimple(IEnumerable<T> items, int pageNumber, int rowCount)
			: this(items.AsQueryable(), pageNumber, rowCount)
		{
		}

		public GridSimple(IQueryable<T> items, int pageNumber, int rowCount)
			: base(items)
		{
			#region init default properties

			//set up sort settings:
			//_pageNumber = pageNumber;
			_rowCount = rowCount;
			_settings = new QueryStringGridSettingsProvider();
			Sanitizer = new Sanitizer();
			EmptyGridText = Strings.DefaultGridEmptyText;
			Language = Strings.Lang;

			_annotations = new GridAnnotationsProvider();

			#endregion

			//Set up column collection:
			_columnBuilder = new DefaultColumnBuilder<T>(this, _annotations);
			_columnsCollection = new GridColumnCollection<T>(_columnBuilder, _settings.SortSettings);
			RenderOptions = new GridRenderOptions();

			ApplyGridSettings();
		}

		/// <summary>
		///     Grid columns collection
		/// </summary>
		public IGridColumnCollection<T> Columns
		{
			get { return _columnsCollection; }
		}

		/// <summary>
		///     Sets or get default value of sorting for all adding columns
		/// </summary>
		public bool DefaultSortEnabled
		{
			get { return _columnBuilder.DefaultSortEnabled; }
			set { _columnBuilder.DefaultSortEnabled = value; }
		}

		/// <summary>
		///     Set or get default value of filtering for all adding columns
		/// </summary>
		public bool DefaultFilteringEnabled
		{
			get { return _columnBuilder.DefaultFilteringEnabled; }
			set { _columnBuilder.DefaultFilteringEnabled = value; }
		}

		public GridRenderOptions RenderOptions { get; set; }

		/// <summary>
		///     Provides settings, using by the grid
		/// </summary>
		public override IGridSettingsProvider Settings
		{
			get { return _settings; }
			set
			{
				_settings = value;
			}
		}

		/// <summary>
		///     Items, displaying in the grid view
		/// </summary>
		IEnumerable<object> IGridBase.ItemsToDisplay
		{
			get { return GetItemsToDisplay(); }
		}

		#region IGrid Members

		/// <summary>
		///     Count of current displaying items
		/// </summary>
		public virtual int DisplayingItemsCount
		{
			get
			{
				if (_displayingItemsCount >= 0)
					return _displayingItemsCount;
				_displayingItemsCount = _rowCount != -1 ? _rowCount : GetItemsToDisplay().Count();
				return _displayingItemsCount;
			}
		}

		/// <summary>
		///     Enable or disable paging for the grid
		/// </summary>
		public bool EnablePaging
		{
			get { return _enablePaging; }
			set
			{
				if (_enablePaging == value) return;
				_enablePaging = value;
				if (_enablePaging)
				{
					if (_pagerProcessor == null)
						_pagerProcessor = new PagerGridItemsProcessor<T>(Pager);
				}
			}
		}

		public string Language { get; set; }

		/// <summary>
		///     Gets or set Grid column values sanitizer
		/// </summary>
		public ISanitizer Sanitizer { get; set; }

		/// <summary>
		///     Manage pager properties
		/// </summary>
		public IGridPager Pager
		{
			get { return _pager ?? (_pager = new GridPager(_rowCount)); }
			set { _pager = value; }
		}

		IGridColumnCollection IGridBase.Columns
		{
			get { return Columns; }
		}

		#endregion

		/// <summary>
		///     Applies data annotations settings
		/// </summary>
		private void ApplyGridSettings()
		{
			GridTableAttribute opt = _annotations.GetAnnotationForTable<T>();
			if (opt == null) return;
			EnablePaging = opt.PagingEnabled;
			if (opt.PageSize > 0)
				Pager.PageSize = opt.PageSize;

			if (opt.PagingMaxDisplayedPages > 0 && Pager is GridPager)
			{
				(Pager as GridPager).MaxDisplayedPages = opt.PagingMaxDisplayedPages;
			}
		}

		/// <summary>
		///     Methods returns items that will need to be displayed
		/// </summary>
		protected internal virtual IEnumerable<T> GetItemsToDisplay()
		{
			return GridItems;
		}

		/// <summary>
		///     Generates columns for all properties of the model
		/// </summary>
		public virtual void AutoGenerateColumns()
		{
			//TODO add support order property
			PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo pi in properties)
			{
				if (pi.CanRead)
					Columns.Add(pi);
			}
		}

	}
}