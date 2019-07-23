using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : PlantFacility
    {
        // 10 rows of plants 
        // 6 plants per row (when purchase you purchase enough seeds for a whole row of plants)
        private int _capacityRows = 10;
        private int _plantsPerRow = 6;
        public override string Type {get; } = "Natural Field";

        public override int TotalPlants
        {
            get
            {
                return Resources.Count * _plantsPerRow;
            }
        }

        public bool FieldFull
        {
            get
            {
                return Resources.Count == _capacityRows;
            }
        }

        public override double Capacity
        {
            get
            {
                return _capacityRows * _plantsPerRow;
            }
        }


        public List<ResourceType> GetPlantTypes()
        {
            return (from plant in Resources
                    group plant by plant.GetType().Name into plantType
                    select new ResourceType { Type = plantType.Key, Total = (plantType.Count() * _plantsPerRow) }).ToList();

        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this.FacilityId.ToString().Substring(this.FacilityId.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this.TotalPlants} plants ({this.Resources.Count} rows)\n");
            this.Resources.ForEach(a => output.Append($"   {_plantsPerRow} {a}\n"));

            return output.ToString();
        }
    }
}