using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Equipment
{
    public class EggGatherer : IEquipment
    {
        public string Name { get; } = "Egg Gatherer";
        public double Capacity { get; } = 15;

        public List<IResource> ResourcesProcessed { get; set; } = new List<IResource>();

        public List<IResource> GetFacilityResources(List<IResource> facilityResources)
        {
            var eggResources = new List<IResource>();
            foreach (var resource in facilityResources)
            {
                if (resource is IEggProducing)
                {

                    eggResources.Add(resource);
                }
            }

            return eggResources;
        }

        public void ProcessResults()
            {
                Dictionary<string, double> eggsProduced = new Dictionary<string, double>();
                ResourcesProcessed.ForEach(animal => {
                    IEggProducing resource = (IEggProducing)animal;
                    try
                    {
                        eggsProduced.Add(resource.GetType().Name, resource.CollectEggs());
                    }
                    catch(Exception)
                    {
                        eggsProduced[resource.GetType().Name] += resource.CollectEggs();
                    }
                });
                foreach(KeyValuePair<string, double> animal in eggsProduced){

                    System.Console.WriteLine($"{animal.Value} {animal.Key} eggs were collected");
                }
            }
        
        public void ProcessResources(List<IResource> processList, List<Facility> facilityList)
        {
            // processList.ForEach(resource => {

            //     Facility resourceFacility = facilityList.Find(facility => facility.Resources.Contains(resource));
            //     resourceFacility.Resources.Remove(resource);

            // });
            
            ResourcesProcessed.AddRange(processList);
            ProcessResults();
        }

    }
}
