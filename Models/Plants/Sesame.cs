using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : Plant, ISeedProducing
    {
        private int _seedsProducedPerRow = 40;
        public override string Type { get; } = "Sesame";

        public double Harvest()
        {
            return _seedsProducedPerRow;
        }

        public override string ToString()
        {
            return $"Sesame plants {this.ShortId}. Yum!";
        }

    }
}