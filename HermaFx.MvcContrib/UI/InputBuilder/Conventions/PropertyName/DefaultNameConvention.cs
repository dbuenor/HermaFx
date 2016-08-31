using System.Reflection;

namespace HermaFx.MvcContrib.UI.InputBuilder.Conventions
{
	public class DefaultNameConvention : IPropertyViewModelNameConvention
	{
		public virtual string PropertyName(PropertyInfo propertyInfo)
		{
			return propertyInfo.Name;
		}
	}
}