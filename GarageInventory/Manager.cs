namespace GarageInventory
{
    public class Manager
    {
        private IUI _ui;
        private List<string> _mainMenuList;
        private List<string> _garageManagerMenuList;

        public IUI UI { get { return _ui; } }
        public List<string> MainMenuList { get { return _mainMenuList; } }
        public List<string> GarageManagerMenuList { get { return _garageManagerMenuList; } }

        public Manager(IUI ui)
        {
            _ui = ui;
            _mainMenuList = new List<string>() { "   New Garage  ",
                                                 "  Load Garage  ",
                                                 "  Save Garage  ",
                                                 "      Quit     " };
            _garageManagerMenuList = new List<string>() { "       Add vehicle        ",
                                                          "      Remove vehicle      ",
                                                          "   Print vehicle stats    ",
                                                          "  List types and amounts  ",
                                                          "          Search          " };
        }
        /// <summary>
        /// Initializes the application then loads the main menu.
        /// </summary>
        public void Run()
        {
            Initialize();
            MainMenu();
        }

        /// <summary>
        /// Initializes the application.
        /// </summary>
        private void Initialize()
        {
            UI.Initialize();
        }

        /// <summary>
        /// Loads the main menu and then applies the users choice.
        /// </summary>
        public void MainMenu()
        {
            int choice = 1;
            choice = UI.Menu(choice, _mainMenuList);
            switch (choice)
            {
                case 1:
                    NewGarage();
                    break;
                case 2:
                    LoadGarage();
                    break;
                case 3:
                    SaveGarage();
                    break;
                case 4:
                    UI.Quit();
                    break;
            }
        }

        /// <summary>
        /// Starts a new garage.
        /// </summary>
        private void NewGarage()
        {
            UI.Clear();
            int capacity = UI.AskForInt("Number of parking spaces");
            IHandler handler = new Handler(capacity, UI);
            int prepopulated;
            int predefined;
            bool incorrect = true;
            do
            {
                prepopulated = UI.AskForInt("Number of parking spaces to be prepopulated");

                if (prepopulated > capacity)
                {
                    UI.AddToMessageLog("Invalid number. Cant be higher than number of parking spaces.");
                }
                else if (prepopulated < 0)
                {
                    UI.AddToMessageLog("Invalid number. Can't be negative.");
                }
                else
                {
                    incorrect = false;
                }
            } while (incorrect);
            incorrect = true;
            do
            {
                predefined = UI.AskForInt("Number of prepopulated to automatically define (max 80)");
                if (predefined > prepopulated)
                {
                    UI.AddToMessageLog("Invalid number. Cant be higher than number to prepopulate.");
                }
                else if (prepopulated < 0)
                {
                    UI.AddToMessageLog("Invalid number. Can't be negative.");
                }
                else
                {
                    incorrect = false;
                }
                if (predefined > 80)
                {
                    UI.AddToMessageLog("Invalid number. Cant be higher than 80.");
                    incorrect = true;
                }
            } while (incorrect);
            handler.Populate(prepopulated, predefined);
            GarageManager(handler);
        }

        //ToDo: XML method summary!
        private void LoadGarage()
        {
            //ToDo: Implement Load functionality!
        }

        //ToDo: XML method summary!
        private void SaveGarage()
        {
            //ToDo: Implement Save functionality!
        }

        /// <summary>
        /// Moves the application to the Handler class with the chosen functionality.
        /// </summary>
        /// <param name="handler"></param>
        public void GarageManager(IHandler handler)
        {
            int choice = 1;
            do
            {
                choice = UI.Menu(choice, GarageManagerMenuList);
                switch (choice)
                {
                    case 1:
                        handler.AddVehicle(1);
                        break;
                    case 2:
                        handler.RemoveVehicle(handler.ListAllParked());
                        break;
                    case 3:
                        var vehicle = handler.ListAllParked();
                        vehicle.PrintVehicle(UI, vehicle);
                        break;
                    case 4:
                        handler.ListTypesAndAmounts();
                        break;
                    case 5:
                        handler.Search();
                        break;
                }
            } while (true);
        }

    }
}
