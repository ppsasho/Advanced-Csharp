
namespace Models
{
    public class Hobby : Activity
    {
        public string CustomInfo { get; set; }
        public Hobby(DateTime start, DateTime end, string name, string type, string customInfo) : base(start, end, name, type)
        {
            CustomInfo = customInfo;
        }
    }
}
