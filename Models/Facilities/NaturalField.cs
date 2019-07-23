using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : Facility
    {
        // 10 rows of plants 
        // 6 plants per row (when purchase you purchase enough seeds for a whole row of plants)
        private int _capacityRows = 10;
        private int _plantsPerRow = 6;
        public override string Type {get; } = "Natural Field";
        public override string Category {get; } = "plants";


        public override int Total
        {
            get
            {
                return Resources.Count * _plantsPerRow;
            }
        }

        public override bool Full
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
        public override List<ResourceType> ResourceTypes
        {
            get{
                return (from plant in Resources
                        group plant by plant.GetType().Name into plantType
                        select new ResourceType { Type = plantType.Key, Total = (plantType.Count() * _plantsPerRow) }).ToList();
            }

        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this.FacilityId.ToString().Substring(this.FacilityId.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this.Total} plants ({this.Resources.Count} rows)\n");
            this.Resources.ForEach(a => output.Append($"   {_plantsPerRow} {a}\n"));

            return output.ToString();
        }
    }
}