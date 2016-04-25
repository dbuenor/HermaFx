using System.Linq;

namespace HermaFx.Mvc.Site.Models
{
	public class CustomersRepository
	{
		public IOrderedQueryable<Customer> GetAll()
		{
			return Database.GetCustomers().OrderBy(o => o.CompanyName);
		}

		public Customer GetById(object id)
		{
			return GetAll().FirstOrDefault(c => c.CustomerID == (string)id);
		}
	}
}