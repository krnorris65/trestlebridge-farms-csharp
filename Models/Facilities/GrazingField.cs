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
        public override double Capacity 
        {
            get
            {
                return _capacity;
            }
        }

        // public List<ResourceType> GetAnimalTypes()
        // {
        //     return (from animal in _animals
        //             group animal by animal.GetType().Name into animalType
        //             select new ResourceType { Type = animalType.Key, Total = animalType.Count() }).ToList();

        // }

    }
}