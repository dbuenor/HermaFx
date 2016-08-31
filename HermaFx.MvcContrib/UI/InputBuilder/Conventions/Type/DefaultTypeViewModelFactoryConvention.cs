using System;
using HermaFx.MvcContrib.UI.InputBuilder.Attributes;
using HermaFx.MvcContrib.UI.InputBuilder.Conventions;
using HermaFx.MvcContrib.UI.InputBuilder.Helpers;
using HermaFx.MvcContrib.UI.InputBuilder.Views;

namespace HermaFx.MvcContrib.UI.InputBuilder.InputSpecification
{
	public class DefaultTypeViewModelFactoryConvention : ITypeViewModelFactory {
		public bool CanHandle(Type type)
		{
			return true;
		}

		public TypeViewModel Create(Type type)
		{
			return new TypeViewModel()
			{
				Label = LabelForTypeConvention(type),				
				PartialName = "Form",
				Type = type,
                
			};
		}

		public string LabelForTypeConvention(Type type)
		{
			if (type.AttributeExists<LabelAttribute>())
			{
				return type.GetAttribute<LabelAttribute>().Label;
			}
			return type.Name.ToSeparatedWords();
		}
	}
}