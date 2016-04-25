using System.Linq;

namespace HermaFx.Mvc.Site.Models
{
	public class OrdersRepository
	{
		public IOrderedQueryable<Order> GetAll()
		{
			return Database.GetOrders().OrderByDescending(o => o.OrderDate);
		}

		public Order GetById(object id)
		{
			return GetAll().FirstOrDefault(o => o.OrderID == (int) id);
		}
	}
}