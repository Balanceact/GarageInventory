﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Input a valid option.");
                }
            } while (string.IsNullOrWhiteSpace(input));
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
                    Console.WriteLine($"You have to supply a valid {prompt}");
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
        public void ResetPosition()
        {
            Console.SetCursorPosition(0, 0);
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
    }
}
