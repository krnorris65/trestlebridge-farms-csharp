namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : AnimalFacility
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
    }
}