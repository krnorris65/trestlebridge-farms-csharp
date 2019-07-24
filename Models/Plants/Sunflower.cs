using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : Plant, ISeedProducing, ICompostProducing
    {
        private int _seedsProducedPerRow = 50;
        private double _compostProducedPerRow = 2.16;
        public override string Type { get; } = "Sunflower";

        public double CollectCompost()
        {
            return _compostProducedPerRow;
        }

        public double Harvest()
        {
            return _seedsProducedPerRow;
        }

        public override string ToString()
        {
            return $"Sunflower plants {this.ShortId}. Pretty!";
        }
    }
}