using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;
using System.Linq;

namespace Trestlebridge.Actions
{
    public class PurchaseSeed
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Sunflower");
            Console.WriteLine("2. Wildflower");
            Console.WriteLine("3. Sesame");

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
                            //either plowed or natural field
                            var plantList = farm.PlowedFields.Concat(farm.NaturalFields).ToList();
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Sunflower(), plantList);
                        }
                        while (stayOnMenu);
                        break;
                    case 2:
                        do
                        {
                            //natural field
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Wildflower(), farm.NaturalFields);
                        }
                        while (stayOnMenu);
                        break;
                    case 3:
                        do
                        {
                            //plowed field
                            stayOnMenu = ChooseFacility.CollectInput(farm, new Sesame(), farm.PlowedFields);
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