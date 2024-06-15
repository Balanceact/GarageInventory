namespace GarageInventory
{
    internal class Handler : IHandler
    {
        private IUI _ui;
        private IGarage<Vehicle> _listOfVehicles;
        private List<string> _listOfVehicleTypes;
        private List<string> _isForRent;
        private List<string> _isElectric;
        private List<Vehicle> _listOfPredefinedVehicles;

        public IUI UI { get { return _ui; } }
        public List<string> ListOfVehicleTypes { get { return _listOfVehicleTypes; } }
        public List<string> IsForRent { get { return _isForRent; } }
        public List<string> IsElectric { get { return _isElectric; } }
        public List<Vehicle> ListOfPredefinedVehicles { get { return _listOfPredefinedVehicles; } }

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
            _isForRent = new List<string>() { "   Is for rent   ",
                                              " Is not for rent " };
            _isElectric = new List<string>() { "   Is electric   ",
                                               " Is not electric " };
            _listOfPredefinedVehicles = new List<Vehicle>()
            {
                new Airplane("N2422V", "Cesna", "140", 2018, 3, "White", "Small single engine" , false, 345, 1),
                new Airplane("N2423V", "Cesna", "140", 2018, 3, "White", "Small single engine" , true, 345, 1),
                new Airplane("N2424V", "Cesna", "140", 2018, 3, "Silver", "Small single engine" , false, 345, 1),
                new Airplane("N2425V", "Cesna", "140", 2018, 3, "Silver", "Small single engine" , true, 345, 1),
                new Airplane("N2426V", "Cesna", "140", 2018, 3, "Black", "Small single engine" , false, 345, 1),
                new Airplane("N2427V", "Cesna", "140", 2018, 3, "Black", "Small single engine" , true, 345, 1),
                new Airplane("N2428V", "Cesna", "140", 2018, 3, "Blue", "Small single engine" , false, 345, 1),
                new Airplane("N2429V", "Cesna", "140", 2018, 3, "Blue", "Small single engine" , true, 345, 1),
                new Airplane("N2430V", "Cesna", "140", 2018, 3, "Red", "Small single engine" , false, 345, 1),
                new Airplane("N2431V", "Cesna", "140", 2018, 3, "Red", "Small single engine" , true, 345, 1),
                new Boat("KRP550", "Cranchi", "E26 Classic", 2019, 0, "White", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP551", "Cranchi", "E26 Classic", 2019, 0, "White", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Boat("KRP552", "Cranchi", "E26 Classic", 2019, 0, "Silver", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP553", "Cranchi", "E26 Classic", 2019, 0, "Silver", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Boat("KRP554", "Cranchi", "E26 Classic", 2019, 0, "Black", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP555", "Cranchi", "E26 Classic", 2019, 0, "Black", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Boat("KRP556", "Cranchi", "E26 Classic", 2019, 0, "Blue", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP557", "Cranchi", "E26 Classic", 2019, 0, "Blue", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Boat("KRP558", "Cranchi", "E26 Classic", 2019, 0, "Red", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP559", "Cranchi", "E26 Classic", 2019, 0, "Red", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Bus("BUS000", "Volvo", "9700", 2022, 10, "White", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS001", "Volvo", "9700", 2022, 10, "White", "Common bus for inter city public transport.", true, 49),
                new Bus("BUS002", "Volvo", "9700", 2022, 10, "Silver", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS003", "Volvo", "9700", 2022, 10, "Silver", "Common bus for inter city public transport.", true, 49),
                new Bus("BUS004", "Volvo", "9700", 2022, 10, "Black", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS005", "Volvo", "9700", 2022, 10, "Black", "Common bus for inter city public transport.", true, 49),
                new Bus("BUS006", "Volvo", "9700", 2022, 10, "Blue", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS007", "Volvo", "9700", 2022, 10, "Blue", "Common bus for inter city public transport.", true, 49),
                new Bus("BUS008", "Volvo", "9700", 2022, 10, "Red", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS009", "Volvo", "9700", 2022, 10, "Red", "Common bus for inter city public transport.", true, 49),
                new Car("SKA540", "Volvo", "244 DL", 1986, 4, "White", "DL (De Luxe) indicates the base model with modest interiors and accessories", false, "Petrol"),
                new Car("SKA541", "Volvo", "244 DL", 1986, 4, "White", "DL (De Luxe) indicates the base model with modest interiors and accessories", true, "Petrol"),
                new Car("SKA542", "Volvo", "244 DL", 1986, 4, "Silver", "DL (De Luxe) indicates the base model with modest interiors and accessories", false, "Petrol"),
                new Car("SKA543", "Volvo", "244 DL", 1986, 4, "Silver", "DL (De Luxe) indicates the base model with modest interiors and accessories", true, "Petrol"),
                new Car("SKA544", "Volvo", "244 DL", 1986, 4, "Black", "DL (De Luxe) indicates the base model with modest interiors and accessories", false, "Petrol"),
                new Car("SKA545", "Volvo", "244 DL", 1986, 4, "Black", "DL (De Luxe) indicates the base model with modest interiors and accessories", true, "Petrol"),
                new Car("SKA546", "Volvo", "244 DL", 1986, 4, "Blue", "DL (De Luxe) indicates the base model with modest interiors and accessories", false, "Petrol"),
                new Car("SKA547", "Volvo", "244 DL", 1986, 4, "Blue", "DL (De Luxe) indicates the base model with modest interiors and accessories", true, "Petrol"),
                new Car("SKA548", "Volvo", "244 DL", 1986, 4, "Red", "DL (De Luxe) indicates the base model with modest interiors and accessories", false, "Petrol"),
                new Car("SKA549", "Volvo", "244 DL", 1986, 4, "Red", "DL (De Luxe) indicates the base model with modest interiors and accessories", true, "Petrol"),
                new Car("SAB950", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "White", "Test car used at Millbrook proving grounds in the UK", false, "Diesel"),
                new Car("SAB951", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "White", "Test car used at Millbrook proving grounds in the UK", true, "Diesel"),
                new Car("SAB952", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Silver", "Test car used at Millbrook proving grounds in the UK", false, "Diesel"),
                new Car("SAB953", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Silver", "Test car used at Millbrook proving grounds in the UK", true, "Diesel"),
                new Car("SAB954", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Black", "Test car used at Millbrook proving grounds in the UK", false, "Diesel"),
                new Car("SAB955", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Black", "Test car used at Millbrook proving grounds in the UK", true, "Diesel"),
                new Car("SAB956", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Blue", "Test car used at Millbrook proving grounds in the UK", false, "Diesel"),
                new Car("SAB957", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Blue", "Test car used at Millbrook proving grounds in the UK", true, "Diesel"),
                new Car("SAB958", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Red", "Test car used at Millbrook proving grounds in the UK", false, "Diesel"),
                new Car("SAB959", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Red", "Test car used at Millbrook proving grounds in the UK", true, "Diesel"),
                new Car("PEG000", "Peugeot", "e-208 156hp", 2024, 4, "White", "Small and nifty!", false, "Electric"),
                new Car("PEG001", "Peugeot", "e-208 156hp", 2024, 4, "White", "Small and nifty!", true, "Electric"),
                new Car("PEG002", "Peugeot", "e-208 156hp", 2024, 4, "Silver", "Small and nifty!", false, "Electric"),
                new Car("PEG003", "Peugeot", "e-208 156hp", 2024, 4, "Silver", "Small and nifty!", true, "Electric"),
                new Car("PEG004", "Peugeot", "e-208 156hp", 2024, 4, "Black", "Small and nifty!", false, "Electric"),
                new Car("PEG005", "Peugeot", "e-208 156hp", 2024, 4, "Black", "Small and nifty!", true, "Electric"),
                new Car("PEG006", "Peugeot", "e-208 156hp", 2024, 4, "Blue", "Small and nifty!", false, "Electric"),
                new Car("PEG007", "Peugeot", "e-208 156hp", 2024, 4, "Blue", "Small and nifty!", true, "Electric"),
                new Car("PEG008", "Peugeot", "e-208 156hp", 2024, 4, "Red", "Small and nifty!", false, "Electric"),
                new Car("PEG009", "Peugeot", "e-208 156hp", 2024, 4, "Red", "Small and nifty!", true, "Electric"),
                new Motorcycle("FAT000", "Harley Davidson", "Fat Boy 114", 2022, 2, "White", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", false, 1690),
                new Motorcycle("FAT001", "Harley Davidson", "Fat Boy 114", 2022, 2, "White", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", true, 1690),
                new Motorcycle("FAT002", "Harley Davidson", "Fat Boy 114", 2022, 2, "Silver", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", false, 1690),
                new Motorcycle("FAT003", "Harley Davidson", "Fat Boy 114", 2022, 2, "Silver", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", true, 1690),
                new Motorcycle("FAT004", "Harley Davidson", "Fat Boy 114", 2022, 2, "Black", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", false, 1690),
                new Motorcycle("FAT005", "Harley Davidson", "Fat Boy 114", 2022, 2, "Black", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", true, 1690),
                new Motorcycle("FAT006", "Harley Davidson", "Fat Boy 114", 2022, 2, "Blue", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", false, 1690),
                new Motorcycle("FAT007", "Harley Davidson", "Fat Boy 114", 2022, 2, "Blue", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", true, 1690),
                new Motorcycle("FAT008", "Harley Davidson", "Fat Boy 114", 2022, 2, "Red", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", false, 1690),
                new Motorcycle("FAT009", "Harley Davidson", "Fat Boy 114", 2022, 2, "Red", "The Harley-Davidson Fat Boy, is a V-twin softail cruiser motorcycle with solid-cast disc wheels.", true, 1690),
                new Truck("TRK000", "Scania", "P360", 2024, 10, "White", "Compact with a low cab weight", false, false),
                new Truck("TRK001", "Scania", "P360", 2024, 10, "White", "Compact with a low cab weight", true, false),
                new Truck("TRK002", "Scania", "P360", 2024, 10, "Silver", "Compact with a low cab weight", false, false),
                new Truck("TRK003", "Scania", "P360", 2024, 10, "Silver", "Compact with a low cab weight", true, false),
                new Truck("TRK004", "Scania", "P360", 2024, 10, "Black", "Compact with a low cab weight", false, false),
                new Truck("TRK005", "Scania", "P360", 2024, 10, "Black", "Compact with a low cab weight", true, false),
                new Truck("TRK006", "Scania", "P360", 2024, 10, "Blue", "Compact with a low cab weight", false, false),
                new Truck("TRK007", "Scania", "P360", 2024, 10, "Blue", "Compact with a low cab weight", true, false),
                new Truck("TRK008", "Scania", "P360", 2024, 10, "Red", "Compact with a low cab weight", false, false),
                new Truck("TRK009", "Scania", "P360", 2024, 10, "Red", "Compact with a low cab weight", true, false),
            };
        }

        public void AddVehicleToList(Vehicle vehicle)
        {
            if (_listOfVehicles.ParkingSpacesFilled == _listOfVehicles.Count)
            {
                UI.WriteLine("Garage is full!");                                //ToDo: Message log.
            }
            else
            {
                _listOfVehicles[_listOfVehicles.ParkingSpacesFilled] = vehicle;
                _listOfVehicles.ParkingSpacesFilled++;
                UI.WriteLine("Vehicle added to Garage!");                       //ToDo: Message log.
            }
        }

        public void ListTypesAndAmounts()
        {
            int airplane = 0, boat = 0, bus = 0, car = 0, motorcycle = 0, truck = 0;
            foreach (Vehicle vehicle in _listOfVehicles)
            {
                switch (vehicle)
                {
                    case Airplane:
                        airplane++;
                        break;
                    case Boat:
                        boat++;
                        break;
                    case Bus:
                        bus++;
                        break;
                    case Car:
                        car++;
                        break;
                    case Motorcycle:
                        motorcycle++;
                        break;
                    case Truck:
                        truck++;
                        break;
                }
            }
            UI.Clear();                                                                     //ToDo: Message log.
            UI.WriteLine($"Airplane:   {airplane}");
            UI.WriteLine($"Boat:       {boat}");
            UI.WriteLine($"Bus:        {bus}");
            UI.WriteLine($"Car:        {car}");
            UI.WriteLine($"Motorcycle: {motorcycle}");
            UI.WriteLine($"Truck:      {truck}");
            UI.ReadKey();
        }

        public void ListAllParked()
        {
            // ToDo: Implement proper menu of vehicles.
            int max = UI.Hight() - 2;
            int pages = ( _listOfVehicles.ParkingSpacesFilled / max ) + 1;
            int currentPage = 1;
            bool noChoice = true;
            do
            {
                UI.PrintPageCount(currentPage, pages);
                Console.ReadLine();
            } while (noChoice);
        }

        public Vehicle SelectVehicle()
        {
            int selection = 0;
            // ToDo: Implement proper menu and selection of vehicle.
            return _listOfVehicles[selection];
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            foreach (var v in _listOfVehicles)
            {
                if (v == vehicle)
                {
                    _listOfVehicles.Remove(vehicle);
                    UI.WriteLine("Vehicle removed from Garage!");               //ToDo: Message log.
                }
            }
        }

        public void Populate(int numberOfVehicles, int numberOfPredefined)
        {
            int myRandom;
            Random random = new Random();
            for (int i = 0; i < numberOfPredefined; i++)
            {
                myRandom = random.Next(79 - i);
                AddVehicleToList(ListOfPredefinedVehicles[myRandom]);
                ListOfPredefinedVehicles.RemoveAt(myRandom);
                //UI.WriteLine("Predefined vehicle has been added to the garage!");                   //ToDo: Message log.
            }
            UI.ReadKey();
            AddVehicle(numberOfVehicles - numberOfPredefined);
        }

        public void AddVehicle(int numberOfVehicles)
        {
            int choice = 1;
            for (int i = 0; i < numberOfVehicles; i++)
            {
                choice = UI.Menu(choice, _listOfVehicleTypes);
                switch (choice)
                {
                    case 1:
                        AddVehicleToList(AskForAirplane());
                        break;
                    case 2:
                        AddVehicleToList(AskForBoat());
                        break;
                    case 3:
                        AddVehicleToList(AskForBus());
                        break;
                    case 4:
                        AddVehicleToList(AskForCar());
                        break;
                    case 5:
                        AddVehicleToList(AskForMotorcycle());
                        break;
                    case 6:
                        AddVehicleToList(AskForTruck());
                        break;
                }
                UI.WriteLine("User defined vehicle has been added to the garage!");         //ToDo: Message log.
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
