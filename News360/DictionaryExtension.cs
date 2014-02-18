using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News360
{
		public static class DictionaryExtension
		{
				/// <summary>
				/// Расшириение для сравнения двух словарей
				/// </summary>
				/// <typeparam name="TKey"></typeparam>
				/// <typeparam name="TValue"></typeparam>
				/// <param name="first"></param>
				/// <param name="second"></param>
				/// <returns></returns>
				public static bool DictionaryEqual<TKey, TValue>(
				this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
				{
						if (first == second) return true;
						if ((first == null) || (second == null)) return false;
						if (first.Count != second.Count) return false;

						var comparer = EqualityComparer<TValue>.Default;

						foreach (KeyValuePair<TKey, TValue> kvp in first)
						{
								TValue secondValue;
								if (!second.TryGetValue(kvp.Key, out secondValue)) return false;
								if (!comparer.Equals(kvp.Value, secondValue)) return false;
						}
						return true;
				}
		}
}
