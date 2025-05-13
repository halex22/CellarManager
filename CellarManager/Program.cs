namespace CellarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CsvStorage storage = new();
            BusinessLogic logic = new(storage);
            Tui tui = new(logic);

            tui.Start();
            
        }
    }
}
