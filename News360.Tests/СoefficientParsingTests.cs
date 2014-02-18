using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace News360.Tests
{
		[TestClass]
		public class СoefficientParsingTests
		{
				[TestMethod]
				public void ParseSingleСoefficient()
				{
						var input = "4";
						var parser = new СoefficientParser();
						var result = parser.GetСoefficient(input);
						Assert.AreEqual(result, 4);
				}

				[TestMethod]
				public void ParseDoubleСoefficient()
				{
						var input = "4*4";
						var parser = new СoefficientParser();
						var result = parser.GetСoefficient(input);
						Assert.AreEqual(result, 16);
				}

				[TestMethod]
				public void ParseSingleСoefficientWithVariables()
				{
						var input = "4*x";
						var parser = new СoefficientParser();
						var result = parser.GetСoefficient(input);
						Assert.AreEqual(result, 4);
				}
		}
}
