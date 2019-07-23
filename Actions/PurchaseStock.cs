using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class PurchaseStock
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Chicken");
            Console.WriteLine("2. Cow");
            Console.WriteLine("3. Duck");
            Console.WriteLine("4. Goat");
            Console.WriteLine("5. Ostrich");
            Console.WriteLine("6. Pig");
            Console.WriteLine("7. Sheep");

            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");
            string choice = Console.ReadLine();

            //if user selection is valid then they return to main menu after animal is added to the facility
            //if the user makes and invalid selection they can return to the menu to select a facility or return to the main menu
            try
            {
                bool stayOnMenu = true;
                switch (Int32.Parse(choice))
                {
                    case 1:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Chicken(), farm.ChickenHouses);
                        }
                        while (stayOnMenu);
                        break;
                    case 2:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Cow(), farm.GrazingFields);
                        }
                        while (stayOnMenu);
                        break;
                    case 3:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Duck(), farm.DuckHouses);
                        }
                        while (stayOnMenu);
                        break;
                    case 4:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Goat(), farm.GrazingFields);
                        }
                        while (stayOnMenu);
                        break;
                    case 5:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Ostrich(), farm.GrazingFields);
                        }
                        while (stayOnMenu);
                        break;
                    case 6:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Pig(), farm.GrazingFields);
                        }
                        while (stayOnMenu);
                        break;
                    case 7:
                        do
                        {
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Sheep(), farm.GrazingFields);
                        }
                        while (stayOnMenu);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception) { }
        }
    }
}