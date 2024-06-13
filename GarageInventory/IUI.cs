﻿
namespace GarageInventory
{
    public interface IUI
    {
        int AskForInt(string prompt);
        string AskForString(string prompt);
        ConsoleKeyInfo ReadKey();
        string ReadLine();
        void Write(string message);
        void WriteLine(string message);
    }
}