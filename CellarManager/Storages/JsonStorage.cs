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
        public required string FilePath { get; set; }
        public List<Beverage> LoadBeverages()
        {
            string path = Path.Combine(FilePath, "beverages.json");
            if (!File.Exists(path)) return [];
            string json = File.ReadAllText(path);
            Console.WriteLine(json);
            var parsedInfo = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json) ?? [];
            if (parsedInfo.Count == 0) return [];
            List<Beverage> beverages = [];

            foreach (var item in parsedInfo)
            {
                string beverageType = item["class"];
                if (beverageType == "Beer")
                {
                    Beer beer = new()
                    {
                        Name = item["name"],
                        AlcoholDegree = double.Parse(item["degree"]),
                        Country = item["country"],
                        Year = int.Parse(item["year"]),
                        Type = Enum.TryParse(item["type"], out BeerType type) ? type : BeerType.Lager,
                        IBU = int.TryParse(item["IBU"], out int ibu) ? ibu : null
                    };
                    beverages.Add(beer);
                }
                else if (beverageType == "Wine")
                {
                    Wine wine = new()
                    {
                        Name = item["name"],
                        AlcoholDegree = double.Parse(item["degree"]),
                        Country = item["country"],
                        Year = int.Parse(item["year"]),
                        Type = Enum.TryParse(item["type"], out WineType type) ? type : WineType.Red,
                        Grape = item["grape"]
                    };
                    beverages.Add(wine);
                }
                
            }
            return  beverages;
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
            string path = Path.Combine(FilePath, "beverages.json");
            File.WriteAllText(path, stringifyList);
        }
    }
}
