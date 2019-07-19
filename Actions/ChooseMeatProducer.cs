using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseMeatProducer
    {
        public static void CollectInput(Farm farm)
        {
            Console.Clear();
            //grazing field, chicken house
            List<dynamic> meatFacilities = new List<dynamic>();

            farm.GrazingFields.ForEach(field => meatFacilities.Add(field));
            farm.ChickenHouses.ForEach(house => meatFacilities.Add(house));

            for (var i = 0; i < meatFacilities.Count; i++)
            {
                var currentFacility = meatFacilities[i];
                var type = currentFacility.Name;
                Console.WriteLine($"{i + 1}. {currentFacility.Name} ({currentFacility.TotalAnimals} animals)");
            }

            Console.WriteLine("Choose facility to process animals from.");

            Console.Write("> ");
            var input = Console.ReadLine();

            int facilityIndex = Int32.Parse(input) - 1;

            var facilityChoosen = meatFacilities[facilityIndex];
            Console.Clear();
            Console.WriteLine("Select an animal to process:");

            Dictionary<string,int> availableResources = new Dictionary<string,int>();


            foreach (var resource in facilityChoosen.Resources)
            {
                if (resource is IMeatProducing)
                {
                    try{
                    availableResources.Add(resource.GetType().Name, 1);
                    }
                    catch(Exception)
                    {
                        availableResources[resource.GetType().Name] ++;
                    }
                }
            }

            int rNum = 1;
            foreach(KeyValuePair<string, int> type in availableResources)
            {
                Console.WriteLine($"{rNum}. {type.Value} {type.Key}s");
                    rNum++;
            }
            Console.Write(">");
            Console.ReadLine();

        }
    }
}