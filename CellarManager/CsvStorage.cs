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
            throw new NotImplementedException();
        }
    }
}
