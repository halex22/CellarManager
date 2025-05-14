using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CellarManager.Interfaces;
using CellarManager.model;

namespace CellarManager.Storages
{
    internal class JsonStorage : IStorage
    {

        public List<Beverage> LoadBeverages()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "beverages.json");
            if (!File.Exists(path)) return [];
            string json = File.ReadAllText(path);

            return [];

        }

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            List<Dictionary<string, string>> beverageDictList = [];

            foreach (var beverage in beverages)
            {
                bool isBeer = beverage is Beer;
                var dict = new Dictionary<string, string>()
                {
                    {"class", isBeer ? "Beer" : "Wine"},
                    {"name", beverage.Name},
                    {"degree", beverage.AlcoholDegree.ToString()},
                    {"country", beverage.Country},
                    {"year", beverage.Year.ToString() ?? ""},
                };

                if (isBeer)
                {
                    var beer = (Beer)beverage;
                    dict.Add("IBU", beer.IBU.ToString() ?? "");
                    dict.Add("type", beer.Type.ToString());
                }
                else
                {
                    var wine = (Wine)beverage;
                    dict.Add("grape", wine.Grape ?? "");
                    dict.Add("type", wine.Type.ToString());
                }

                beverageDictList.Add(dict);

            }

            string stringifyList = JsonSerializer.Serialize(beverageDictList, new JsonSerializerOptions { WriteIndented =  true});
            string path = Path.Combine(Environment.CurrentDirectory, "beverages.json");
            File.WriteAllText(path, stringifyList);
        }
    }
}
