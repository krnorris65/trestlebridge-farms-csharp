using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static bool CollectInput(Farm farm, Chicken chicken)
        {
            Console.Clear();

            //gets only the houses that are not full
            var houseWithCapacity = farm.ChickenHouses.Where(house => !house.HouseFull).ToList();

            //allows users to only select houses that have the capacity to add a chicken
            for (int i = 0; i < houseWithCapacity.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Chicken House");
            }

            Console.WriteLine();

            Console.WriteLine($"Place the chicken where?");

            Console.Write("> ");

            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int choiceIndex = choice - 1;
                //gets the house that was selected by the user
                ChickenHouse selectedHouse = houseWithCapacity[choiceIndex];
                //finds the house in the ChickenHouses list on the farm instance using the houseId
                ChickenHouse chickenHouse = farm.ChickenHouses.Find(field => field.HouseId == selectedHouse.HouseId);
                //adds chicken to the Chicken House on the farm
                chickenHouse.AddResource(chicken);
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