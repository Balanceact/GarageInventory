namespace GarageInventory
{
    public class UI : IUI
    {
        public void Write(string message) { Console.Write(message); }
        public void WriteLine(string message) { Console.WriteLine(message); }
        public ConsoleKey ReadKey() => Console.ReadKey(intercept: true).Key;

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

        public string AskForString(string prompt)
        {
            bool fail = true;
            string input;
            do {
                Console.WriteLine($"{prompt}: ");
                input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine($"You have to supply a valid {prompt.ToLower()}");    //ToDo: Message log.
                else
                    fail = false;
            } while (fail);
            return input;
        }

        public int AskForInt(string prompt)
        {
            do {
                string given = AskForString(prompt);
                if (int.TryParse(given, out int result))
                    return result;
            } while (true);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Initialize()
        {
            Console.CursorVisible = false;
        }

        public void ResetPosition()
        {
            Console.SetCursorPosition(0, 0);
        }

        public int Hight()
        {
            return Console.WindowHeight;
        }

        public void MenuHighlight()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MenuNotSelected()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPageCount(int currentPage, int pages)
        {
            int max = Hight();
            Console.SetCursorPosition(0, max - 1);
            Console.Write($"Page {currentPage} of {pages}.");                                   //ToDo: Message log.
            Console.SetCursorPosition(0, 0);
        }

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

        public void Quit()
        {
            System.Environment.Exit(0);
        }
    }
}
