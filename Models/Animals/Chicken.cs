using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Equipment;

namespace Trestlebridge.Models.Animals
{
    public class Chicken : IResource, IPoultry, IMeatProducing, IEggProducing, IFeatherProducing
    {

        private Guid _id = Guid.NewGuid();
        private double _meatProduced = 1.7;
        private double _eggsProduced = 7;
        private double _feathersProduced = 0.5;

        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double FeedPerDay { get; set; } = 0.9;
        public string Type { get; } = "Chicken";

        // Methods
        public void Feed()
        {
            Console.WriteLine($"Chicken {this._shortId} just ate {this.FeedPerDay}kg of feed");
        }

        public double Butcher()
        {
            return _meatProduced;
        }
        public double CollectEggs()
        {
            return _eggsProduced;
        }

        public double GatherFeathers()
        {
            return _feathersProduced;
        }
        public double Process(MeatProcessor meat)
        {
            return _meatProduced;
        }
        public double Process(EggGatherer egg)
        {
            return _eggsProduced;
        }

        public double Process()
        {
            return _feathersProduced;
        }

        public override string ToString()
        {
            return $"Chicken {this._shortId}. Cluck!";
        }


    }
}