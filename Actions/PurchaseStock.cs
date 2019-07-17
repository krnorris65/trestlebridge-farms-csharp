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

            bool repeat = true;
            switch (Int32.Parse(choice))
            {
                case 1:
                    ChooseChickenHouse.CollectInput(farm, new Chicken());
                    break;
                case 2:
                    do{
                        repeat = ChooseGrazingField.CollectInput(farm, new Cow());
                    }while(repeat);
                    break;
                case 3:
                    ChooseDuckHouse.CollectInput(farm, new Duck());
                    break;
                case 4:
                    do{
                        repeat = ChooseGrazingField.CollectInput(farm, new Goat());
                    }while(repeat);
                    break;
                case 5:
                    do{
                        repeat = ChooseGrazingField.CollectInput(farm, new Ostrich());
                    }while(repeat);
                    break;
                case 6:
                    do{
                        repeat = ChooseGrazingField.CollectInput(farm, new Pig());
                    }while(repeat);
                    break;
                case 7:
                    do{
                        repeat = ChooseGrazingField.CollectInput(farm, new Sheep());
                    }while(repeat);
                    break;
                default:
                    break;
            }
        }
    }
}