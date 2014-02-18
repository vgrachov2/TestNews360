using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News360
{
		/// <summary>
		/// Валидатор входной строки, для проверки на возможность нормализации
		/// </summary>
		public interface IExpressionValidator {
			ValidationResult Validate(string input);
		}
}
