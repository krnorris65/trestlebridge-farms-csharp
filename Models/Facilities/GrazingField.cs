using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;


namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : Facility
    {
        private int _capacity = 20;
        public override string Type {get; } = "Grazing Field";
        public override string ResourceType {get; } = "animal";

        public override double Capacity 
        {
            get
            {
                return _capacity;
            }
        }
        public override bool Full
        {
            get
            {
                return _capacity == Resources.Count;
            }
        }
        // public List<ResourceType> GetAnimalTypes()
        // {
        //     return (from animal in _animals
        //             group animal by animal.GetType().Name into animalType
        //             select new ResourceType { Type = animalType.Key, Total = animalType.Count() }).ToList();

        // }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this.FacilityId.ToString().Substring(this.FacilityId.ToString().Length - 6)}";

            output.Append($"{Type} {shortId} has {this.Resources.Count} animals\n");
            this.Resources.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

    }
}