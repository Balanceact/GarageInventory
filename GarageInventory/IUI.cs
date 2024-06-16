namespace GarageInventory
{
    public interface IUI
    {
        int Height { get; }
        int Width { get; }

        void AddToMessageLog(string message);
        bool AskForBool(List<string> menu);
        int AskForInt(string prompt);
        string AskForString(string prompt);
        void Clear();
        void Initialize();
        int Menu(int choice, List<string> menu);
        void MenuHighlight();
        void MenuNotSelected();
        void PrintMenu(int choice, List<string> menu);
        void PrintMessageLog();
        void Quit();
        ConsoleKey ReadKey();
        string ReadLine();
        void ResetPosition();
        void Write(string message);
        void WriteLine(string message);
    }
}