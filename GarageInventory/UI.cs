using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    public class UI
    {
        public static void Write(string message)
        {
            Console.Write(message);
        }
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public static string ReadLine()
        {
            string input;
            do
            {
                input = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(input))
                {
                    UI.WriteLine("Input a valid option.");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }
        public static ConsoleKeyInfo ReadKey() => Console.ReadKey(true);

        public static string AskForString(string prompt)
        {
            bool fail = true;
            string given;
            do
            {
                UI.WriteLine($"{prompt}: ");
                given = UI.ReadLine()!;
                if (string.IsNullOrWhiteSpace(given))
                {
                    UI.WriteLine($"You have to supply a valid {prompt}");
                }
                else
                {
                    fail = false;
                }
            } while (fail);
            return given;
        }

        public static int AskForInt(string prompt)
        {
            do
            {
                string given = AskForString(prompt);
                if (int.TryParse(given, out int result))
                {
                    return result;
                }
            } while (true);
        }

    }
}
