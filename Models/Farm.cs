using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class Farm
    {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();

        public List<ChickenHouse> ChickenHouse {get; } = new List<ChickenHouse>();

        public List<DuckHouse> DuckHouse {get;} = new List<DuckHouse>();

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T> (IResource resource, int index)
        {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing)resource);
                    break;
                default:
                    break;
            }
        }

        public void AddGrazingField (GrazingField field)
        {
            GrazingFields.Add(field);
        }

        public void AddChickenHouse (ChickenHouse house)
        {
            ChickenHouse.Add(house);
        }

        public void AddDuckHouse (DuckHouse house)
        {
            DuckHouse.Add(house);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));
            ChickenHouse.ForEach(ch => report.Append(ch));
            DuckHouse.ForEach(dh => report.Append(dh));

            return report.ToString();
        }
    }
}