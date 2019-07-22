using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Equipment
{
    public class MeatProcessor : IEquipment
    {
        public string Name { get; } = "Meat Processor";
        public double Capacity { get; } = 7;

        public List<IResource> Resources { get; set; } = new List<IResource>();

        public void ProcessResources()
            {
                Dictionary<string, double> meatProduced = new Dictionary<string, double>();
                Resources.ForEach(animal => {
                    IMeatProducing resource = (IMeatProducing)animal;
                    try
                    {
                        meatProduced.Add(resource.GetType().Name, resource.Butcher());
                    }
                    catch(Exception)
                    {
                        meatProduced[resource.GetType().Name] += resource.Butcher();
                    }
                });
                foreach(KeyValuePair<string, double> animal in meatProduced){

                    System.Console.WriteLine($"{animal.Value}kg of {animal.Key} meat was produced");
                }
            }
        
        public void ProcessResources(List<IMeatProducing> animals)
        {
            // Resources.AddRange(animals);
        }

    }
}
