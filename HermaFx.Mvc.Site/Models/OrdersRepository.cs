using System.Linq;

namespace HermaFx.Mvc.Site.Models
{
    public class OrdersRepository : SqlRepository<Order>
    {
        public OrdersRepository()
            : base(new NorthwindDbContext())
        {
        }

        public override IOrderedQueryable<Order> GetAll()
        {
			// FIXME: Change Db Source or Add Sql Server 2012 Express Local Db to solution
			// Another option is to use MongoDb driver and use this db:
			// https://github.com/tmcnab/northwind-mongo
			return Enumerable.Empty<Order>().AsQueryable().OrderByDescending(o => o.OrderDate);
			//return EfDbSet.Include("Customer").OrderByDescending(o => o.OrderDate);
        }

        public override Order GetById(object id)
        {
            return GetAll().FirstOrDefault(o => o.OrderID == (int) id);
        }
    }
}