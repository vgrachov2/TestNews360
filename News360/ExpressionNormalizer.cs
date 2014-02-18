using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News360
{
		public class ExpressionNormalizer {
			private readonly IСoefficientParser _coefficientParser;
			private readonly IVariablesParser _variablesParser;
			private readonly INormalizeExpressionFormatter _expressionFormatter;

			public ExpressionNormalizer(
					IСoefficientParser coefficientParser,
					IVariablesParser variablesParser,
					INormalizeExpressionFormatter expressionFormatter)
			{
				_coefficientParser = coefficientParser;
				_variablesParser = variablesParser;
				_expressionFormatter = expressionFormatter;
			}

			/// <summary>
			/// Преобразование входного уравнения к нормальному виду
			/// </summary>
			/// <param name="input"></param>
			/// <returns></returns>
			public string NormalizeExpression(string input)
			{
				var sides = PrepareStringForNormalizing(input).Split('=');
				var result = new KeyCountCollection<KeyCountCollection<string>>();
				ParseSummand(sides[0].Split('+'), result, false);
				ParseSummand(sides[1].Split('+'), result, true);
				return _expressionFormatter.GetExpression(result);
			}

				/// <summary>
				/// Обработка слогаемых
				/// </summary>
				/// <param name="summands">Слогаемые</param>
				/// <param name="result">Выходная коллекция</param>
				/// <param name="inverse">Инвертировать ли слогаемые?</param>
			private void ParseSummand(IEnumerable<string> summands, KeyCountCollection<KeyCountCollection<string>> result, bool inverse)
			{
				foreach (var summand in summands)
				{
					var coefficient = _coefficientParser.GetСoefficient(summand);
					if (inverse)
					{
						coefficient *= -1;
					}

					var variableCollection = new KeyCountCollection<string>();
					variableCollection.AddRange(_variablesParser.GetVariables(summand));
					result.Add(variableCollection, coefficient);
				}
			}

			private static string PrepareStringForNormalizing(string input)
			{
				return input.Replace(" ", string.Empty).Replace("-", "+-").ToLower();
			}
		}
}
