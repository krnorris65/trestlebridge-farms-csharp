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

            //if user selection is valid then they return to main menu after animal is added to the facility
            //if the user makes and invalid selection they can return to the menu to select a facility or return to the main menu
            bool stayOnMenu = true;
            switch (Int32.Parse(choice))
            {
                case 1:
                    ChooseChickenHouse.CollectInput(farm, new Chicken());
                    break;
                case 2:
                    do{
                        stayOnMenu = ChooseGrazingField.CollectInput(farm, new Cow());
                    }while(stayOnMenu);
                    break;
                case 3:
                    ChooseDuckHouse.CollectInput(farm, new Duck());
                    break;
                case 4:
                    do{
                        stayOnMenu = ChooseGrazingField.CollectInput(farm, new Goat());
                    }while(stayOnMenu);
                    break;
                case 5:
                    do{
                        stayOnMenu = ChooseGrazingField.CollectInput(farm, new Ostrich());
                    }while(stayOnMenu);
                    break;
                case 6:
                    do{
                        stayOnMenu = ChooseGrazingField.CollectInput(farm, new Pig());
                    }while(stayOnMenu);
                    break;
                case 7:
                    do{
                        stayOnMenu = ChooseGrazingField.CollectInput(farm, new Sheep());
                    }while(stayOnMenu);
                    break;
                default:
                    break;
            }
        }
    }
}