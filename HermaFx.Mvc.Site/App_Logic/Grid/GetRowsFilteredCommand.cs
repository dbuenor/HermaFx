using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HermaFx.Mvc.Site
{
	public class GetRowsFiltered<T>
	{
		public int RowsPerPage { get; set; }
		public int CurrentPage { get; set; }
		public string ColumnSort { get; set; }
		public IQueryable<T> Rows { get; set; }
	}

	public static class GetRowsFilteredCommand
	{
		public static List<T> Execute<T>(GetRowsFiltered<T> model)
		{
			var results = model.Rows.Skip(model.RowsPerPage * (model.CurrentPage - 1));

			//SORTING
			if (!string.IsNullOrEmpty(model.ColumnSort))
				results = results.OrderBy(model.ColumnSort);

			//PAGING
			results = results.Take(model.RowsPerPage);

			return results.ToList();
		}
	}
}