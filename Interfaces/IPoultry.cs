namespace Trestlebridge.Interfaces
{
    public interface IPoultry
    {
        double FeedPerDay { get; set; }
        void Feed();
    }
}