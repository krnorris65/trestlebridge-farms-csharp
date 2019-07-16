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
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Console.Clear();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Grazing Field");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());
            //index of list starts at 0, so the index will always be one less than the value the user selects
            int choiceIndex = choice - 1;

            GrazingField grazingField = farm.GrazingFields[choiceIndex];

            AddAnimalToField(farm, grazingField, animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
        public static void AddAnimalToField(Farm farm, GrazingField field, IGrazing animal){
            if (field.FieldFull)
            {
                Console.WriteLine("This field is full");
                Console.WriteLine("Press Enter to Select New field");
                Console.ReadLine();
                CollectInput(farm, animal);
            }
            else
            {
                field.AddResource(animal);
            }
        }
    }
}