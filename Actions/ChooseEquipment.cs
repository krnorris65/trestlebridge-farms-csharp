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
                    List<IResource> availableResourcesList = equipment.GetFacilityResources(facilityChoosen.Resources).Where(resource => !ChooseEquipment._discardList.Contains(resource)).ToList();

                    if(availableResourcesList.Count == 0){
                        Console.WriteLine("This facility does not have any resources that can be processed");
                        Console.ReadLine();
                    }
                    else{
                        readyToProcess = ChooseResource.CollectInput(availableResourcesList, ChooseEquipment._discardList, equipment);
                    }
                    }
            }
            while(!readyToProcess);

            equipment.ProcessResources(ChooseEquipment._discardList, facilityList);

            Console.WriteLine();
            Console.WriteLine("Please press enter to return to main menu");
            Console.ReadLine();
        }
        
    }
}