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

namespace HermaFx.Mvc.Site.Models
{
	public class Database
	{
		public static IQueryable<Order> GetOrders()
		{
			using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Content/Json/Orders.json")))
			{
				var test = reader.ReadToEnd();
				var res = JsonConvert.DeserializeObject<List<Order>>(test);

				return res.AsQueryable();
			}
		}
	}
}