using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HermaFx.MvcContrib.UI.Html
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class RawValueAttribute : Attribute, IMetadataAware
	{

		public RawValueAttribute() { }

		public void OnMetadataCreated(ModelMetadata metadata)
		{
			metadata.HideSurroundingHtml = true;
		}
	}
}
