using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Equipment
{
    public class SeedHarvester : IEquipment
    {
        public string Name { get; } = "Seed Harvester";
        public double Capacity { get; } = 8;

        public List<IResource> ResourcesProcessed { get; set; } = new List<IResource>();

        public List<IResource> GetFacilityResources(List<IResource> facilityResources)
        {
            var seedResources = new List<IResource>();
            foreach (var resource in facilityResources)
            {
                if (resource is ISeedProducing)
                {

                    seedResources.Add(resource);
                }
            }

            return seedResources;
        }

        public void ProcessResults(List<IResource> resProcessed)
            {
                Dictionary<string, double> seedsProduced = new Dictionary<string, double>();
                resProcessed.ForEach(plant => {
                    ISeedProducing resource = (ISeedProducing)plant;
                    try
                    {
                        seedsProduced.Add(resource.GetType().Name, resource.Harvest());
                    }
                    catch(Exception)
                    {
                        seedsProduced[resource.GetType().Name] += resource.Harvest();
                    }
                });
                foreach(KeyValuePair<string, double> plant in seedsProduced){

                    System.Console.WriteLine($"{plant.Value} {plant.Key} seeds were produced");
                }
            }
        
        public void ProcessResources(List<IResource> processList, List<Facility> facilityList)
        {
            processList.ForEach(resource => {

                Facility resourceFacility = facilityList.Find(facility => facility.Resources.Contains(resource));
                resourceFacility.Resources.Remove(resource);

            });
            
            ResourcesProcessed.AddRange(processList);
            ProcessResults(processList);
        }

    }
}
