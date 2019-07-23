using System.Collections.Generic;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Interfaces
{
    public interface IFacility
    {
        double Capacity { get; }

        void AddResource (IResource resource);
        void AddResource (List<IResource> resources);
    }
}