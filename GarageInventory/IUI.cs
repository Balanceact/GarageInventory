
namespace GarageInventory
{
    public interface IUI
    {
        int AskForInt(string prompt);
        string AskForString(string prompt);
        void MenuHighlight();
        void MenuNotSelected();
        ConsoleKey ReadKey();
        string ReadLine();
        void ResetPosition();
        void Write(string message);
        void WriteLine(string message);
    }
}