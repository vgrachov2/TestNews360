using System.Collections.Generic;

namespace News360 {
	/// <summary>
	/// Парсер переменных множителей
	/// </summary>
	public interface IVariablesParser {
		/// <summary>
		/// Получить все множители из строки
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		IEnumerable<string> GetVariables(string input);
	}
}