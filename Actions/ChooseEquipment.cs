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
    public class ChooseEquipment
    {
        private static List<IResource> _discardList { get; } = new List<IResource>();
        public static void CollectInput(Farm farm, List<Facility> facilityList, IEquipment equipment)
        {
            //grazing field, chicken house
            bool readyToProcess = false;

            do
            {
                Console.Clear();
                if(ChooseEquipment._discardList.Count >= equipment.Capacity){
                    Console.WriteLine("You have reached the maximum number that can be processed at one time");
                    Console.WriteLine("Press any key to process resources");
                    Console.ReadLine();
                    readyToProcess = true;
                }
                else
                {

                    Console.Clear();

                    Console.WriteLine($"The {equipment.Name} can process {equipment.Capacity} resources at one time.");
                    Console.WriteLine($"You have currently selected {ChooseEquipment._discardList.Count} resources to process.");
                    Console.WriteLine();

                    for (var i = 0; i < facilityList.Count; i++)
                    {
                        var currentFacility = facilityList[i];
                        Console.WriteLine($"{i + 1}. {currentFacility.Type} ({currentFacility.Total} {currentFacility.Category})");
                    }
                    
                    Console.WriteLine("Choose facility to process animals from.");

                    Console.Write("> ");

                    int facilityIndex = Int32.Parse(Console.ReadLine()) - 1;

                    var facilityChoosen = facilityList[facilityIndex];
                    Console.Clear();


                    //add only resources that the equipment can process and that have not already been selected to discard to availableResourcesList
                    List<IResource> availableResourcesList = equipment.GetEquipmentResources(facilityChoosen.Resources).Where(resource => !ChooseEquipment._discardList.Contains(resource)).ToList();

                    if(availableResourcesList.Count == 0){
                        Console.WriteLine("This facility does not have any animals that can be processed");
                        Console.ReadLine();
                    }
                    else{
                        var animalTypeChoosen = ChooseEquipment.ShowAnimals(availableResourcesList);
                        readyToProcess = ChooseEquipment.SelectAnimalsToProcess(availableResourcesList, animalTypeChoosen);
                    }
                    }
            }
            while(!readyToProcess);
            
            ChooseEquipment._discardList.ForEach(animal => {

                Facility animalFacility = facilityList.Find(facility => facility.Resources.Contains(animal));
                animalFacility.Resources.Remove(animal);

                equipment.ResourcesProcessed.Add(animal);
            });
            equipment.ProcessResources();
            Console.ReadLine();
        }
        private static ResourceType ShowAnimals(List<IResource> availableResourcesList)
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

        private static bool SelectAnimalsToProcess(List<IResource> availableResourcesList, ResourceType animalType)
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
                if((ChooseEquipment._discardList.Count + processThese.Count) > 7 ){
                    Console.WriteLine("You have exceeded the maximum number of animals that this processor can handle");
                    Console.WriteLine("Press enter to return to list of facilities");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    ChooseEquipment._discardList.AddRange(processThese);
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