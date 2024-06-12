using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Vehicle
    {
        private string _licensePlateNumber;
        private string _color;
        private int _numberOfWheels;
        private string _make;
        private string _model;
        private int _year;
        private string _description;
        private bool _forRent;

        public string LicensePlateNumber { get { return _licensePlateNumber; } set { _licensePlateNumber = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public int NumberOfWheels { get { return _numberOfWheels; } set { _numberOfWheels = value; } }
        public string Make { get { return _make; } set { _make = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public int Year { get { return _year; } set { _year = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public bool ForRent { get { return _forRent; } set { _forRent = value; } }

        public Vehicle(string licensePlateNumber, string color, int numberOfWheels, string make, string model, int year, string description, bool forRent)
        {
            _licensePlateNumber = licensePlateNumber;
            _color = color;
            _numberOfWheels = numberOfWheels;
            _make = make;
            _model = model;
            _year = year;
            _description = description;
            _forRent = forRent;
        }

    }
    internal class Airplane : Vehicle
    {
        private int _wingspan;

        public int Wingspan { get { return _wingspan; } set { _wingspan = value; } }

        public Airplane(string licensePlateNumber, string color, int numberOfWheels, string make, string model, int year, string description, bool forRent, int wingspan) 
            : base(licensePlateNumber, color, numberOfWheels, make, model, year, description, forRent)
        {
            _wingspan = wingspan;
        }

    }
    internal class Boat : Vehicle
    {
        private int _length;

        public int Length { get { return _length; } set { _length = value; } }

        public Boat(string licensePlateNumber, string color, int numberOfWheels, string make, string model, int year, string description, bool forRent, int length) 
            : base(licensePlateNumber, color, numberOfWheels, make, model, year, description, forRent)
        {
            _length = length;
        }

    }
    internal class Bus : Vehicle
    {
        private int _numberOfSeats;

        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }

        public Bus(string licensePlateNumber, string color, int numberOfWheels, string make, string model, int year, string description, bool forRent, int numberOfSeats) 
            : base(licensePlateNumber, color, numberOfWheels, make, model, year, description, forRent)
        {
            _numberOfSeats = numberOfSeats;
        }

    }
    internal class Car : Vehicle
    {
        private string _fuelType;
        
        public string FuelType { get { return _fuelType; } set { _fuelType = value; } }

        public Car(string licensePlateNumber, string color, int numberOfWheels, string make, string model, int year, string description, bool forRent, string fuelType)
            : base(licensePlateNumber, color, numberOfWheels, make, model, year, description, forRent)
        {
            _fuelType = fuelType;
        }

    }
    internal class Motorcycle : Vehicle
    {
        private int _cylinderVolumeInCC;

        public int CylinderVolumeInCC { get { return _cylinderVolumeInCC; } set { _cylinderVolumeInCC = value; } }

        public Motorcycle(string licensePlateNumber, string color, int numberOfWheels, string make, string model, int year, string description, bool forRent, int cylinderVolumeInCC) 
            : base(licensePlateNumber, color, numberOfWheels, make, model, year, description, forRent)
        {
            _cylinderVolumeInCC = cylinderVolumeInCC;
        }

    }
}
