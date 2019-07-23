
namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : Facility
    {
        private int _capacity;
        public override string Type {get; } = "Chicken House";
        public override double Capacity 
        {
            get
            {
                return _capacity;
            }
        }

    }
}