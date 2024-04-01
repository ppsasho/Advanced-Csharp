namespace Models
{
    public class BaseClass
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set;}
        public BaseClass(string createdBy, DateTime createdAt)
        {
            Random rnd = new Random();
            Id = rnd.Next(1, Int32.MaxValue);

            CreatedBy = createdBy;
            CreatedAt = createdAt;
        }
    }
}
