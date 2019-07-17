using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static bool CollectInput(Farm farm, ICompostProducing plant)
        {
            Console.Clear();

            //gets only the fields that are not full
            var fieldWithCapacity = farm.NaturalFields.Where(field => !field.FieldFull).ToList();

            Console.WriteLine("Available Natural Fields:");
            Console.WriteLine("");
            //allows users to only select fields that have the capacity to add plants
            for (int i = 0; i < fieldWithCapacity.Count; i++)
            {
                NaturalField currentField = fieldWithCapacity[i];
                Console.WriteLine($"{i + 1}. Natural Field");

                
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
                NaturalField selectedField = fieldWithCapacity[choiceIndex];
                //finds the field in the NaturalFields list on the farm instance using the FieldId
                NaturalField naturalField = farm.NaturalFields.Find(field => field.FieldId == selectedField.FieldId);
                //adds plant to the Natural Field on the farm
                naturalField.AddResource(plant);
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