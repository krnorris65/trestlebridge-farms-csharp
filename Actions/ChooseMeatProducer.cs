using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using System.Linq;

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

            int facilityIndex = Int32.Parse(Console.ReadLine()) - 1;

            var facilityChoosen = meatFacilities[facilityIndex];
            Console.Clear();
            Console.WriteLine("Select an animal to process:");

            List<IMeatProducing> availableResourcesList = new List<IMeatProducing>();

            foreach (var resource in facilityChoosen.Resources)
            {
                if (resource is IMeatProducing)
                {
                    availableResourcesList.Add(resource);
                }
            }

            List<ResourceType> animalTypeTotals = (from animal in availableResourcesList
                    group animal by animal.GetType().Name into animalType
                    select new ResourceType { Type = animalType.Key, Total = animalType.Count() }).ToList();

            int rNum = 1;
            foreach(var animalType in animalTypeTotals)
            {
                Console.WriteLine($"{rNum}. {animalType.Total} {animalType.Type}s");
                rNum++;
            }
            Console.Write(">");

            int animalTypeIndex = Int32.Parse(Console.ReadLine()) - 1;

            var animalTypeChoosen = animalTypeTotals[animalTypeIndex];
            // Console.Clear();
            Console.WriteLine($"How many {animalTypeChoosen.Type}s do you want to process?");
            Console.ReadLine();



        }
    }
}