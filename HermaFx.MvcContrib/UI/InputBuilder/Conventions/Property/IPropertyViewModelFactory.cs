using System;
using System.Reflection;
using HermaFx.MvcContrib.UI.InputBuilder.InputSpecification;
using HermaFx.MvcContrib.UI.InputBuilder.Views;

namespace HermaFx.MvcContrib.UI.InputBuilder.Conventions
{
	public interface IPropertyViewModelFactory
	{
		bool CanHandle(PropertyInfo propertyInfo);
		PropertyViewModel Create(PropertyInfo propertyInfo, object model, string name, Type type);
	}

	public interface  IRequireViewModelFactory
	{
		void Set(IViewModelFactory factory);
	}
}