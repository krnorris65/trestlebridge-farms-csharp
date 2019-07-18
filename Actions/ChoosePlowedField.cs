using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedField
    {
        public static bool CollectInput(Farm farm, ISeedProducing plant)
        {
            Console.Clear();

            //gets only the fields that are not full
            var fieldWithCapacity = farm.PlowedFields.Where(field => !field.FieldFull).ToList();

            Console.WriteLine("Available Plowed Fields:");
            Console.WriteLine("");
            //allows users to only select fields that have the capacity to add plants
            for (int i = 0; i < fieldWithCapacity.Count; i++)
            {
                PlowedField currentField = fieldWithCapacity[i];
                Console.WriteLine($"{i + 1}. Plowed Field");


            }

            Console.WriteLine();

            Console.WriteLine($"Plant seeds where?");

            Console.Write("> ");


            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int choiceIndex = choice - 1;
                //gets the field that was selected by the user
                PlowedField selectedField = fieldWithCapacity[choiceIndex];
                //finds the field in the PlowedFields list on the farm instance using the FieldId
                PlowedField plowedField = farm.PlowedFields.Find(field => field.FieldId == selectedField.FieldId);
                //adds plant to the Plowed Field on the farm
                plowedField.AddResource(plant);
                Console.WriteLine("You added a plant to a plowed field!");
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadLine();
                //return false so the user returns to the main menu
                return false;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection.");
                Console.WriteLine("Please press enter to select another field or enter 0 to return to main menu");
                Console.Write("> ");

                //if user enters 0, they will be brought to the main menu, if they enter anything else they will be brought back to the field menu
                if (Console.ReadLine() == "0")
                {
                    //return false so the user returns to the main menu
                    return false;
                }
                else
                {
                    //return true so the user returns to the list of fields
                    return true;
                }

            }

        }

    }
}