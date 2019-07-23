
using System.Text;

namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : Facility
    {
        private int _capacity = 15;
        public override string Type {get; } = "Chicken House";
        public override string ResourceType {get; } = "animal";
        public override double Capacity 
        {
            get
            {
                return _capacity;
            }
        }

        public override bool Full
        {
            get
            {
                return _capacity == Resources.Count;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this.FacilityId.ToString().Substring(this.FacilityId.ToString().Length - 6)}";

            output.Append($"{Type} {shortId} has {this.Resources.Count} animals\n");
            this.Resources.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

    }
}