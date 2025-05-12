namespace CellarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // instace TUI
            // var tui = new TUI();
            CsvStorage storage = new();
            BusinessLogic logic = new(storage);
            Tui tui = new(logic);
        }
    }
}
