using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Equipment
{
    public class Composter : IEquipment
    {
        public string Name { get; } = "Composter";
        public double Capacity { get; } = 8;
        public double CapacityGoat { get; } = 4;


        public List<IResource> ResourcesProcessed { get; set; } = new List<IResource>();

        public List<IResource> GetFacilityResources(List<IResource> facilityResources)
        {
            var compostResources = new List<IResource>();

            foreach (var resource in facilityResources)
            {
                if (resource is ICompostProducing)
                {

                    compostResources.Add(resource);
                }
            }

            return compostResources;
        }

        public void ProcessResults(List<IResource> resProcessed)
        {
            Dictionary<string, double> compostProduced = new Dictionary<string, double>();
            resProcessed.ForEach(composter =>
            {
                ICompostProducing resource = (ICompostProducing)composter;
                try
                {
                    compostProduced.Add(resource.GetType().Name, resource.CollectCompost());
                }
                catch (Exception)
                {
                    compostProduced[resource.GetType().Name] += resource.CollectCompost();
                }
            });
            foreach (KeyValuePair<string, double> composter in compostProduced)
            {

                System.Console.WriteLine($"{composter.Value}kg of {composter.Key} compost was collected");
            }
        }

        public void ProcessResources(List<IResource> processList, List<Facility> facilityList)
        {
            processList.ForEach(resource => {

                if(resource is Plant){
                    Facility resourceFacility = facilityList.Find(facility => facility.Resources.Contains(resource));
                    resourceFacility.Resources.Remove(resource);
                }
            });
            ResourcesProcessed.AddRange(processList);
            ProcessResults(processList);
        }

    }
}
