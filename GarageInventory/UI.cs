namespace GarageInventory
{
    public class UI : IUI
    {
        public void Write(string message) { Console.Write(message); }
        public void WriteLine(string message) { Console.WriteLine(message); }
        public ConsoleKey ReadKey() => Console.ReadKey(intercept: true).Key;
        public int Height => Console.WindowHeight;

        public string ReadLine()
        {
            string input;
            do
            {
                input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input a valid option.");                             //ToDo: Message log.
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
                Console.WriteLine($"{prompt}: ");
                input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine($"You have to supply a valid {prompt.ToLower()}");    //ToDo: Message log.
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
            Console.Clear();
            PrintMessageLog();
        }

        /// <summary>
        /// Applies desired settings based on the UI class functionality.
        /// </summary>
        public void Initialize()
        {
            Console.CursorVisible = false;
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
        /// Prints the current page number in a multi page view in the bottom left corner then returns the cursor to the top left corner.
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pages"></param>
        public void PrintPageCount(int currentPage, int pages)
        {
            int max = Height;
            Console.SetCursorPosition(0, max - 1);
            Console.Write($"Page {currentPage} of {pages}.");                                   //ToDo: Message log.
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Prints a menu based on which choice should be the currently marked one and based on the List<string> taken as input.
        /// </summary>
        /// <param name="choice"></param>
        /// <param name="menu"></param>
        public void PrintMenu(int choice, List<string> menu)
        {
            ResetPosition();
            WriteLine("Please choose an option using the up and down arrow keys and enter, or press 'Esc' to exit: ");      //ToDo: Implement going back with Esc.
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
                }
                if (choice == 0)
                    choice = menu.Count;
                if (choice == menu.Count + 1)
                    choice = 1;
            } while (notChosen);

            return choice;
        }

        /// <summary>
        /// Prints the message log in the message half of the console.
        /// </summary>
        public void PrintMessageLog()
        {
            //Todo: Implement!
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
