
namespace Models
{
    public class Exercising : Activity
    {
        public Exercising(DateTime start, DateTime end, string type) : base(start, end, "Exercising", type) { }
    }
}
