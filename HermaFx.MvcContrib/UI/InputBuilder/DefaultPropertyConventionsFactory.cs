using System.Collections.Generic;
using HermaFx.MvcContrib.UI.InputBuilder.Conventions;

namespace HermaFx.MvcContrib.UI.InputBuilder
{
	public class DefaultPropertyConventionsFactory : List<IPropertyViewModelFactory>
	{
		public DefaultPropertyConventionsFactory()
		{
			Add(new ArrayPropertyConvention());
			Add(new GuidPropertyConvention());
			Add(new EnumPropertyConvention());
			Add(new DateTimePropertyConvention());
			Add(new DefaultPropertyConvention());
		}
	}
}