using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class Tui
    {
        // quando faccio la lista monstrare indice 
        // creare funzione che cancelli l'elemento
        // search data una una str mi da una lista di tittu elementi che contenga parte della stringa
        // creare una clase chiamata JsonStorage che implementa IStorage

        private ILogic _logic;
        private string[] Options = { "Add Beer", "Add Wine", "list Beverages", "Remove Beverage" };
        private bool ShowErrorMessage = false;

        public Tui(ILogic logic)
        {
            _logic = logic;
        }

        public void Start()
        {
            GreetUser();
            while (true)
            {
                GiveUserOptions();
                if (ShowErrorMessage) WriteErrorMessage();
                string userInput = Console.ReadLine() ?? "";
                Console.WriteLine($"User input is: {userInput}");

                ShowErrorMessage = IsValidInput(userInput);
                if (ShowErrorMessage) continue;
                if (userInput.ToLower() == "q") break;
                ProcessUserInput(userInput);


            }

        }

        private void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to the Cellar Managaer\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void GiveUserOptions()
        {
            Console.WriteLine("Please choose one of the fallowing options (write the numer)");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Options[i]}");
            }
            Console.WriteLine("\nOr type \"q\" to shutdown application ...");
        }

        private void WriteErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please provide a valid option");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool IsValidInput(string input) => (input.Length > 0) && string.IsNullOrEmpty(input);

        private void ProcessUserInput(string input)
        {
            Console.WriteLine(input);
            switch (input)
            {
                case "1":
                    HandleBeerAddition();
                    break;
                case "2":
                    HandleWineAddition();
                    break;
            }
        }

        public void ShowAllBeverages()
        {
            Console.WriteLine("Please choose one of the fallowing options (write the numer)");
            var beverages = _logic.GetAllBeverages();
            for (int i = 0; i < beverages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {beverages[i].Name}");
            }
        }


        public void HandleBeerAddition()
        {
            Console.WriteLine("Please write the name of the beer");
            string beerName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please write the alcohol degree");
            double beerDegree = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please write the type of the beer (Lager, Ale, Stout, IPA)");
            string beerType = Enum.TryParse<BeerType>(Console.ReadLine() ?? "Pilsner", out BeerType type) ? type.ToString() : "Pilsner";
            Console.WriteLine("Please write the year of the beer");
            string beerYear = Console.ReadLine();
            int.TryParse(beerYear, out int y);
        }

        public void HandleWineAddition()
        {
            Console.WriteLine("Please write the name of the wine");
            string wineName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please write the alcohol degree");
            double wineDegree = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please write the type of the wine (Red, White, Rose)");
            string wineType = Enum.TryParse<WineType>(Console.ReadLine() ?? "Red", out WineType type) ? type.ToString() : "Red";
            Console.WriteLine("Please write the year of the wine");
            string wineYear = Console.ReadLine();
            int.TryParse(wineYear, out int y);
        }

        public void CreateDummyDate()
        {
            var beer1 = new Beer()
            {
                Name = "Beer1",
                AlcoholDegree = 5.0,
                Type = BeerType.Lager,
                Country = "Germany",
                IBU = 20,
                Year = 2020
            };
            var beer2 = new Beer()
            {
                Name = "Beer2",
                AlcoholDegree = 6.0,
                Type = BeerType.Ale,
                Country = "Belgium",
                IBU = 30,
                Year = 2021
            };

            var wine1 = new Wine()
            {
                Name = "Wine1",
                AlcoholDegree = 12.0,
                Type = WineType.Red,
                Country = "France",
                Grape = "Merlot",
                Year = 2019
            };
            var wine2 = new Wine()
            {
                Name = "Wine2",
                AlcoholDegree = 13.0,
                Type = WineType.White,
                Country = "Italy",
                Grape = "Pinot Grigio",
                Year = 2020
            };
        }
    }

    class Animal

    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
        }
        public void Speak()
        {
            Console.WriteLine($"{Name} says hello!");
        }
    }
}
