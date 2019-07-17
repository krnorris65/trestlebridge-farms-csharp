using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;


namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public int TotalAnimals
        {
            get
            {
                return _animals.Count;
            }
        }

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public Guid FieldId
        {
            get
            {
                return _id;
            }
        }

        public void AddResource(IGrazing animal)
        {
            // TODO: implement this...
            _animals.Add(animal);

        }

        public void AddResource(List<IGrazing> animals)
        {
            // TODO: implement this...
            _animals.AddRange(animals);
        }

        public List<AnimalType> GetAnimalTypes()
        {
            return (from animal in _animals
                        group animal by animal.GetType().Name into animalType
                        select new AnimalType{ Type = animalType.Key, Total = animalType.Count() }).ToList();
            
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}