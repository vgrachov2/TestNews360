using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace News360.Tests
{
		[TestClass]
		public class ValidatorTests
		{
				[TestMethod]
				public void ErrorIfNullOrEmpty()
				{
					var validator = new ExpressionValidator();
					var result1 = validator.Validate(null);
					Assert.AreEqual(result1.IsValid, false);
					var result2 = validator.Validate(string.Empty);
					Assert.AreEqual(result2.IsValid, false);
				}

				[TestMethod]
				public void ErrorIfIsNotEquality()
				{
						var input = "4*x + 5*y^3 -6*x";
						var validator = new ExpressionValidator();
						var result = validator.Validate(input);
						Assert.AreEqual(result.IsValid, false);
				}

				[TestMethod]
				public void ErrorIfEmptyPartOfEquality()
				{
						var input = "4*x + 5*y^3 -6*x=";
						var validator = new ExpressionValidator();
						var result = validator.Validate(input);
						Assert.AreEqual(result.IsValid, false);

						var input2 = "4*x + 5*y^3 -6*x=";
						var result2 = validator.Validate(input2);
						Assert.AreEqual(result2.IsValid, false);
				}
		}
}
