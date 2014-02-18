using System;
using System.Data.Odbc;
using System.Linq;

namespace News360 {
	public class ExpressionValidator : IExpressionValidator {
		public ValidationResult Validate(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return ValidationResult.Error("Входная строка неопределена или пуста");
			}

			if (!input.Contains("="))
			{
					return ValidationResult.Error("Входная строка не явлется равенством");
			}

			if (input.Count(x => x == '=') != 1)
			{
					return ValidationResult.Error("Знак 'равно' встречается более одного раза");
			}

			var summands = input.Split('=');
			if (summands.Any(string.IsNullOrEmpty))
			{
					return ValidationResult.Error("Одна из частей равенства пуста");
			}

			return ValidationResult.Succes();
		}
	}
}