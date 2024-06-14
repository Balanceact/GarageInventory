using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Handler : IHandler
    {
        private IUI _ui;
        private IGarage<Vehicle> _listOfVehicles;
        private List<string> _listOfVehicleTypes;
        private List<string> _isForRent;
        private List<string> _isElectric;

        public IUI UI { get { return _ui; } }
        public List<string> ListOfVehicleTypes { get { return _listOfVehicleTypes; } }
        public List<string> IsForRent { get { return _isForRent; } }
        public List<string> IsElectric { get { return _isElectric; } }

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
            _isForRent = new List<string>() {"   Is for rent   ",
                                             " Is not for rent " };
            _isElectric = new List<string>() {"   Is electric   ",
                                              " Is not electric " };
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
            string licensePlateNumber = UI.AskForString("License plate number");
            string make = UI.AskForString("Make");
            string model = UI.AskForString("Model");
            int year = UI.AskForInt("Year");
            int numberOfWheels = UI.AskForInt("Number of wheels");
            string color = UI.AskForString("Color");
            string description = UI.AskForString("Name or description");
            bool forRent = UI.AskForBool(IsForRent);
            int wingspan = UI.AskForInt("Wingspan");
            int numberOfEngines = UI.AskForInt("Number of engines");
            Airplane airplane = new Airplane(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent, wingspan, numberOfEngines);
            return airplane;
        }
        private Vehicle AskForBoat()
        {
            string licensePlateNumber = UI.AskForString("License plate number");
            string make = UI.AskForString("Make");
            string model = UI.AskForString("Model");
            int year = UI.AskForInt("Year");
            int numberOfWheels = UI.AskForInt("Number of wheels");
            string color = UI.AskForString("Color");
            string description = UI.AskForString("Name or description");
            bool forRent = UI.AskForBool(IsForRent);
            int length = UI.AskForInt("Length");
            Boat boat = new Boat(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent, length);
            return boat;
        }

        private Vehicle AskForBus()
        {
            string licensePlateNumber = UI.AskForString("License plate number");
            string make = UI.AskForString("Make");
            string model = UI.AskForString("Model");
            int year = UI.AskForInt("Year");
            int numberOfWheels = UI.AskForInt("Number of wheels");
            string color = UI.AskForString("Color");
            string description = UI.AskForString("Name or description");
            bool forRent = UI.AskForBool(IsForRent);
            int numberOfSeats = UI.AskForInt("Number of seats");
            Bus bus = new Bus(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent, numberOfSeats);
            return bus;
        }

        private Vehicle AskForCar()
        {
            string licensePlateNumber = UI.AskForString("License plate number");
            string make = UI.AskForString("Make");
            string model = UI.AskForString("Model");
            int year = UI.AskForInt("Year");
            int numberOfWheels = UI.AskForInt("Number of wheels");
            string color = UI.AskForString("Color");
            string description = UI.AskForString("Name or description");
            bool forRent = UI.AskForBool(IsForRent);
            string fuelType = UI.AskForString("Fuel Type");
            Car car = new Car(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent, fuelType);
            return car;
        }

        private Vehicle AskForMotorcycle()
        {
            string licensePlateNumber = UI.AskForString("License plate number");
            string make = UI.AskForString("Make");
            string model = UI.AskForString("Model");
            int year = UI.AskForInt("Year");
            int numberOfWheels = UI.AskForInt("Number of wheels");
            string color = UI.AskForString("Color");
            string description = UI.AskForString("Name or description");
            bool forRent = UI.AskForBool(IsForRent);
            int cylinderVolumeInCC = UI.AskForInt("Cylinder volume in cc");
            Motorcycle motorcycle = new Motorcycle(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent, cylinderVolumeInCC);
            return motorcycle;
        }

        private Vehicle AskForTruck()
        {
            string licensePlateNumber = UI.AskForString("License plate number");
            string make = UI.AskForString("Make");
            string model = UI.AskForString("Model");
            int year = UI.AskForInt("Year");
            int numberOfWheels = UI.AskForInt("Number of wheels");
            string color = UI.AskForString("Color");
            string description = UI.AskForString("Name or description");
            bool forRent = UI.AskForBool(IsForRent);
            bool isElectric = UI.AskForBool(IsElectric);
            Truck truck = new Truck(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent, isElectric);
            return truck;
        }
    }
}
