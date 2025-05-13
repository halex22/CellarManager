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
            //_storage.SaveBeverages(Beverages);
        }

        public void AddWine(string name, double degree, WineType type, string? country, string? grape, int? year)
        {
            Wine wine = new() { Name = name, AlcoholDegree = degree, Type = type };
            if (country != null) wine.Country = country;
            if (grape != null) wine.Grape = grape;
            if (year != null) wine.Year = year;
            Beverages.Add(wine);

        }


        public void RemoveBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public void RemoveWine(Wine wine)
        {
            throw new NotImplementedException();
        }

        public List<Beverage> GetAllBeverages()
        {
            throw new NotImplementedException();
        }

        public List<Beverage> FilterBeverageByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveBeverage(Beverage beverage)
        {
            throw new NotImplementedException();
        }
    }
}
