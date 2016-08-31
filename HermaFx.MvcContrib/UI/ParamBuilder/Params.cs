using System.Collections.Generic;
using HermaFx.MvcContrib.UI.ReturnUrl;

namespace HermaFx.MvcContrib.UI.ParamBuilder
{
	public class Params
	{
		public static ParamBuilder With
		{
			get { return new ParamBuilder(new ReturnUrlManager()); }
		}

		public static IDictionary<string, object> Empty
		{
			get
			{
				return new Dictionary<string, object>();
			}
		}
	}
}