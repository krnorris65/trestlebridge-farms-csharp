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
        private int _capacityRows = 13;
        private int _plantsPerRow = 5;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _plantRows = new List<ISeedProducing>();

        public int TotalPlantRows
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