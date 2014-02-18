using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace News360.Tests
{
		[TestClass]
		public class ExpressionNormalizerTests
		{
				[TestMethod]
				public void NormalizeComplexInput()
				{
						var input = "4*x + 5*y -6*x = 4*x+ 10*x*y";
						var normalizer = new ExpressionNormalizer(
								new СoefficientParser(),
								new VariablesParser(),
								new NormalizeExpressionFormatter());
						var result = normalizer.NormalizeExpression(input);
						Assert.IsTrue(result.Length > 0);
				}

				[TestMethod]
				public void NormalizeComplexWithExponentaInput()
				{
						var input = "4*x + 5*y^3 -6*x = 4*x+ 10*x*y^4";
						var normalizer = new ExpressionNormalizer(
								new СoefficientParser(),
								new VariablesParser(),
								new NormalizeExpressionFormatter());
						var result = normalizer.NormalizeExpression(input);
						Assert.IsTrue(result.Length > 0);
				}
		}
}
