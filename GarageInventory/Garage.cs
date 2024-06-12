using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Garage<T> where T : Vehicle , IEnumerable<T>
    {
        Vehicle[] listOfVehicles;
        private int _capacity;

        public int Capacity { get { return _capacity; } set { _capacity = value; } }

        public Garage(int capacity)
        {
            listOfVehicles = new Vehicle[capacity];
            _capacity = capacity;
        }
    }
}
