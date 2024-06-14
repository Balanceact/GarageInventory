using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Manager
    {
        private IUI _ui;
        private List<string> _mainMenuList;

        public IUI UI { get { return _ui; } }
        public List<string> MainMenuList { get { return _mainMenuList; } }

        public Manager(IUI ui)
        {
            _ui = ui;
            _mainMenuList = new List<string>() { "   New Garage  ",
                                                 "  Load Garage  ",
                                                 "  Save Garage  ",
                                                 "      Quit     " };
        }

        public void Run()
        {
            Initialize();
            MainMenu();
        }

        private void Initialize()
        {
            UI.Initialize();
        }

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
                    UI.WriteLine("Invalid number. Cant be higher than number of parking spaces.");
                }
                else if (prepopulated < 0)
                {
                    UI.WriteLine("Invalid number. Can't be negative.");
                }
                else
                {
                    incorrect = false;
                }
            } while (incorrect);
            incorrect = true;
            do
            { 
                predefined = UI.AskForInt("Number of prepopulated to automatically define");
                if (predefined > prepopulated)
                {
                    UI.WriteLine("Invalid number. Cant be higher than number to prepopulate.");
                }
                else if (prepopulated < 0)
                {
                    UI.WriteLine("Invalid number. Can't be negative.");
                }
                else
                {
                    incorrect = false;
                }
            } while (incorrect);
            handler.Populate(prepopulated, predefined);
            //ToDo: Fully implement NewGarage().
        }

        private void LoadGarage()
        {
            throw new NotImplementedException();
        }

        private void SaveGarage()
        {
            throw new NotImplementedException();
        }
    }
}
