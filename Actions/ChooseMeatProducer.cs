using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using System.Linq;

namespace Trestlebridge.Actions
{
    public class ChooseMeatProducer
    {
        public static List<IMeatProducing> AnimalsToDiscard { get; } = new List<IMeatProducing>();
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


            List<IMeatProducing> availableResourcesList = new List<IMeatProducing>();

            foreach (var resource in facilityChoosen.Resources)
            {
                if (resource is IMeatProducing)
                {
                    availableResourcesList.Add(resource);
                }
            }

            var animalTypeChoosen = ChooseMeatProducer.ShowAnimals(availableResourcesList);

            ChooseMeatProducer.SelectAnimals(availableResourcesList, animalTypeChoosen);

            Console.ReadLine();

        }
        private static ResourceType ShowAnimals(List<IMeatProducing> availableResourcesList)
        {
            Console.WriteLine("Select an animal to process:");

            List<ResourceType> animalTypeTotals = (from animal in availableResourcesList
                                                group animal by animal.GetType().Name into animalType
                                                select new ResourceType { Type = animalType.Key, Total = animalType.Count() }).ToList();

            int rNum = 1;
            foreach (var animalType in animalTypeTotals)
            {
                Console.WriteLine($"{rNum}. {animalType.Total} {animalType.Type}s");
                rNum++;
            }
            Console.Write(">");
            int animalTypeIndex = Int32.Parse(Console.ReadLine()) - 1;

            return animalTypeTotals[animalTypeIndex];
        }

        private static void SelectAnimals(List<IMeatProducing> availableResourcesList, ResourceType animalType)
        {
            Console.WriteLine($"How many {animalType.Type}s do you want to process?");
            int numSelected = Int32.Parse(Console.ReadLine());

            if (numSelected > animalType.Total)
            {
                Console.WriteLine($"There are not that many {animalType.Type}s");
            }
            else
            {
                //find animals in availableResourcesList that match the type of animal that was selected and limit the number to the number of animals the user wants to process
                var processThese = (from animal in availableResourcesList
                                    where animal.GetType().Name == animalType.Type
                                    select animal
                    ).Take(numSelected).ToList();
                //remove them from availableResourcesList
                availableResourcesList.RemoveAll(animal => processThese.Contains(animal));
                //add them to AnimalsToProcess
                ChooseMeatProducer.AnimalsToDiscard.AddRange(processThese);
                Console.WriteLine("Ready to process? (Y/n)");
                var processYN = Console.ReadLine();
                if (processYN.ToLower() == "y")
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }

            }
        }
    }
}