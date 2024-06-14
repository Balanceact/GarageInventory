namespace GarageInventory
{
    internal abstract class Vehicle
    {
        private string _licensePlateNumber;
        private string _make;
        private string _model;
        private int _year;
        private int _numberOfWheels;
        private string _color;
        private string _description;
        private bool _forRent;

        public string LicensePlateNumber { get { return _licensePlateNumber; } set { _licensePlateNumber = value; } }
        public string Make { get { return _make; } set { _make = value; } }
        public string Model { get { return _model; } set { _model = value; } }
        public int Year { get { return _year; } set { _year = value; } }
        public int NumberOfWheels { get { return _numberOfWheels; } set { _numberOfWheels = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public bool ForRent { get { return _forRent; } set { _forRent = value; } }

        public Vehicle(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent)
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
        private int _numberOfEngines;

        public int Wingspan { get { return _wingspan; } set { _wingspan = value; } }

        public Airplane(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent, int wingspan, int numberOfEngines)
            : base(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent)
        {
            _wingspan = wingspan;
            _numberOfEngines = numberOfEngines;
        }

    }

    internal class Boat : Vehicle
    {
        private int _length;

        public int Length { get { return _length; } set { _length = value; } }

        public Boat(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent, int length)
            : base(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent)
        {
            _length = length;
        }

    }

    internal class Bus : Vehicle
    {
        private int _numberOfSeats;

        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }

        public Bus(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent, int numberOfSeats)
            : base(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent)
        {
            _numberOfSeats = numberOfSeats;
        }

    }

    internal class Car : Vehicle
    {
        private string _fuelType;

        public string FuelType { get { return _fuelType; } set { _fuelType = value; } }

        public Car(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent, string fuelType)
            : base(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent)
        {
            _fuelType = fuelType;
        }

    }

    internal class Motorcycle : Vehicle
    {
        private int _cylinderVolumeInCC;

        public int CylinderVolumeInCC { get { return _cylinderVolumeInCC; } set { _cylinderVolumeInCC = value; } }

        public Motorcycle(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent, int cylinderVolumeInCC)
            : base(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent)
        {
            _cylinderVolumeInCC = cylinderVolumeInCC;
        }

    }

    internal class Truck : Vehicle
    {
        private bool _isElectric;

        public bool IsElectric { get { return _isElectric; } set { _isElectric = value; } }

        public Truck(string licensePlateNumber, string make, string model, int year, int numberOfWheels, string color, string description, bool forRent, bool isElectric)
            : base(licensePlateNumber, make, model, year, numberOfWheels, color, description, forRent)
        {
            _isElectric = isElectric;
        }
    }
}
