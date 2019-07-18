using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<ISeedProducing>
    {
        public string Name {get; } = "Plowed Field";

        // 13 rows of plants 
        // 5 plants per row (when purchase you purchase enough seeds for a whole row of plants)
        private int _capacityRows = 13;
        private int _plantsPerRow = 5;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plantRows = new List<ISeedProducing>();

        public int TotalPlants
        {
            get
            {
                return _plantRows.Count * _plantsPerRow;
            }
        }

        public bool FieldFull
        {
            get
            {
                return _plantRows.Count == _capacityRows;
            }
        }

        public double Capacity
        {
            get
            {
                return _capacityRows * _plantsPerRow;
            }
        }

        public Guid FieldId
        {
            get
            {
                return _id;
            }
        }
        public void AddResource(ISeedProducing plantRow)
        {
            _plantRows.Add(plantRow);
        }

        public void AddResource(List<ISeedProducing> plantRows)
        {
            _plantRows.AddRange(plantRows);
        }

        public List<ResourceType> GetPlantTypes()
        {
            return (from plant in _plantRows
                    group plant by plant.GetType().Name into plantType
                    select new ResourceType { Type = plantType.Key, Total = (plantType.Count() * _plantsPerRow) }).ToList();

        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this.TotalPlants} plants ({this._plantRows.Count} rows)\n");
            this._plantRows.ForEach(a => output.Append($"   {_plantsPerRow} {a}\n"));

            return output.ToString();
        }
    }
}