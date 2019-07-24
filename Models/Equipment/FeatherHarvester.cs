using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Equipment
{
    public class FeatherHarvester : IEquipment
    {
        public string Name { get; } = "Feather Harvester";
        public double Capacity { get; } = 8;

        public List<IResource> ResourcesProcessed { get; set; } = new List<IResource>();

        public List<IResource> GetFacilityResources(List<IResource> facilityResources)
        {
            var featherResources = new List<IResource>();
            foreach (var resource in facilityResources)
            {
                if (resource is IFeatherProducing)
                {

                    featherResources.Add(resource);
                }
            }

            return featherResources;
        }

        public void ProcessResults(List<IResource> resProcessed)
            {
                Dictionary<string, double> feathersProduced = new Dictionary<string, double>();
                resProcessed.ForEach(animal => {
                    IFeatherProducing resource = (IFeatherProducing)animal;
                    try
                    {
                        feathersProduced.Add(resource.GetType().Name, resource.GatherFeathers());
                    }
                    catch(Exception)
                    {
                        feathersProduced[resource.GetType().Name] += resource.GatherFeathers();
                    }
                });
                foreach(KeyValuePair<string, double> animal in feathersProduced){

                    System.Console.WriteLine($"{animal.Value}kg of {animal.Key} feathers were produced");
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
