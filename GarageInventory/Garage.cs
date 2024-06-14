using System.Collections;

namespace GarageInventory
{
    internal class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T[] _array;
        private int _parkingSpacesFilled;

        public T this[int index] { get { return _array[index]; } set { _array[index] = value; } }
        public int Count => _array.Length;
        public int ParkingSpacesFilled { get { return _parkingSpacesFilled; } set { _parkingSpacesFilled = value; } }

        public Garage(int capacity)
        {
            _array = new T[capacity];
            _parkingSpacesFilled = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Remove(Vehicle vehicle)
        {
            T[] array2 = new T[_array.Length];
            int first = 0;
            int second = 0;
            foreach (Vehicle item in _array)
            {
                if (item != vehicle)
                {
                    array2[second] = _array[first];
                    second++;
                }
                first++;
            }
            _array = array2;
        }

    }
}
