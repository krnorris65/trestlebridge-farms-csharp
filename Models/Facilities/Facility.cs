using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class Facility : IResource, IFacility
    {
        private Guid _id = Guid.NewGuid();
        private List<IResource> _resources = new List<IResource>();
        public virtual string Type {get; }

        public virtual string Category {get;}

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
                return _resources.Count;
            }
        }

        public List<IResource> Resources
        {
            get
            {
                return _resources;
            }
        }
        public void AddResource(IResource resource)
        {
            _resources.Add(resource);
        }

        public void AddResource(List<IResource> resources)
        {
            _resources.AddRange(resources);
        }

        public virtual List<ResourceType> ResourceTypes
        {
            get{
                return (from resource in _resources
                        group resource by resource.GetType().Name into resourceType
                        select new ResourceType { Type = resourceType.Key, Total = resourceType.Count() }).ToList();
            }
        }

    }
}