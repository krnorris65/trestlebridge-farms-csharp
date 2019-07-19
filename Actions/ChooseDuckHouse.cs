using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static bool CollectInput(Farm farm, Duck duck)
        {
            Console.Clear();

            //gets only the houses that are not full
            var houseWithCapacity = farm.DuckHouses.Where(house => house.TotalAnimals != house.Capacity).ToList();

            //allows users to only select houses that have the capacity to add a duck
            Console.WriteLine("Available Duck Houses:");
            Console.WriteLine("");
            
            for (int i = 0; i < houseWithCapacity.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Duck House ({houseWithCapacity[i].TotalAnimals} Ducks)");
            }

            Console.WriteLine();

            Console.WriteLine($"Place the duck where?");

            Console.Write("> ");

            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int choiceIndex = choice - 1;
                //gets the house that was selected by the user
                DuckHouse selectedHouse = houseWithCapacity[choiceIndex];
                //finds the house in the DuckHouses list on the farm instance using the houseId
                DuckHouse duckHouse = farm.DuckHouses.Find(field => field.HouseId == selectedHouse.HouseId);
                //adds duck to the Duck House on the farm
                duckHouse.AddResource(duck);
                //return false so the user returns to the main menu
                return false;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection.");
                Console.WriteLine("Please press enter to select another house or enter 0 to return to main menu");
                Console.Write("> ");

                //if user enters 0, they will be brought to the main menu, if they enter anything else they will be brought back to the facility menu
                if (Console.ReadLine() == "0")
                {
                    //return false so the user returns to the main menu
                    return false;
                }
                else
                {
                    //return true so the user returns to the list of facilities
                    return true;
                }
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<Chicken>(animal, choice);

        }

    }
}