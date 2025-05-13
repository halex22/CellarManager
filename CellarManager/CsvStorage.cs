using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class CsvStorage : IStorage
    {
        public List<Beverage> LoadBeverages()
        {
            return new List<Beverage>();
        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            StringBuilder sb = new();
            sb.AppendLine("name, degree, type");

            foreach (Beverage beverage in beverages)
            {
                sb.AppendLine(beverage.ToCsvString());
            }

            Console.WriteLine(sb.ToString());

            string path = Path.Combine(Environment.CurrentDirectory, "beverages.csv");
            File.WriteAllText(path, sb.ToString());
        }
    }
}
