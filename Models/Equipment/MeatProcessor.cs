using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models.Equipment
{
    public class MeatProcessor : IEquipment
    {
        public string Name { get; } = "Meat Processor";
        public double Capacity { get; }

        public List<IResource> Resources { get; set; }

        public void ProcessResources()
            {

            }

        public void ProcessResources(Farm farm, GrazingField facility)
        {
                var facId = facility.FieldId;
                // var farmProp = farm.GrazingFields[facId];
        }
        
    }
}
