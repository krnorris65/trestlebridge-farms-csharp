using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalOrPlowedField
    {
        public static bool CollectInput(Farm farm, Sunflower plant)
        {
            Console.Clear();

            //gets only the fields that are not full
            var plowedFieldWithCapacity = farm.PlowedFields.Where(field => !field.FieldFull).ToList();
            var naturalFieldWithCapacity = farm.NaturalFields.Where(field => !field.FieldFull).ToList();

            Console.WriteLine("Available Plowed & Natural Fields:");
            //allows users to only select fields that have the capacity to add plants
            int plantNum = 0;
            for (int i = 0; i < plowedFieldWithCapacity.Count; i++)
            {
                PlowedField currentField = plowedFieldWithCapacity[i];
                Console.WriteLine($"{plantNum + 1}. Plowed Field");
                plantNum++;
            }

            for (int i = 0; i < naturalFieldWithCapacity.Count; i++)
            {
                NaturalField currentField = naturalFieldWithCapacity[i];
                Console.WriteLine($"{plantNum + 1}. Natural Field");
                plantNum++;
            }

            Console.WriteLine();

            Console.WriteLine($"Plant seeds where?");

            Console.Write("> ");


            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int plowedIndex = choice - 1;
                int naturalIndex = plowedIndex - plowedFieldWithCapacity.Count;
                //if the user selected a plowed field the choice would be equal to or less than the count of the plowedFieldWithCapacity
                if (choice < plowedFieldWithCapacity.Count || choice == plowedFieldWithCapacity.Count)
                {
                    //gets the field that was selected by the user
                    PlowedField selectedField = plowedFieldWithCapacity[plowedIndex];
                    // //finds the field in the PlowedFields list on the farm instance using the FieldId
                    PlowedField plowedField = farm.PlowedFields.Find(field => field.FieldId == selectedField.FieldId);
                    // //adds plant to the Plowed Field on the farm
                    plowedField.AddResource(plant);
                }
                //if a user selected a natural field the choice would be greater than the count of the plowedFieldWithCapacity
                else
                {
                    NaturalField selectedField = naturalFieldWithCapacity[naturalIndex];
                    //finds the field in the NaturalFields list on the farm instance using the FieldId
                    NaturalField naturalField = farm.NaturalFields.Find(field => field.FieldId == selectedField.FieldId);
                    //adds plant to the Natural Field on the farm
                    naturalField.AddResource(plant);
                }

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