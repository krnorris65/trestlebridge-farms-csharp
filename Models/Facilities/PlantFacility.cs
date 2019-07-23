using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class PlantFacility : IResource, IFacility
    {
        private Guid _id = Guid.NewGuid();

        private List<IResource> _plantRows = new List<IResource>();
        public virtual string Type {get; }

        public virtual double Capacity {get;}
        public virtual int TotalPlants {get;}

        public Guid FacilityId
        {
            get
            {
                return _id;
            }
        }

        public List<IResource> Resources
        {
            get
            {
                return _plantRows;
            }
        }
        public void AddResource(IResource resource)
        {
            _plantRows.Add(resource);
        }

        public void AddResource(List<IResource> resources)
        {
            _plantRows.AddRange(resources);
        }

    }
}