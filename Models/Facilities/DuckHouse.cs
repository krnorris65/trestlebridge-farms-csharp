using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.Animals;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<Duck>
    {
        public string Name { get; } = "Duck House";

        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _animals = new List<Duck>();

        public int TotalAnimals
        {
            get
            {
                return _animals.Count;
            }
        }

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public Guid HouseId
        {
            get
            {
                return _id;
            }
        }

        public List<Duck> Resources
        {
            get
            {
                return _animals;
            }
        }

        public void AddResource(Duck duck)
        {
            // TODO: implement this...
            _animals.Add(duck);

        }

        public void AddResource(List<Duck> ducks)
        {
            // TODO: implement this...
            _animals.AddRange(ducks);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._animals.Count} ducks\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}