using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class BusinessLogic: ILogic
    {
        private IStorage _storage;
        public List<Beverage> Beverages { get; set; }

        public BusinessLogic(IStorage storage) 
        {
            _storage = storage;
            Beverages = _storage.LoadBeverages();
        }

        public void AddBeer(string name, double degree, BeerType type, string? country, int? IBU, int? year)
        {
            Beer beer = new() { Name = name, AlcoholDegree = degree,  Type= type};
            if (country != null) beer.Country= country;
            if (IBU != null) beer.IBU = IBU;
            if (year != null) beer.Year = year;
            Beverages.Add(beer);
            _storage.SaveAllBeverages(Beverages);
        }

        public void AddWine(string name, double degree, WineType type, string? country, string? grape, int? year)
        {
            Wine wine = new() { Name = name, AlcoholDegree = degree, Type = type };
            if (country != null) wine.Country = country;
            if (grape != null) wine.Grape = grape;
            if (year != null) wine.Year = year;
            Beverages.Add(wine);
            _storage.SaveAllBeverages(Beverages);
        }


        public void RemoveBeverage(int index)
        {
            Beverages.RemoveAt(index);
            _storage.SaveAllBeverages(Beverages);
        }

        public List<Beverage> GetAllBeverages() => Beverages;

        public List<Beverage> FilterBeverageByName(string name)
        {
            List<Beverage> filteredBeverages = [];
            foreach (var beverage in Beverages)
            {
                if (beverage.Name.ToLower().Contains(name.ToLower()))
                {
                    filteredBeverages.Add(beverage);
                }
            }
            return filteredBeverages;
        }

        public void RemoveBeverage(Beverage beverage)
        {
            throw new NotImplementedException();
        }
    }
}
