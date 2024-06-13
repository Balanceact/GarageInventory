using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Garage<T> : IEnumerable<T>, IGarage<T> where T : Vehicle
    {
        private T[] _array;
        private int _capacity;
        private int _parkingSpacesFilled;

        public int ParkingSpacesFilled { get { return _parkingSpacesFilled; } }
        public int Capacity { get { return _capacity; } set { _capacity = value; } }

        public T this[int index] => _array[index];

        public Garage(int capacity)
        {
            _array = new T[capacity];
            _capacity = capacity;
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
    }
}
