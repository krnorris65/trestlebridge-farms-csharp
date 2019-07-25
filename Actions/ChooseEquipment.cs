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
        private static List<IResource> _discardList = new List<IResource>();
        private static Facility selectedFacility;
        public static void CollectInput(List<Facility> facilityList, IEquipment equipment)
        {

            bool readyToProcess = false;
            List<Facility> availableFacilities = facilityList;

            do
            {
                Console.Clear();
                var resourceCount = ChooseEquipment._discardList.Count;
                var equipmentCapacity = equipment.Capacity;

                if(equipment.Name == "Egg Gatherer")
                {
                    resourceCount = 0;
                    ChooseEquipment._discardList.ForEach(resource => {
                        IEggProducing eggRes = (IEggProducing)resource;
                        resourceCount += eggRes.CollectEggs();
                    });
                }

                if(resourceCount >= equipmentCapacity){
                    Console.WriteLine("You have reached the maximum number that can be processed at one time");
                    Console.WriteLine("Press enter to process resources");
                    Console.ReadLine();
                    readyToProcess = true;
                }
                else
                {

                    Console.Clear();
                    Console.WriteLine($"The {equipment.Name} can process {equipmentCapacity} resources at one time.");
                    Console.WriteLine($"You have currently selected {resourceCount} resources to process.");
                    Console.WriteLine();

                    //if the equipment type is composter then if the discardList has resources in it, only show facilities that contain that resource, else show all the facilities
                    if(equipment.Name == "Composter" && resourceCount != 0){
                        if(ChooseEquipment.selectedFacility.Type == "Grazing Field")
                        {
                            availableFacilities = facilityList.Where(facility => facility.Type == "Grazing Field").ToList();
                        }else
                        {
                            availableFacilities = facilityList.Where(facility => facility.Type != "Grazing Field").ToList();
                        }
                    }
                    for (var i = 0; i < availableFacilities.Count; i++)
                    {
                        var currentFacility = availableFacilities[i];
                        Console.WriteLine($"{i + 1}. {currentFacility.Type} ({currentFacility.Total} {currentFacility.Category})");
                    }
                    
                    Console.WriteLine("Choose facility to process resources from.");

                    Console.Write("> ");

                    int facilityIndex = Int32.Parse(Console.ReadLine()) - 1;

                    var facilityChoosen = availableFacilities[facilityIndex];

                    if(equipment.Name == "Composter" && resourceCount == 0){
                        ChooseEquipment.selectedFacility = facilityChoosen;
                    }
                    Console.Clear();


                    //add only resources that the equipment can process and that have not already been selected to discard to availableResourcesList
                    List<IResource> availableResourcesList = equipment.GetFacilityResources(facilityChoosen.Resources).Where(resource => !ChooseEquipment._discardList.Contains(resource)).ToList();

                    if(availableResourcesList.Count == 0){
                        Console.WriteLine("This facility does not have any resources that can be processed");
                        Console.ReadLine();
                    }
                    else{
                        var availableSpace = equipmentCapacity - resourceCount;
                        readyToProcess = ChooseResource.CollectInput(availableResourcesList, ChooseEquipment._discardList, availableSpace, equipment);
                    }
                    }
            }
            while(!readyToProcess);

            equipment.ProcessResources(ChooseEquipment._discardList, availableFacilities);
            ChooseEquipment._discardList = new List<IResource>();

            Console.WriteLine();
            Console.WriteLine("Please press enter to return to main menu");
            Console.ReadLine();
        }
        
    }
}