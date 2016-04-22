using System.Linq;

using HermaFx.Mvc.Grid;

namespace HermaFx.Mvc.Site.Models.Grids
{
    public class OrdersGrid : Grid<Order>
    {
        public OrdersGrid(IQueryable<Order> items)
            : base(items)
        {
        }
    }
}