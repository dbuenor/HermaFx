using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using HermaFx.Mvc.Grid.DataAnnotations.Models;

namespace HermaFx.Mvc.Grid.DataAnnotations
{
	[TestFixture]
	public class DataAnnotationsProviderTests
	{
		private IGridAnnotationsProvider _provider;
		[OneTimeSetUp]
		public void Init()
		{
			_provider = new GridAnnotationsProvider();
		}

		[Test]
		public void TestProviderMetadataType()
		{
			var pi = typeof(TestGridAnnotationModel).GetProperty("Title");
			var opt = _provider.GetAnnotationForColumn<TestGridAnnotationModel>(pi);
			Assert.IsNotNull(opt);
			Assert.AreEqual(opt.Title, "Some title"); //ensure that title reads from metadata type class

			var gridSettings = _provider.GetAnnotationForTable<TestGridAnnotationModel>();
			Assert.IsNotNull(gridSettings);
			Assert.AreEqual(gridSettings.PageSize, 20);
			Assert.AreEqual(gridSettings.PagingEnabled, true);
		}
	}
}
