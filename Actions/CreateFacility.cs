using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class CreateFacility
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Grazing field");
            Console.WriteLine("2. Plowed field");
            Console.WriteLine("3. Chicken House");

            Console.WriteLine();
            Console.WriteLine("Choose what you want to create");

            Console.Write("> ");
            string input = Console.ReadLine();

            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddGrazingField(new GrazingField());
                    Console.WriteLine("You added a new grazing field!"); 
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadLine();
                    break;
                case 3:
                    farm.AddChickenHouse(new ChickenHouse());
                    Console.WriteLine("You added a new chicken house!"); 
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
}