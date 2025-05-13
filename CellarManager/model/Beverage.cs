using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Beverage
    {
        private string _country;
        public required string Name { get; set; }
        public string Country {
            get => _country ?? "Unknown";
            set {
                //string.IsNullOrEmpty
            }
        }
        

        public required double  AlcoholDegree { get; set; }
        public int? Year { get; set; }

        public virtual string ToCsvString()
        {
            return $"{Name}, {AlcoholDegree}, {Country}, {Year}";
        }

    }
}
