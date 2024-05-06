
namespace Models
{
    public class Working : Activity
    {
        public Working(DateTime start, DateTime end, string type) : base(start, end, "Working", type) {  }
    }
}
