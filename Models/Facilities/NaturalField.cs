using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ICompostProducing>
    {
                public string Name {get; } = "Natural Field";

        // 10 rows of plants 
        // 6 plants per row (when purchase you purchase enough seeds for a whole row of plants)
        private int _capacityRows = 10;
        private int _plantsPerRow = 6;
        private Guid _id = Guid.NewGuid();

        private List<ICompostProducing> _plantRows = new List<ICompostProducing>();

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
        public void AddResource(ICompostProducing plant)
        {
            _plantRows.Add(plant);
        }

        public void AddResource(List<ICompostProducing> plants)
        {
            _plantRows.AddRange(plants);
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

            output.Append($"Natural field {shortId} has {this.TotalPlants} plants ({this._plantRows.Count} rows)\n");
            this._plantRows.ForEach(a => output.Append($"   {_plantsPerRow} {a}\n"));

            return output.ToString();
        }
    }
}