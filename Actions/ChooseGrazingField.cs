using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static bool CollectInput(Farm farm, IGrazing animal)
        {
            Console.Clear();

            //gets only the fields that are not full
            var fieldWithCapacity = farm.GrazingFields.Where(field => field.TotalAnimals != field.Capacity).ToList();

            //allows users to only select fields that have the capacity to add an animal
            for (int i = 0; i < fieldWithCapacity.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Grazing Field (has {fieldWithCapacity[i].TotalAnimals} animals)");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");


            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int choiceIndex = choice - 1;
                //gets the field that was selected by the user
                GrazingField selectedField = fieldWithCapacity[choiceIndex];
                //finds the field in the GrazingFields list on the farm instance using the FieldId
                GrazingField grazingField = farm.GrazingFields.Find(field => field.FieldId == selectedField.FieldId);
                //adds animal to the Grazing Field on the farm
                grazingField.AddResource(animal);
                //return false so the user returns to the main menu
                return false;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection.");
                Console.WriteLine("Please press enter to select another field or enter 0 to return to main menu");
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
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }

    }
}