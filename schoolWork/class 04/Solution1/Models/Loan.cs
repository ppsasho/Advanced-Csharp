namespace Models
{
    public class Loan : BaseClass
    {
        public User User { get; set; }
        public decimal Amount { get; set; }
        public Loan(User user, decimal amount, string createdBy, DateTime createdAt) : base(createdBy, createdAt)
        {
            User = user;
            Amount = amount;
        }
    }
}
