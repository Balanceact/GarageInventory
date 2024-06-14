using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Handler
    {
        private Garage<Vehicle> _listOfVehicles;

        public Handler(int capacity)
        {
            _listOfVehicles = new Garage<Vehicle>(capacity);
        }
    }
}
