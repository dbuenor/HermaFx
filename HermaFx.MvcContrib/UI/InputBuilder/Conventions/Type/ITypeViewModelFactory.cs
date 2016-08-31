using System;
using HermaFx.MvcContrib.UI.InputBuilder.Views;

namespace HermaFx.MvcContrib.UI.InputBuilder.InputSpecification
{
	public interface ITypeViewModelFactory {
		bool CanHandle(Type type);
		TypeViewModel Create(Type type);
	}
}