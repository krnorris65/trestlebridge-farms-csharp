using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : Plant, ICompostProducing
    {
        private double _compostProducedPerRow = 3.03;
        public override string Type { get; } = "Wildflower";

        public double CollectCompost()
        {
            return _compostProducedPerRow;
        }

        public override string ToString () {
            return $"Wildflower plants {this.ShortId}. Colorful!";
        }
    }
}