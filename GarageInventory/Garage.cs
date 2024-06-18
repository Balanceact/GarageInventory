using System.Collections;

namespace GarageInventory
{
    public class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T[] _array;
        private int _parkingSpacesFilled;

        public T this[int index] { get { return _array[index]; } set { _array[index] = value; } }
        public int Count => _array.Length;
        public int ParkingSpacesFilled { get { return _parkingSpacesFilled; } set { _parkingSpacesFilled = value; } }
        public bool IsFull => Count <= ParkingSpacesFilled;

        public Garage(int capacity)
        {
            _array = new T[capacity];
            _parkingSpacesFilled = 0;
        }

        /// <summary>
        /// Implements IEnumerator<T> for IEnumerable<T> for the class (and by extension for the collection).
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _array)
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
        /// Removes a desired element from the array.
        /// </summary>
        /// <param name="vehicle"></param>
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

        /// <summary>
        /// Returns a List<string> of the '.ToString' elements for every vehicle in the array. 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<string> AllParkedToString()
        {
            List<string> allParked = new List<string>();
            for (int i = 0; i < ParkingSpacesFilled; i++)
            {
                allParked.Add(_array[i].ToString());
            }
            return allParked;
        }
    }
}
