using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Equipment
{
    public class MeatProcessor : IEquipment
    {
        public string Name {get;} = "Meat Processor";
        public double Capacity {get;}

        public List<IResource> Resources { get; set; }

        public void ProcessResources()
        {
            
        }
    }
}
