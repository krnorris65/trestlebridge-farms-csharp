using System.Text;

namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : Facility
    {
        private int _capacity = 12;
        public override string Type {get; } = "Duck House";
        public override double Capacity 
        {
            get
            {
                return _capacity;
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