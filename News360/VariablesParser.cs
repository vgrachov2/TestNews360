using System;
using System.Collections.Generic;
using System.Linq;

namespace News360 {
	public class VariablesParser : IVariablesParser {
		public IEnumerable<string> GetVariables(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				return new List<string>();
			}

			var multipliers = input.Split('*').Where(multiplier => !IsVariable(multiplier));
			return multipliers.SelectMany(GetMultipliersFromExponent);
		}

		private static bool IsVariable(string multiplier)
		{
			double coef; 
			return double.TryParse(multiplier, out coef);
		}

		private IEnumerable<string> GetMultipliersFromExponent(string multiplier)
		{
			if (!multiplier.Contains('^'))
			{
				return new[] {multiplier};
			}
			var multiplierWithExponenta = multiplier.Split('^');
			if (multiplierWithExponenta.Count() > 2)
			{
				throw new FormatException(string.Format("Некорретный множитель - {0}", multiplier));
			}
			double exponenta;
			if (!double.TryParse(multiplierWithExponenta[1], out exponenta))
			{
				throw new FormatException(string.Format("Некорретная значение экспоненты - {0}", (multiplierWithExponenta[1])));
			}

			var result = new List<string>();
			for (var i = 0; i < exponenta; i++)
			{
				result.Add(multiplierWithExponenta[0]);
			}

			return result;
		}
	}
}
