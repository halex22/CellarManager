using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager.Interfaces
{
    internal interface ILogic
    {
        public List<Beverage> Beverages { get; set; }
        public void AddBeer(string name, double degree, BeerType type, string? country, int? IBU, int? year);
        public void AddWine(string name, double degree, WineType type, string? country, string? grape, int? year);
        public List<Beverage> GetAllBeverages();
        public List<Beverage> FilterBeverageByName(string name);
        public void RemoveBeverage(int index);
    }
}
