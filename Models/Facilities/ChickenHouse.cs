
namespace Trestlebridge.Models.Facilities
{
    public class ChickenHouse : Facility
    {
        private int _capacity = 15;
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