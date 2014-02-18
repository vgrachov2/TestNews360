using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace News360.Tests
{
		[TestClass]
		public class VariablesParsingTests
		{
				[TestMethod]
				public void ParseSingleVariable()
				{
						var input = "x";
						var result = new KeyCountCollection<string>();
						result.Add(input);
						Assert.IsTrue(result.Any());
						Assert.AreEqual(result.First().Value, 1);
				}

				[TestMethod]
				public void ParseDoubleVariables()
				{
						var input = "x*y";
						var result = new KeyCountCollection<string>();
						var parser = new VariablesParser();
						var multipliers = parser.GetVariables(input);
						result.AddRange(multipliers);
						Assert.IsTrue(result.Count() == 2);
						Assert.AreEqual(result.First().Value, 1);
				}

				[TestMethod]
				public void ParseVariablesWithRepeatlyVariables()
				{
						var input = "x*x*y";
						var result = new KeyCountCollection<string>();
						var parser = new VariablesParser();
						var multipliers = parser.GetVariables(input);
						result.AddRange(multipliers);
						Assert.IsTrue(result.Count() == 2);
						Assert.AreEqual(result.First(x => x.Key == "x").Value, 2);
				}

				[TestMethod]
				public void ParseVariablesWithExponent()
				{
						var input = "x^2*y";
						var result = new KeyCountCollection<string>();
						var parser = new VariablesParser();
						var multipliers = parser.GetVariables(input);
						result.AddRange(multipliers);
						Assert.IsTrue(result.Count() == 2);
						Assert.AreEqual(result.First(x => x.Key == "x").Value, 2);
				}
		}
}
