using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private T[] _array;
        private int _capacity;
        private int _parkingSpacesFilled;

        public T this[int index] { get { return _array[index]; } set { _array[index] = value; } }
        public int Capacity { get { return _capacity; } set { _capacity = value; } }
        public int Count => _array.Length;
        public int ParkingSpacesFilled { get { return _parkingSpacesFilled; } }


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
        public void AddVehicle(Vehicle vehicle)
        {

        }
    }
}
