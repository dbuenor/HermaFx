using System.Collections.Generic;
using HermaFx.MvcContrib.UI.InputBuilder.InputSpecification;

namespace HermaFx.MvcContrib.UI.InputBuilder
{
	public class DefaultTypeConventionsFactory : List<ITypeViewModelFactory>
	{
		public DefaultTypeConventionsFactory()
		{
			Add(new DefaultTypeViewModelFactoryConvention());
		}
	}
}