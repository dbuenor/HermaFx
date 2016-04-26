using System.Linq;
using System.Collections.Generic;

using HermaFx.Mvc.Grid;

namespace HermaFx.Mvc.Site.Models.Grids
{
	public class OrdersGridTest : GridSimple<Order>
	{
		public OrdersGridTest(List<Order> items, int pageNumber, int rowCount)
			: base(items, pageNumber, rowCount)
		{
		}
	}
}