using System.Collections.Generic;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Interfaces
{
    public interface IEquipment
    {
        string Name {get; }
        double Capacity { get; }

        List<IResource> ResourcesProcessed { get; set; }

        List<IResource> GetFacilityResources(List<IResource> list);

        void ProcessResults ();
        void ProcessResources (List<IResource> rList, List<Facility> fList);

    }
}