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
            if (!File.Exists("beverages.csv"))
            {
                File.Create("beverages.csv").Close();
                return new List<Beverage>();
            }
            string[] rowBeverage = File.ReadAllLines("beverages.csv");
            List<Beverage> beverages = new();
            for (int i = 1; i < rowBeverage.Length; i++)
            {
                string[] row = rowBeverage[i].Split(',');
                if (row[0] == "Beer")
                {
                    Beer beer = new()
                    {
                        Name = row[1],
                        AlcoholDegree = double.Parse(row[2]),
                        Country = row[3],
                        Year = int.Parse(row[4]),
                        Type = Enum.TryParse<BeerType>(row[5], out BeerType type) ? type : BeerType.Lager,
                        IBU = int.TryParse(row[6], out int ibu) ? ibu : null
                    };
                    beverages.Add(beer);
                }
                else if (row[0] == "Wine")
                {
                    Wine wine = new()
                    {
                        Name = row[1],
                        AlcoholDegree = double.Parse(row[2]),
                        Country = row[3],
                        Year = int.Parse(row[4]),
                        Type = Enum.TryParse<WineType>(row[5], out WineType type) ? type : WineType.Red,
                        Grape = row[7]
                    };
                    beverages.Add(wine);
                }


            }
            return beverages;
        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            StringBuilder sb = new();
            sb.AppendLine("Class, Name, Degree, Country, Year, type, IBU, Grape");

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
