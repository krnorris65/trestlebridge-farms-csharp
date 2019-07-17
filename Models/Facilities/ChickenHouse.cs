using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : IFacility<IMeatProducing>
    {
        private int _capacity = 1;
        private Guid _id = Guid.NewGuid();

        private List<IMeatProducing> _animals = new List<IMeatProducing>();

        public bool FieldFull {
            get
            {
                return _animals.Count == _capacity;
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

        public void AddResource(IMeatProducing animal)
        {
            // TODO: implement this...
            _animals.Add(animal);

        }

        public void AddResource(List<IMeatProducing> animals)
        {
            // TODO: implement this...
            _animals.AddRange(animals);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}