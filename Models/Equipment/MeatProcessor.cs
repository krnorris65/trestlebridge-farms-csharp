using System.Collections.Generic;
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
                Resources.ForEach(animal => {
                    IMeatProducing resource = (IMeatProducing)animal;
                    System.Console.WriteLine($"{resource.Butcher()}kg of meat was produced");
                });
            }
        
        public void ProcessResources(List<IMeatProducing> animals)
        {
            // Resources.AddRange(animals);
        }

    }
}
