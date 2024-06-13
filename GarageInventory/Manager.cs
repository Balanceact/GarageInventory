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
        private List<String> _mainMenuList;

        public IUI UI { get { return _ui; } }
        public List<String> MainMenuList { get { return _mainMenuList; } }

        public Manager(IUI ui)
        {
            _ui = ui;
            _mainMenuList = new List<String>() { "   New Garage  ",
                                                 "  Load Garage  ",
                                                 "  Save Garage  ",
                                                 "    Options    ",
                                                 "      Quit     " };
        }
        public void Run()
        {
            Initialize();
            int choice = MainMenu();
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
                    OptionsMenu();
                    break;
            }
        }

        private void Initialize()
        {
            //ToDo: Remove dependency on Console.
            Console.CursorVisible = false;
        }

        public int MainMenu()
        {
            int choice = 1;
            bool notChosen = true;
            do
            {
                PrintMenu(choice);
                ConsoleKey keyPress = UI.ReadKey();
                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        notChosen = false;
                        break;
                }
                if (choice == 0)
                    choice = 5;
                if (choice == 6)
                    choice = 1;
            } while (notChosen);

            return choice;
        }

        public void PrintMenu(int choice)
        {
            //Console.Clear();
            Console.SetCursorPosition(0, 0);
            UI.WriteLine("Please choose an option or press 'Esc': ");
            for (int i = 1; i < MainMenuList.Count+1; i++)
            {
                if (i == choice)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    UI.WriteLine(MainMenuList[i - 1]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    //Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    UI.WriteLine(MainMenuList[i - 1]);
                }

            }
        }

        private void NewGarage()
        {
            throw new NotImplementedException();
        }

        private void LoadGarage()
        {
            throw new NotImplementedException();
        }

        private void SaveGarage()
        {
            throw new NotImplementedException();
        }

        private void OptionsMenu()
        {
            throw new NotImplementedException();
        }

    }
}
