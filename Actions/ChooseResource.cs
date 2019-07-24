using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseResource
    {
        public static bool CollectInput(List<IResource> resourceList, List<IResource> discardList, double spaceAvailable, string equipmentName)
        {
            Console.Clear();

            List<ResourceType> resourceTypeTotals = (from resource in resourceList
                                                group resource by resource.GetType().Name into resourceType
                                                select new ResourceType { Type = resourceType.Key, Total = resourceType.Count()}).ToList();

            int rNum = 1;

            Console.WriteLine("Select a resource to process:");
            foreach (var resourceType in resourceTypeTotals)
            {
                Console.WriteLine($"{rNum}. {resourceType.Type} ({resourceType.Total} available)");
                rNum++;
            }
            Console.Write(">");

            int resourceTypeIndex = Int32.Parse(Console.ReadLine()) - 1;

            var selectedResource = resourceTypeTotals[resourceTypeIndex];

            Console.WriteLine($"There are {selectedResource.Total} {selectedResource.Type}s. How many do you want to process?");
            Console.Write(">");
            int numSelected = Int32.Parse(Console.ReadLine());

            if (numSelected > selectedResource.Total)
            {
                Console.WriteLine($"There are not that many {selectedResource.Type}s available");
                    Console.WriteLine("Press enter to return to list of facilities");
                    Console.ReadLine();
                return false;
            }
            else
            {
                //find animals in availableResourcesList that match the type of animal that was selected and limit the number to the number of animals the user wants to process
                var processThese = (from animal in resourceList
                                    where animal.GetType().Name == selectedResource.Type
                                    select animal
                    ).Take(numSelected).ToList();
                //add them to discardList
                int numToAdd = numSelected;

                if(equipmentName == "Egg Gatherer" && (processThese[0] is IEggProducing)){
                    IEggProducing eggResource = (IEggProducing)processThese[0];
                    int eggsPerResource = eggResource.CollectEggs();
                    numToAdd = numSelected * eggsPerResource;
                }


                if(numToAdd > spaceAvailable){
                    Console.WriteLine("You have exceeded the maximum number of resources that this processor can handle");
                    Console.WriteLine("Press enter to return to list of facilities");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    discardList.AddRange(processThese);
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