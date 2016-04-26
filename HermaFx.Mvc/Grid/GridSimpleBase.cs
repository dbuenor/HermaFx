using System;
using System.Collections.Generic;
using System.Linq;

namespace HermaFx.Mvc.Grid
{
	/// <summary>
	///     Base implementation of the Grid.Mvc
	/// </summary>
	public abstract class GridSimpleBase<T> where T : class
	{
		protected IEnumerable<T> Items; //items after processors

		private int _itemsCount = -1; // total items count on collection
		private bool _itemsPreProcessed; //is preprocessors launched?
		private bool _itemsProcessed; //is processors launched?

		private Func<T, string> _rowCssClassesContraint;

		protected GridSimpleBase(IEnumerable<T> items)
		{
			Items = items;
		}

		public abstract IGridSettingsProvider Settings { get; set; }

		public IEnumerable<T> GridItems
		{
			get
			{
				return Items;
			}
		}

		/// <summary>
		///     Text in empty grid (no items for display)
		/// </summary>
		public string EmptyGridText { get; set; }

		/// <summary>
		/// Total count of items in the grid
		/// </summary>
		public int ItemsCount
		{
			get
			{
				if (_itemsCount < 0)
					_itemsCount = GridItems.Count();
				return _itemsCount;
			}
			set
			{
				_itemsCount = value; //value can be set by pager (for minimizing db calls)
			}
		}

		#region Custom row css classes
		public void SetRowCssClassesContraint(Func<T, string> contraint)
		{
			_rowCssClassesContraint = contraint;
		}

		public string GetRowCssClasses(object item)
		{
			if (_rowCssClassesContraint == null)
				return string.Empty;
			var typed = item as T;
			if (typed == null)
				throw new InvalidCastException(string.Format("The item must be of type '{0}'", typeof(T).FullName));
			return _rowCssClassesContraint(typed);
		}

		#endregion
	}
}