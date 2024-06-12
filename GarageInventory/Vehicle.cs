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

        public string LicensePlateNumber
        {
            get { return _licensePlateNumber; }
            set { _licensePlateNumber = value; }
        }

    }
    internal class Airplane : Vehicle
    {
        private int _wingspan;

        public int Wingspan { get { return _wingspan; } set { _wingspan = value; } }
    }
    internal class Boat : Vehicle
    {
        private int _length;

        public int Length { get { return _length; } set { _length = value; } }
    }
    internal class Bus : Vehicle
    {
        private int _numberOfSeats;

        public int NumberOfSeats { get { return _numberOfSeats; } set { _numberOfSeats = value; } }
    }
    internal class Car : Vehicle
    {
        private int _fuelType;

        public int FuelType { get { return _fuelType; } set { _fuelType = value; } }
    }
    internal class Motorcycle : Vehicle
    {
        private int _cylinderVolume;

        public int CylinderVolume { get { return _cylinderVolume; } set { _cylinderVolume = value; } }

    }
}
