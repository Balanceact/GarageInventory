using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Handler : IHandler
    {
        private IUI _ui;
        private IGarage<Vehicle> _listOfVehicles;
        public List<string> _listOfVehicleTypes;

        public IUI UI { get { return _ui; } }
        public List<string> ListOfVehicleTypes { get { return _listOfVehicleTypes; } }

        public Handler(int capacity, IUI UI)
        {
            _ui = UI;
            _listOfVehicles = new Garage<Vehicle>(capacity);
            _listOfVehicleTypes = new List<string>() { "  Airplane  ",
                                                       "    Boat    ",
                                                       "    Bus     ",
                                                       "    Car     ",
                                                       " Motorcycle ",
                                                       "   Truck    "};
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

        public void Populate(int numberOfVehicles, int numberOfPredefined)
        {
            int choice = 1;
            for (int i = 0; i < numberOfVehicles - numberOfPredefined; i++)
            {
                choice = UI.Menu(choice, _listOfVehicleTypes);
                switch (choice)
                {
                    case 1:
                        AddVehicle(AskForAirplane());
                        break;
                    case 2:
                        AddVehicle(AskForBoat());
                        break;
                    case 3:
                        AddVehicle(AskForBus());
                        break;
                    case 4:
                        AddVehicle(AskForCar());
                        break;
                    case 5:
                        AddVehicle(AskForMotorcycle());
                        break;
                    case 6:
                        AddVehicle(AskForTruck());
                        break;
                }
            }
            for (int i = 0; i < numberOfPredefined; i++)
            {
                //ToDo: Implement predefined vehicles.
            }

        }

        private Vehicle AskForAirplane()
        {
            throw new NotImplementedException();
        }

        private Vehicle AskForBoat()
        {
            throw new NotImplementedException();
        }

        private Vehicle AskForBus()
        {
            throw new NotImplementedException();
        }

        private Vehicle AskForCar()
        {
            throw new NotImplementedException();
        }

        private Vehicle AskForMotorcycle()
        {
            throw new NotImplementedException();
        }

        private Vehicle AskForTruck()
        {
            throw new NotImplementedException();
        }
    }
}
