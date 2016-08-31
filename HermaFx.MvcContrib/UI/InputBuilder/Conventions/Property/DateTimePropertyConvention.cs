using System;
using System.Reflection;
using HermaFx.MvcContrib.UI.InputBuilder.Views;

namespace HermaFx.MvcContrib.UI.InputBuilder.Conventions
{
	public class DateTimePropertyConvention : DefaultPropertyConvention
	{
		public override bool CanHandle(PropertyInfo propertyInfo)
		{
			return propertyInfo.PropertyType == typeof(DateTime);
		}

		public override PropertyViewModel CreateViewModel<T>()
		{
			return new PropertyViewModel<DateTime> {};
		}
	}
}