
namespace Models
{
    public class Reading : Activity
    {
        public int Pages { get; set; }
        public Reading(DateTime start, DateTime end, string type, int pages) : base(start, end, "Reading", type)
        {
            Pages = pages;
        }
    }
}
