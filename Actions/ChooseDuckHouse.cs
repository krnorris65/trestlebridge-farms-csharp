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
        public static void CollectInput(Farm farm, Duck duck)
        {
            Console.Clear();

            //gets only the houses that are not full
            var houseWithCapacity = farm.DuckHouses.Where(house => !house.HouseFull).ToList();

            //allows users to only select houses that have the capacity to add a duck
            for (int i = 0; i < houseWithCapacity.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Duck House");
            }

            Console.WriteLine();

            Console.WriteLine($"Place the duck where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            //index of list starts at 0, so the index will always be one less than the value the user selects
            int choiceIndex = choice - 1;

            try
            {
                //gets the house that was selected by the user
                DuckHouse selectedHouse = houseWithCapacity[choiceIndex];
                //finds the house in the DuckHouses list on the farm instance using the houseId
                DuckHouse duckHouse = farm.DuckHouses.Find(field => field.HouseId == selectedHouse.HouseId);
                //adds duck to the Duck House on the farm
                duckHouse.AddResource(duck);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Selection");
                Console.ReadLine();
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<Chicken>(animal, choice);

        }

    }
}