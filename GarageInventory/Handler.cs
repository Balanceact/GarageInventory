namespace GarageInventory
{
    public class Handler : IHandler
    {
        private IUI _ui;
        private IGarage<Vehicle> _listOfVehicles;
        private List<string> _listOfVehicleTypes;
        private List<string> _isForRent;
        private List<string> _isElectric;
        private List<string> _vehicleProperties;
        private List<Vehicle> _listOfPredefinedVehicles;

        public IUI UI { get { return _ui; } }
        public IGarage<Vehicle> ListOfVehicles { get { return _listOfVehicles; } }
        public List<string> ListOfVehicleTypes { get { return _listOfVehicleTypes; } }
        public List<string> IsForRent { get { return _isForRent; } }
        public List<string> IsElectric { get { return _isElectric; } }
        public List<string> VehicleProperties { get { return _vehicleProperties; } }
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
                                                       "   Truck    " };
            _isForRent = new List<string>() { "   Is for rent   ",
                                              " Is not for rent " };
            _isElectric = new List<string>() { "   Is electric   ",
                                               " Is not electric " };
            _vehicleProperties = new List<string>() { " License Plate Number ",
                                                      "  All the properties  " };
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
                new Airplane("N2430V", "Cesna", "140", 2018, 3, "Green", "Small single engine" , false, 345, 1),
                new Airplane("N2432V", "Cesna", "140", 2018, 3, "Green", "Small single engine" , true, 345, 1),
                new Airplane("N2433V", "Cesna", "140", 2018, 3, "Yellow", "Small single engine" , false, 345, 1),
                new Airplane("N2434V", "Cesna", "140", 2018, 3, "Yellow", "Small single engine" , true, 345, 1),
                new Airplane("N2435V", "Cesna", "140", 2018, 3, "Purple", "Small single engine" , false, 345, 1),
                new Airplane("N2436V", "Cesna", "140", 2018, 3, "Purple", "Small single engine" , true, 345, 1),
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
                new Boat("KRP560", "Cranchi", "E26 Classic", 2019, 0, "Green", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP561", "Cranchi", "E26 Classic", 2019, 0, "Green", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Boat("KRP562", "Cranchi", "E26 Classic", 2019, 0, "Yellow", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP563", "Cranchi", "E26 Classic", 2019, 0, "Yellow", "Old-school cuddy cabin inboard engine sportster", true, 780),
                new Boat("KRP564", "Cranchi", "E26 Classic", 2019, 0, "Purple", "Old-school cuddy cabin inboard engine sportster", false, 780),
                new Boat("KRP565", "Cranchi", "E26 Classic", 2019, 0, "Purple", "Old-school cuddy cabin inboard engine sportster", true, 780),
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
                new Bus("BUS010", "Volvo", "9700", 2022, 10, "Green", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS011", "Volvo", "9700", 2022, 10, "Green", "Common bus for inter city public transport.", true, 49),
                new Bus("BUS012", "Volvo", "9700", 2022, 10, "Yellow", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS013", "Volvo", "9700", 2022, 10, "Yellow", "Common bus for inter city public transport.", true, 49),
                new Bus("BUS014", "Volvo", "9700", 2022, 10, "Purple", "Common bus for inter city public transport.", false, 49),
                new Bus("BUS015", "Volvo", "9700", 2022, 10, "Purple", "Common bus for inter city public transport.", true, 49),
                new Car("SKA540", "Volvo", "244 DL", 1986, 4, "White", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA541", "Volvo", "244 DL", 1986, 4, "White", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA542", "Volvo", "244 DL", 1986, 4, "Silver", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA543", "Volvo", "244 DL", 1986, 4, "Silver", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA544", "Volvo", "244 DL", 1986, 4, "Black", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA545", "Volvo", "244 DL", 1986, 4, "Black", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA546", "Volvo", "244 DL", 1986, 4, "Blue", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA547", "Volvo", "244 DL", 1986, 4, "Blue", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA548", "Volvo", "244 DL", 1986, 4, "Red", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA549", "Volvo", "244 DL", 1986, 4, "Red", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA550", "Volvo", "244 DL", 1986, 4, "Green", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA551", "Volvo", "244 DL", 1986, 4, "Green", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA552", "Volvo", "244 DL", 1986, 4, "Yellow", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA553", "Volvo", "244 DL", 1986, 4, "Yellow", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SKA554", "Volvo", "244 DL", 1986, 4, "Purple", "DL (De Luxe) indicates the base model.", false, "Gas"),
                new Car("SKA555", "Volvo", "244 DL", 1986, 4, "Purple", "DL (De Luxe) indicates the base model.", true, "Gas"),
                new Car("SAB950", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "White", "Only available second-hand.", false, "Diesel"),
                new Car("SAB951", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "White", "Only available second-hand.", true, "Diesel"),
                new Car("SAB952", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Silver", "Only available second-hand.", false, "Diesel"),
                new Car("SAB953", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Silver", "Only available second-hand.", true, "Diesel"),
                new Car("SAB954", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Black", "Only available second-hand.", false, "Diesel"),
                new Car("SAB955", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Black", "Only available second-hand.", true, "Diesel"),
                new Car("SAB956", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Blue", "Only available second-hand.", false, "Diesel"),
                new Car("SAB957", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Blue", "Only available second-hand.", true, "Diesel"),
                new Car("SAB958", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Red", "Only available second-hand.", false, "Diesel"),
                new Car("SAB959", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Red", "Only available second-hand.", true, "Diesel"),
                new Car("SAB960", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Green", "Only available second-hand.", false, "Diesel"),
                new Car("SAB961", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Green", "Only available second-hand.", true, "Diesel"),
                new Car("SAB962", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Yellow", "Only available second-hand.", false, "Diesel"),
                new Car("SAB963", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Yellow", "Only available second-hand.", true, "Diesel"),
                new Car("SAB964", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Purple", "Only available second-hand.", false, "Diesel"),
                new Car("SAB965", "Saab", "9-5 SportCombi TTiD4", 2011, 4, "Purple", "Only available second-hand.", true, "Diesel"),
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
                new Car("PEG010", "Peugeot", "e-208 156hp", 2024, 4, "Green", "Small and nifty!", false, "Electric"),
                new Car("PEG011", "Peugeot", "e-208 156hp", 2024, 4, "Green", "Small and nifty!", true, "Electric"),
                new Car("PEG012", "Peugeot", "e-208 156hp", 2024, 4, "Yellow", "Small and nifty!", false, "Electric"),
                new Car("PEG013", "Peugeot", "e-208 156hp", 2024, 4, "Yellow", "Small and nifty!", true, "Electric"),
                new Car("PEG014", "Peugeot", "e-208 156hp", 2024, 4, "Purple", "Small and nifty!", false, "Electric"),
                new Car("PEG015", "Peugeot", "e-208 156hp", 2024, 4, "Purple", "Small and nifty!", true, "Electric"),
                new Motorcycle("FAT000", "Harley Davidson", "Fat Boy 114", 2022, 2, "White", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT001", "Harley Davidson", "Fat Boy 114", 2022, 2, "White", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT002", "Harley Davidson", "Fat Boy 114", 2022, 2, "Silver", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT003", "Harley Davidson", "Fat Boy 114", 2022, 2, "Silver", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT004", "Harley Davidson", "Fat Boy 114", 2022, 2, "Black", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT005", "Harley Davidson", "Fat Boy 114", 2022, 2, "Black", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT006", "Harley Davidson", "Fat Boy 114", 2022, 2, "Blue", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT007", "Harley Davidson", "Fat Boy 114", 2022, 2, "Blue", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT008", "Harley Davidson", "Fat Boy 114", 2022, 2, "Red", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT009", "Harley Davidson", "Fat Boy 114", 2022, 2, "Red", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT010", "Harley Davidson", "Fat Boy 114", 2022, 2, "Green", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT011", "Harley Davidson", "Fat Boy 114", 2022, 2, "Green", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT012", "Harley Davidson", "Fat Boy 114", 2022, 2, "Yellow", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT013", "Harley Davidson", "Fat Boy 114", 2022, 2, "Yellow", "A V-twin softail cruiser.", true, 1690),
                new Motorcycle("FAT014", "Harley Davidson", "Fat Boy 114", 2022, 2, "Purple", "A V-twin softail cruiser.", false, 1690),
                new Motorcycle("FAT015", "Harley Davidson", "Fat Boy 114", 2022, 2, "Purple", "A V-twin softail cruiser.", true, 1690),
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
                new Truck("TRK010", "Scania", "P360", 2024, 10, "Green", "Compact with a low cab weight", false, false),
                new Truck("TRK011", "Scania", "P360", 2024, 10, "Green", "Compact with a low cab weight", true, false),
                new Truck("TRK012", "Scania", "P360", 2024, 10, "Yellow", "Compact with a low cab weight", false, false),
                new Truck("TRK013", "Scania", "P360", 2024, 10, "Yellow", "Compact with a low cab weight", true, false),
                new Truck("TRK014", "Scania", "P360", 2024, 10, "Purple", "Compact with a low cab weight", false, false),
                new Truck("TRK015", "Scania", "P360", 2024, 10, "Purple", "Compact with a low cab weight", true, false),
            };
        }

        /// <summary>
        /// Searches the vehicles in the garage to match their properties to the search terms.
        /// </summary>
        public void Search()
        {
            int choice = 1;
            string searchParameter;
            choice = UI.Menu(choice, VehicleProperties);
            switch (choice)
            {
                case 1: //  Search by: LicensePlateNumber
                    searchParameter = UI.AskForString("License plate number");
                    var vehicle = SearchByLicensePlateNumber(searchParameter);
                    if (vehicle == null)
                        UI.AddToMessageLog("License plate number not found!");
                    else
                        vehicle.PrintVehicle(UI, vehicle);
                    break;
                case 2: //  Search by: All the properties
                    searchParameter = UI.AskForString("Any property");
                    List<string> properties = new();
                    foreach (Vehicle item in ListOfVehicles)
                    {
                        properties.Add(item.AllProperties());
                    }
                    int i = 0;
                    List<Vehicle> vehicles = new();
                    string[] query = searchParameter.Split(' ');
                    foreach (string item in properties)                 
                    {
                        for (int j = 0; j < query.Length; j++)
                        {
                            if (item.ToLower().Contains(query[j].ToLower()))    // ToDo: Refine search!
                            {
                                vehicles.Add(ListOfVehicles[i]);
                            }
                        }
                        i++;
                    }
                    List<string> vehiclesToPrint = new();
                    foreach (Vehicle item in vehicles)
                    {
                        vehiclesToPrint.Add(item.ToString());
                    }
                    int choice2 = 1;
                    choice2 = UI.MenuPaged(choice2, vehiclesToPrint);
                    vehicles[choice2 - 1].PrintVehicle(UI, vehicles[choice2 - 1]);
                    break;
            }
        }

        /// <summary>
        /// Searches in the Garage array after a vehicle with the stated license plate that equals searchParameter and returns that vehicle if it finds it.
        /// </summary>
        /// <param name="searchParameter"></param>
        /// <returns></returns>
        public Vehicle SearchByLicensePlateNumber(string searchParameter)
        {
            foreach (Vehicle item in ListOfVehicles)
            {
                if (item.LicensePlateNumber.ToUpper() == searchParameter.ToUpper())
                {
                    return item;
                }
            }
            return null!;
        }

        /// <summary>
        /// Checks if the garage is full, if not then adds the vehicle to the garage.
        /// </summary>
        /// <param name="vehicle"></param>
        public void AddVehicleToList(Vehicle vehicle)
        {
            _listOfVehicles[_listOfVehicles.ParkingSpacesFilled] = vehicle;
            _listOfVehicles.ParkingSpacesFilled++;
            UI.AddToMessageLog("Vehicle added to Garage!");
        }

        /// <summary>
        /// Lists how many of each type of vehicle is currently parked in the garage.
        /// </summary>
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
            UI.AddToMessageLog($"Airplane:      {airplane}");
            UI.AddToMessageLog($"Boat:          {boat}");
            UI.AddToMessageLog($"Bus:           {bus}");
            UI.AddToMessageLog($"Car:           {car}");
            UI.AddToMessageLog($"Motorcycle:    {motorcycle}");
            UI.AddToMessageLog($"Truck:         {truck}");
        }

        /// <summary>
        /// Lists all the vehicles currently parked in the garage and lets you select one of them.
        /// </summary>
        public Vehicle ListAllParked()
        {
            int selection = 0;
            selection = UI.MenuPaged(1, _listOfVehicles.AllParkedToString());
            return _listOfVehicles[selection];
        }

        /// <summary>
        /// Removes the selected vehicle.
        /// </summary>
        /// <param name="vehicle"></param>
        public void RemoveVehicle(Vehicle vehicle)
        {
            foreach (var v in _listOfVehicles)
            {
                if (v == vehicle)
                {
                    _listOfVehicles.Remove(vehicle);
                    _listOfVehicles.ParkingSpacesFilled--;
                    UI.AddToMessageLog("Vehicle removed from Garage!");
                }
            }
        }

        /// <summary>
        /// Populates a garage with either user defined or predefined vehicles.
        /// </summary>
        /// <param name="numberOfVehicles"></param>
        /// <param name="numberOfPredefined"></param>
        public void Populate(int numberOfVehicles, int numberOfPredefined)
        {
            int myRandom;
            Random random = new Random();
            for (int i = 0; i < numberOfPredefined; i++)
            {
                myRandom = random.Next(127 - i);
                AddVehicleToList(ListOfPredefinedVehicles[myRandom]);
                ListOfPredefinedVehicles.RemoveAt(myRandom);
            }
            AddVehicle(numberOfVehicles - numberOfPredefined);
        }

        /// <summary>
        /// Adds a user defined vehicle to the garage.
        /// </summary>
        /// <param name="numberOfVehicles"></param>
        public void AddVehicle(int numberOfVehicles)
        {
            int choice = 1;
            for (int i = 0; i < numberOfVehicles; i++)
            {
                if (_listOfVehicles.IsFull)
                {
                    UI.AddToMessageLog("The garage is full!");
                }
                else
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
                    UI.AddToMessageLog("User defined vehicle has been added to the garage!");
                }
            }
        }

        /// <summary>
        /// Asks the user for a license plate number and verifies that it's unique.
        /// </summary>
        /// <returns></returns>
        private string AskForLicensePlateNumber()
        {
            string licensePlateNumber = UI.AskForString("License plate number");
            bool incorrect = true;
            do
            {
                int i = 0;
                foreach (Vehicle item in ListOfVehicles)
                {
                    if (item.LicensePlateNumber.ToUpper() == licensePlateNumber.ToUpper())
                    {
                        i++;
                    }
                }
                if (i > 0)
                {
                    UI.AddToMessageLog($"{licensePlateNumber} is not unique!");
                    licensePlateNumber = UI.AskForString("License plate number");
                }
                else if (i == 0)
                    incorrect = false;
            } while (incorrect);
            return licensePlateNumber;
        }

        /// <summary>
        /// Asks the user for an airplanes properties.
        /// </summary>
        /// <returns></returns>
        private Vehicle AskForAirplane()
        {
            string licensePlateNumber = AskForLicensePlateNumber();
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

        /// <summary>
        /// Asks the user for a boats properties.
        /// </summary>
        /// <returns></returns>
        private Vehicle AskForBoat()
        {
            string licensePlateNumber = AskForLicensePlateNumber();
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

        /// <summary>
        /// Asks the user for a bus's properties.
        /// </summary>
        /// <returns></returns>
        private Vehicle AskForBus()
        {
            string licensePlateNumber = AskForLicensePlateNumber();
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

        /// <summary>
        /// Asks the user for a cars properties.
        /// </summary>
        /// <returns></returns>
        private Vehicle AskForCar()
        {
            string licensePlateNumber = AskForLicensePlateNumber();
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

        /// <summary>
        /// Asks the user for a motorcycles properties.
        /// </summary>
        /// <returns></returns>
        private Vehicle AskForMotorcycle()
        {
            string licensePlateNumber = AskForLicensePlateNumber();
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

        /// <summary>
        /// Asks the user for a trucks properties.
        /// </summary>
        /// <returns></returns>
        private Vehicle AskForTruck()
        {
            string licensePlateNumber = AskForLicensePlateNumber();
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
