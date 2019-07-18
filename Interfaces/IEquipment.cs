using System.Collections.Generic;

namespace Trestlebridge.Interfaces
{
    public interface IEquipment
    {
        string Name {get; }
        double Capacity { get; }

        List<IResource> Resources { get; set; }

        void ProcessResources ();

    }
}