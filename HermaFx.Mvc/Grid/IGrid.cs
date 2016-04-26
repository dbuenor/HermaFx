using HermaFx.Mvc.Grid.Columns;
using HermaFx.Mvc.Grid.Html;
using HermaFx.Mvc.Grid.Pagination;

namespace HermaFx.Mvc.Grid
{
	public interface IGrid<T> : IGridBase where T : class
	{
		bool DefaultFilteringEnabled { get; set; }
		bool DefaultSortEnabled { get; set; }

		void AutoGenerateColumns();
	}
}