using System.Collections;

namespace GarageInventory
{
    internal class LimitedList<T> : IEnumerable<T>
    {
        private readonly int _capacity;
        protected List<T> _list;

        public int Count => _list.Count;
        public bool IsFull => _capacity <= Count;

        public T this[int index] => _list[index];

        public LimitedList(int capacity)
        {
            _capacity = capacity;
            _list = new List<T>(_capacity);
        }

        /// <summary>
        /// Adds item to list. Removes first item if full.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, "item");
            if (IsFull)
            {
                _list.RemoveAt(0);
            }
            _list.Add(item);
        }

        /// <summary>
        /// Implements IEnumerator<T> for IEnumerable<T> for the class (and by extension for the collection).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Implements IEnumerator for IEnumerable for the class (and by extension for the collection).
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Removes item from list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item) => _list.Remove(item);
    }
}
