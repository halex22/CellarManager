using CellarManager.Storages;

namespace CellarManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Allievo\Desktop\Hugo\CellarManager\CellarManager\db";
            //CsvStorage storage = new() { FilePath = path};
            JsonStorage storage = new() { FilePath = path };
            BusinessLogic logic = new(storage);
            Tui tui = new(logic);

            tui.Start();
            
        }
    }
}
