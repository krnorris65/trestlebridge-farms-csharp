using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, ICompostProducing
    {
        private Guid _id = Guid.NewGuid();

        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        private int _seedsProduced = 650;
        private double _compostProduced = 21.6;
        public string Type { get; } = "Sunflower";

        public double CollectCompost()
        {
            return _compostProduced;
        }

        public double Harvest()
        {
            return _seedsProduced;
        }

        public override string ToString()
        {
            return $"Sunflower plants {this._shortId}. Pretty!";
        }
    }
}