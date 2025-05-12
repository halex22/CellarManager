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
        private IStorage _csvStorage;
        public List<Beverage> Beverages { get; set; }
        public BusinessLogic(IStorage storage) 
        {
            _csvStorage = storage;
            Beverages = _csvStorage.LoadBeverages();
        }

        public void AddBeer(string name, double degree, string style)
        {
            Beer beer = new() { Name = name, AlcoholDegree = degree };
            Beverages.Add(beer);
        }

        public void AddWine(Wine wine)
        {
            throw new NotImplementedException();
        }

        public List<Beverage> GetAllBeverages()
        {
            throw new NotImplementedException();
        }

        public void RemoveBeer(Beer beer)
        {
            throw new NotImplementedException();
        }

        public void RemoveWine(Wine wine)
        {
            throw new NotImplementedException();
        }
    }
}
