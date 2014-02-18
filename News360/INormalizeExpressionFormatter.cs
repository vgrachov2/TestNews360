using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News360
{
		/// <summary>
		/// Выводит результат. Уравнение приведенное к нормальному виду.
		/// </summary>
		public interface INormalizeExpressionFormatter {
			string GetExpression(KeyCountCollection<KeyCountCollection<string>> summands);
		}
}
