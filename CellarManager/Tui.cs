using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager
{
    internal class Tui
    {
        private ILogic _logic;
        private bool Shutdown = false;
        private string[] Options = { "Add Beer", "Add Wine" };
        private bool ShowErrorMessage = false;

        public Tui(ILogic logic) 
        {
            _logic = logic;
        }

        public void Start()
        {
            string[] options = { "Add Beer", "Add Wine" };
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
            Console.ForegroundColor= ConsoleColor.White;
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
            switch(input)
            {
                case "1":
                    Console.WriteLine("user input is 1");
                    break;
                case "2": Console.WriteLine("user input is 2");
                    break;
            }
        }

        public void HandleBeerAddition()
        {
            Console.WriteLine("Please write the name of the beer");
            string beerName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please write the alcohol degree"); 

            string beerDegree = Console.ReadLine() ?? string.Empty;
            double.TryParse(beerDegree, out double parsedDegrees);

            Console.WriteLine("Please write the beer Style");
            string beerStyle = Console.ReadLine() ?? string.Empty;
            _logic.AddBeer(beerName, parsedDegrees, beerStyle);
        }
    }
}
