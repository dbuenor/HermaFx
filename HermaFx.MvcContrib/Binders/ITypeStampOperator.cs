using System.Web.Mvc;

namespace HermaFx.MvcContrib.Binders
{
    public interface ITypeStampOperator
    {
        string DetectTypeStamp(ModelBindingContext bindingContext, IPropertyNameProvider propertyNameProvider);
    }
}
