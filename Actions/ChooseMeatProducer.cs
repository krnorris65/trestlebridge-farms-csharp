using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using System.Linq;
using Trestlebridge.Models.Equipment;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseMeatProducer
    {
        public static List<IMeatProducing> AnimalsToDiscard { get; } = new List<IMeatProducing>();
        public static void CollectInput(Farm farm)
        {
            //grazing field, chicken house
            bool readyToProcess = false;
            List<dynamic> meatFacilities = new List<dynamic>();
            farm.GrazingFields.ForEach(field => meatFacilities.Add(field));
            farm.ChickenHouses.ForEach(house => meatFacilities.Add(house));

            do
            {
                Console.Clear();
                if(ChooseMeatProducer.AnimalsToDiscard.Count >= 7){
                    Console.WriteLine("You have reached the maximum number of animals that can be processed at one time");
                    Console.WriteLine("Press any key to process the animals");
                    Console.ReadLine();
                    readyToProcess = true;
                }
                else
                {

                    Console.Clear();

                    Console.WriteLine($"The Meat Processor can process {farm.MeatProcessor.Capacity} animals at one time.");
                    Console.WriteLine($"You have currently selected {ChooseMeatProducer.AnimalsToDiscard.Count} animals to process.");
                    Console.WriteLine();

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


                    //add only meat producing animals that have not already been selected to discard to availableResourcesList
                    foreach (var resource in facilityChoosen.Resources)
                    {
                        if (resource is IMeatProducing && !ChooseMeatProducer.AnimalsToDiscard.Contains(resource))
                        {
                            availableResourcesList.Add(resource);
                        }
                    }

                    if(availableResourcesList.Count == 0){
                        Console.WriteLine("This facility does not have any animals that can be processed");
                        Console.ReadLine();
                    }
                    else{
                        var animalTypeChoosen = ChooseMeatProducer.ShowAnimals(availableResourcesList);
                        readyToProcess = ChooseMeatProducer.SelectAnimalsToProcess(availableResourcesList, animalTypeChoosen);
                    }
                    }
            }
            while(!readyToProcess);
            
            ChooseMeatProducer.AnimalsToDiscard.ForEach(animal => {
                
                // if(animal.GetType().Name == "Chicken"){
                //     var chicken = (Chicken)animal;
                //     ChickenHouse chickenHouse = farm.ChickenHouses.Find(house => house.Resources.Contains(chicken));
                //     chickenHouse.Resources.Remove(chicken);
                // }
                // else{
                //     var grazingAnimal = (IGrazing)animal;
                //     GrazingField grazingField = farm.GrazingFields.Find(field => field.Resources.Contains(grazingAnimal));
                //     grazingField.Resources.Remove(grazingAnimal);
                // }
                    IResource processedAnimal = (IResource)animal;
                    List<IResource> meatResourceList = farm.MeatProcessor.Resources;
                    meatResourceList.Add(processedAnimal);
            });
            farm.MeatProcessor.ProcessResources();
            Console.ReadLine();
        }
        private static ResourceType ShowAnimals(List<IMeatProducing> availableResourcesList)
        {
            Console.Clear();
            List<ResourceType> animalTypeTotals = (from animal in availableResourcesList
                                                group animal by animal.GetType().Name into animalType
                                                select new ResourceType { Type = animalType.Key, Total = animalType.Count() }).ToList();

            int rNum = 1;

            if (animalTypeTotals[0].Type == "Chicken")
            {
                return animalTypeTotals[0];
            }
            else
            {
                Console.WriteLine("Select an animal to process:");
                foreach (var animalType in animalTypeTotals)
                {
                    Console.WriteLine($"{rNum}. {animalType.Total} {animalType.Type}s");
                    rNum++;
                }
                Console.Write(">");
                int animalTypeIndex = Int32.Parse(Console.ReadLine()) - 1;

                return animalTypeTotals[animalTypeIndex];
            }
        }

        private static bool SelectAnimalsToProcess(List<IMeatProducing> availableResourcesList, ResourceType animalType)
        {
            Console.WriteLine($"There are {animalType.Total} {animalType.Type}s. How many do you want to process?");
            Console.Write(">");
            int numSelected = Int32.Parse(Console.ReadLine());

            if (numSelected > animalType.Total)
            {
                Console.WriteLine($"There are not that many {animalType.Type}s available");
                    Console.WriteLine("Press enter to return to list of facilities");
                    Console.ReadLine();
                return false;
            }
            else
            {
                //find animals in availableResourcesList that match the type of animal that was selected and limit the number to the number of animals the user wants to process
                var processThese = (from animal in availableResourcesList
                                    where animal.GetType().Name == animalType.Type
                                    select animal
                    ).Take(numSelected).ToList();
                //add them to AnimalsToDicard
                if((ChooseMeatProducer.AnimalsToDiscard.Count + processThese.Count) > 7 ){
                    Console.WriteLine("You have exceeded the maximum number of animals that this processor can handle");
                    Console.WriteLine("Press enter to return to list of facilities");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    ChooseMeatProducer.AnimalsToDiscard.AddRange(processThese);
                    Console.WriteLine("Ready to process? (Y/n)");
                    var processYN = Console.ReadLine();
                    if (processYN.ToLower() == "y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
        }
    }
}