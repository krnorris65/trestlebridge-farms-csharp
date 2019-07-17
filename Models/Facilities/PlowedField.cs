using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<ISeedProducing>
    {
        // 13 rows of plants 
        // 5 plants per row (when purchase you purchase enough seeds for a whole row of plants)
        private int _capacity = 13;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plantRows = new List<ISeedProducing>();

        public int TotalPlants
        {
            get
            {
                return _plantRows.Count;
            }
        }

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public Guid FieldId
        {
            get
            {
                return _id;
            }
        }
        public void AddResource(ISeedProducing plant)
        {
            _plantRows.Add(plant);
        }

        public void AddResource(List<ISeedProducing> plants)
        {
            _plantRows.AddRange(plants);
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._plantRows.Count} rows of plants\n");
            this._plantRows.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}