using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News360
{
		/// <summary>
		/// Коллекция которая считает количество вхождения ключа
		/// </summary>
		public interface IKeyCountCollection<T> : IEnumerable<KeyValuePair<T, double>>
		{
				void Add(T key);

				void Add(T key, double count);

				void AddRange(IEnumerable<T> keys);
		}
}
