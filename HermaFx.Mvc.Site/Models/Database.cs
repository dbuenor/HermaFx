using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Http.Routing;
using System.Collections;

namespace HermaFx.Mvc.Site.Models
{
	public class Database
	{
		private static IQueryable<T> GetResults<T>(string filePath)
		{
			using (var reader = new StreamReader(filePath))
			{
				var json = reader.ReadToEnd();
				var results = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

				return results.AsQueryable();
			}
		}

		public static IQueryable<Order> GetOrders()
		{
			return GetResults<Order>(
				HttpContext.Current.Server.MapPath("~/Content/Json/Orders.json"));
		}

		public static IQueryable<Customer> GetCustomers()
		{
			return GetResults<Customer>(
				HttpContext.Current.Server.MapPath("~/Content/Json/Customers.json"));
		}
	}
}