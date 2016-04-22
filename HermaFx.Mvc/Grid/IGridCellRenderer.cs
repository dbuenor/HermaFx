﻿using System.Web;
using HermaFx.Mvc.Grid.Columns;

namespace HermaFx.Mvc.Grid
{
	/// <summary>
	///     Object to render the content
	/// </summary>
	public interface IGridCellRenderer
	{
		/// <summary>
		///     Render grid cell
		/// </summary>
		/// <param name="column">Column of the cell</param>
		/// <param name="cell">The cell</param>
		/// <returns>HTML</returns>
		IHtmlString Render(IGridColumn column, IGridCell cell);
	}
}