using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, ICompostProducing
    {
        private Guid _id = Guid.NewGuid();
        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        private double _compostProducedPerPlant = 0.51;
        public string Type { get; } = "Wildflower";

        public double CollectCompost()
        {
            return _compostProducedPerPlant;
        }

        public override string ToString () {
            return $"Wildflower plants {this._shortId}. Colorful!";
        }
    }
}