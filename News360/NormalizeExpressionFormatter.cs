using System;
using System.Collections.Generic;
using System.Text;

namespace News360 {
	public class NormalizeExpressionFormatter : INormalizeExpressionFormatter {
		public string GetExpression(KeyCountCollection<KeyCountCollection<string>> summands)
		{
			var resultBuilder = new StringBuilder();
			foreach (var summand in summands)
			{
				resultBuilder
					.Append(GetSign(summand))
					.Append(summand.Value)
					.Append("*");
				foreach (var variable in summand.Key)
				{
					resultBuilder.Append(variable.Key);
					FormatExponenta(variable, resultBuilder);
					resultBuilder.Append("*");
				}
				resultBuilder.Length--;
			}

			TrimFirstPlus(resultBuilder);
			resultBuilder.Append("= 0");
			return resultBuilder.ToString();
		}

		private static void FormatExponenta(KeyValuePair<string, double> variable, StringBuilder resultBuilder)
		{
			if (variable.Value != 1)
			{
				resultBuilder
					.Append("^")
					.Append(variable.Value);
			}
		}

		private static void TrimFirstPlus(StringBuilder resultBuilder)
		{
			if (resultBuilder[0] == '+')
			{
				resultBuilder.Remove(0, 1);
			}
		}

		/// <summary>
		/// Получение знака слогаемого
		/// </summary>
		/// <param name="summand"></param>
		/// <returns></returns>
		private static string GetSign(KeyValuePair<KeyCountCollection<string>, double> summand)
		{
			return summand.Value >= 0 ? "+" : string.Empty;
		}
	}
}