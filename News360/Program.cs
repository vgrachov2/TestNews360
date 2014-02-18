using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News360
{
		class Program
		{
				static void Main(string[] args)
				{
					var normalizer = new ExpressionNormalizer(
						new СoefficientParser(),
						new VariablesParser(),
						new NormalizeExpressionFormatter());
					var validator = new ExpressionValidator();
					var expressions = File.ReadAllLines("test.txt");
					foreach (var expression in expressions)
					{
						var validationResult = validator.Validate(expression);
						if (!validationResult.IsValid)
						{
							Console.WriteLine("Выражение не корректно - {0}. {1}", expression, validationResult.ErrorMessage);
							continue;
						}

						Console.WriteLine("Исходное выражение: {0}, полученное выражение {1}", expression, normalizer.NormalizeExpression(expression));
					}
					Console.ReadKey();
				}
		}
}
