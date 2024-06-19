namespace GarageInventory
{
    public class UI : IUI
    {
        private LimitedList<string> _messageLog;

        public int Height => Console.WindowHeight;
        public int Width => Console.WindowWidth;
        public int HalfWay => Width / 2;
        public Manager Manager { get; }

        public UI()
        {
            _messageLog = new LimitedList<string>(Height);
            Manager = new Manager(this);
        }

        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message"></param>
        public void Write(string message) { Console.Write(message); }

        /// <summary>
        /// Writes a message to the console and inserts a new-line character at the end.
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message) { Console.WriteLine(message); }

        /// <summary>
        /// Pauses the application and waits for the next keypress on the keyboard.
        /// </summary>
        /// <returns></returns>
        public ConsoleKey ReadKey() => Console.ReadKey(intercept: true).Key;

        /// <summary>
        /// Takes an input string from the user.
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            string input;
            do
            {
                input = Console.ReadLine()!.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    AddToMessageLog("Input a valid option.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        /// <summary>
        /// Asks the User for a bool with the possible choices in a List<string>.
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool AskForBool(List<string> menu)
        {
            bool input = false;
            int choice = Menu(2, menu);
            if (choice == 1)
                input = true;
            else if (choice == 2)
                input = false;
            return input;
        }

        /// <summary>
        /// Asks the User for a string as input.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public string AskForString(string prompt)
        {
            bool fail = true;
            string input;
            do
            {
                AddToMessageLog($"{prompt}: ");
                input = Console.ReadLine()!.Trim();
                if (string.IsNullOrWhiteSpace(input))
                    AddToMessageLog($"You have to supply a valid {prompt.ToLower()}");
                else
                    fail = false;
            } while (fail);
            return input;
        }

        /// <summary>
        /// Asks the User for a Int as Input.
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        public int AskForInt(string prompt)
        {
            do
            {
                string given = AskForString(prompt);
                if (int.TryParse(given, out int result))
                    return result;
            } while (true);
        }

        /// <summary>
        /// Clears the menu half of the console.
        /// </summary>
        public void Clear()
        {
            string blanker = new string(' ', HalfWay - 1);
            ResetPosition();
            for (int i = 0; i < Height; i++)
            {
                WriteLine(blanker);
            }
            ResetPosition();
        }

        /// <summary>
        /// Applies desired settings based on the UI class functionality.
        /// </summary>
        public void Initialize()
        {
            Console.CursorVisible = false;
            PrintMessageLog();
        }

        /// <summary>
        /// Returns the position of the cursor to the top left corner.
        /// </summary>
        public void ResetPosition()
        {
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Changes the console window color settings for providing a highlight to the currently marked option.
        /// </summary>
        public void MenuHighlight()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Returns the console window color settings to default (grey text on black background).
        /// </summary>
        public void MenuNotSelected()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Prints a menu based on which choice should be the currently marked one and based on the List<string> taken as input.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="menu"></param>
        public void PrintMenu(int choice, List<string> menu)
        {
            ResetPosition();
            for (int i = 1; i < menu.Count + 1; i++)
            {
                if (i == choice)
                {
                    MenuHighlight();
                    WriteLine(menu[i - 1]);
                    MenuNotSelected();
                }
                else
                {
                    WriteLine(menu[i - 1]);
                }
            }
        }

        /// <summary>
        /// Moves the highlighted marker for the menu based on input and returns which option was chosen.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int Menu(int choice, List<string> menu)
        {
            bool notChosen = true;
            Clear();
            AddToMessageLog("Use the up & down arrow keys & enter, esc for menu.");
            do
            {
                PrintMenu(choice, menu);
                ConsoleKey keyPress = ReadKey();
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
                    case ConsoleKey.Escape:
                        Manager.MainMenu();
                        break;
                }
                if (choice == 0)
                    choice = menu.Count;
                if (choice == menu.Count + 1)
                    choice = 1;
            } while (notChosen);

            return choice;
        }

        /// <summary>
        /// Moves the highlighted marker for the menu based on input and returns which option was chosen. Can handle multiple pages.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        public int MenuPaged(int choice, List<string> menu)
        {
            bool notChosen = true;
            int max = Height - 1;
            int currentPage = 1;
            int pages = (menu.Count / max) + 1;
            int lastPage = menu.Count % max;
            if (lastPage == 0)
            {
                lastPage = max;
                pages--;
            }
            Clear();
            AddToMessageLog("Choose an option using the up & down arrow keys & enter:");
            AddToMessageLog($"Page {currentPage} of {pages}.");
            do
            {
                if (currentPage == pages)
                    PrintMenu(choice, menu.GetRange((currentPage - 1) * max, lastPage));
                else
                    PrintMenu(choice, menu.GetRange((currentPage - 1) * max, max));
                ConsoleKey keyPress = ReadKey();
                switch (keyPress)
                {
                    case ConsoleKey.UpArrow:
                        choice--;
                        if (choice == 0)
                        {
                            if (currentPage == 1)
                            {
                                currentPage = pages;
                                choice = lastPage;
                            }
                            else
                            {
                                choice = max;
                                currentPage--;
                            }
                            AddToMessageLog($"Page {currentPage} of {pages}.");
                            Clear();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        choice++;
                        if (currentPage == pages && choice == lastPage + 1)
                        {
                            choice = 1;
                            currentPage = 1;
                            AddToMessageLog($"Page {currentPage} of {pages}.");
                            Clear();
                        }
                        if (choice == max + 1)
                        {
                            choice = 1;
                            currentPage++;
                            AddToMessageLog($"Page {currentPage} of {pages}.");
                            Clear();
                        }
                        break;
                    case ConsoleKey.Enter:
                        notChosen = false;
                        break;
                    case ConsoleKey.Escape:
                        Manager.MainMenu();
                        break;
                }
            } while (notChosen);
            return ((currentPage - 1) * Height) + choice - 1;
        }

        /// <summary>
        /// Prints the message log in the message half of the console.
        /// </summary>
        public void PrintMessageLog()
        {
            PrintDivider();
            int i = 0;
            foreach (string message in _messageLog)
            {
                Console.SetCursorPosition(HalfWay + 2, i);
                WriteLine(message + new string(' ', HalfWay - message.Length - 2));
                i++;
            }
            Clear();
        }

        /// <summary>
        /// Prints the divider that segments the console in two halves.
        /// </summary>
        private void PrintDivider()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(HalfWay, i);
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Adds a message to the message log and then reprints the log.
        /// </summary>
        /// <param name="message"></param>
        public void AddToMessageLog(string message)
        {
            _messageLog.Add(message);
            PrintMessageLog();
        }

        /// <summary>
        /// Exits the application gracefully.
        /// </summary>
        public void Quit()
        {
            System.Environment.Exit(0);
        }
    }
}
