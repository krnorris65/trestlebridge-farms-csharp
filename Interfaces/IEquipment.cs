using System.Collections.Generic;

namespace Trestlebridge.Interfaces
{
    public interface IEquipment
    {
        string Name {get; }
        double Capacity { get; }

        List<IResource> ResourcesProcessed { get; set; }

        List<IResource> GetEquipmentResources(List<IResource> list);

        void ProcessResources ();

    }
}