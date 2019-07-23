using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class Facility : IResource, IFacility
    {
        private Guid _id = Guid.NewGuid();

        private List<IResource> _animals = new List<IResource>();
        public virtual string Type {get; }

        public virtual double Capacity {get;}

        public Guid FacilityId
        {
            get
            {
                return _id;
            }
        }
        public int TotalAnimals {
            get
            {
                return _animals.Count;
            }
        }

        public List<IResource> Resources
        {
            get
            {
                return _animals;
            }
        }
        public void AddResource(IResource resource)
        {
            _animals.Add(resource);
        }

        public void AddResource(List<IResource> resources)
        {
            _animals.AddRange(resources);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"{Type} {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}