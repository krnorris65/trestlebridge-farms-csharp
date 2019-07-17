using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Models.Animals;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _ducks = new List<Duck>();

        public bool HouseFull {
            get
            {
                return _ducks.Count == _capacity;
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

        public void AddResource(Duck duck)
        {
            // TODO: implement this...
            _ducks.Add(duck);

        }

        public void AddResource(List<Duck> ducks)
        {
            // TODO: implement this...
            _ducks.AddRange(ducks);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._ducks.Count} ducks\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}