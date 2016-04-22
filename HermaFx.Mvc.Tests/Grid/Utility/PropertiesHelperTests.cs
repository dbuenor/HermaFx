using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using NUnit.Framework;

namespace HermaFx.Mvc.Grid.Utility
{
	[TestFixture]
	public class PropertiesHelperTests
	{


		[OneTimeSetUp]
		public void Init()
		{

		}

		[Test]
		public void TestColumnNameBuilding()
		{
			Expression<Func<TestModel, DateTime>> expr = m => m.Created;

			string name = PropertiesHelper.BuildColumnNameFromMemberExpression((MemberExpression)expr.Body);
			Assert.AreEqual(name, "Created");

		}

		[Test]
		public void TestColumnNameBuildingChilds()
		{
			Expression<Func<TestModel, string>> expr = m => m.Child.ChildTitle;
			string name = PropertiesHelper.BuildColumnNameFromMemberExpression((MemberExpression)expr.Body);
			Assert.AreEqual(name, "Child.ChildTitle");

		}

		[Test]
		public void TestGetPropertyFromColumnName()
		{
			const string columnName = "Created";
			IEnumerable<PropertyInfo> sequence;
			var pi = PropertiesHelper.GetPropertyFromColumnName(columnName, typeof(TestModel), out sequence);
			Assert.AreEqual(sequence.Count(), 1);
			Assert.AreEqual(pi.Name, "Created");
		}

		[Test]
		public void TestGetPropertyFromColumnNameChilds()
		{
			const string columnName = "Child.ChildTitle";
			IEnumerable<PropertyInfo> sequence;
			var pi = PropertiesHelper.GetPropertyFromColumnName(columnName, typeof(TestModel), out sequence);
			Assert.AreEqual(sequence.Count(), 2);
			Assert.AreEqual(pi.Name, "ChildTitle");
		}
	}
}