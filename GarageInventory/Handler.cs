using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Handler : IHandler
    {
        private IGarage<Vehicle> _listOfVehicles;
        private List<string> _listOfVehicleTypes = new List<string> { "  Airplane  ",
                                                                      "    Boat    ",
                                                                      "    Bus     ",
                                                                      "    Car     ",
                                                                      " Motorcycle ",
                                                                      "   Truck    "};

        public List<string> ListOfVehicles { get { return _listOfVehicleTypes; } }
        public Handler(int capacity)
        {
            _listOfVehicles = new Garage<Vehicle>(capacity);
        }
        public void AddVehicle(Vehicle vehicle)
        {
            if (_listOfVehicles.Count == _listOfVehicles.Count)
            {
                //ToDo: Message handler: Garage is full!
            }
            else
            {
                _listOfVehicles[_listOfVehicles.ParkingSpacesFilled] = vehicle;
                _listOfVehicles.ParkingSpacesFilled++;
                //ToDo: Message handler: Vehicle added to Garage!
            }
        }
        public void RemoveVehicle(Vehicle vehicle)
        {
            foreach (var v in _listOfVehicles)
            {
                if (v == vehicle)
                {
                    _listOfVehicles.Remove(vehicle);
                    //ToDo: Message handler: Vehicle removed from Garage!
                }
            }
        }
        public void Populate(int numberOfVehicles)
        {
            int choice = 1;
            choice = UI.Menu(choice, .ListOfVehicles);
        }
    }
}
