using System.Reflection;

namespace HermaFx.MvcContrib.UI.InputBuilder.Conventions
{
	public interface IPropertyViewModelNameConvention
	{
		string PropertyName(PropertyInfo propertyInfo);
	}
}