using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace News360
{
		public class KeyCountCollection<T> : IKeyCountCollection<T>
		{
			private readonly IDictionary<T, double> _keysToCount;

			public KeyCountCollection()
			{
					_keysToCount = new Dictionary<T, double>();
			}

			public void Add(T key)
			{
				Add(key, 1);
			}

			public void Add(T key, double count)
			{

					if (_keysToCount.Any(keyToCount => keyToCount.Key.Equals(key)))
					{
							_keysToCount[key] = _keysToCount[key] + count;
					}
					else
					{
							_keysToCount.Add(key, count);
					}
			}

				public void AddRange(IEnumerable<T> keys)
				{
					foreach (var key in keys)
					{
						Add(key);
					}
				}

				protected bool Equals(KeyCountCollection<T> other)
				{
						return _keysToCount.DictionaryEqual(other._keysToCount);
				}

				public override bool Equals(object obj)
				{
						if (ReferenceEquals(null, obj)) return false;
						if (ReferenceEquals(this, obj)) return true;
						if (obj.GetType() != this.GetType()) return false;
						return Equals((KeyCountCollection<T>)obj);
				}

				public override int GetHashCode()
				{
						if (_keysToCount == null)
						{
								return 0;
						}

						return _keysToCount.Aggregate(13, (current, i) => current ^ i.GetHashCode());
				}

				public IEnumerator<KeyValuePair<T, double>> GetEnumerator()
				{
						return _keysToCount.GetEnumerator();
				}

				IEnumerator IEnumerable.GetEnumerator()
				{
						return GetEnumerator();
				}
		}
}
