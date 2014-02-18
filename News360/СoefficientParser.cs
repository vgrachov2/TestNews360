using System;
using System.Linq;

namespace News360 {
	public class СoefficientParser : IСoefficientParser {
		public double GetСoefficient(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				throw new ArgumentException("Некорректная входная строка.");
			}

			var multipliers = input.Split('*');
			if (!multipliers.Any())
			{
				return 0;
			}

			var result = 1d;
			foreach (var multiplier in multipliers)
			{
					result *= GetCoefficient(multiplier);
			}

			return result;
		}

		private static double GetCoefficient(string input)
		{
			double coefficient;
			if (double.TryParse(input, out coefficient))
			{
				return coefficient;
			}
			return 1;
		}
	}
}