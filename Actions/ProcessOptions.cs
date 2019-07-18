using System;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ProcessOptions
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Seed Harvester");
            Console.WriteLine("2. Meat Processor");
            Console.WriteLine("3. Egg Gatherer");
            Console.WriteLine("4. Composter");
            Console.WriteLine("5. Feather Harvester");

            Console.WriteLine();
            Console.WriteLine("Choose equipment to use.");

            Console.Write("> ");
            string input = Console.ReadLine();
            try
            {

                switch (Int32.Parse(input))
                {
                    case 1:
                        //seeds
                        break;
                    case 2:
                        //meat
                        ChooseMeatProducer.CollectInput(farm);
                        break;
                    case 3:
                        //egg
                        break;
                    case 4:
                        //compost
                        break;
                    case 5:
                        //feather
                        break;
                    default:
                        break;
                }
            }
            catch (Exception) { }
        }
    }
}