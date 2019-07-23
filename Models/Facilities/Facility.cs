using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class Facility : IResource, IFacility
    {
        private Guid _id = Guid.NewGuid();
        private List<IResource> _resouces = new List<IResource>();
        public virtual string Type {get; }

        public virtual double Capacity {get;}

        public virtual bool Full {get;}

        public Guid FacilityId
        {
            get
            {
                return _id;
            }
        }
        public virtual int Total {
            get
            {
                return _resouces.Count;
            }
        }

        public List<IResource> Resources
        {
            get
            {
                return _resouces;
            }
        }
        public void AddResource(IResource resource)
        {
            _resouces.Add(resource);
        }

        public void AddResource(List<IResource> resources)
        {
            _resouces.AddRange(resources);
        }


    }
}