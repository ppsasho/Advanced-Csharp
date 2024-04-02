namespace Models
{
    public class Deposit : BaseClass
    {
        public User User { get; set; }
        public decimal Amount { get; set; }
        public Deposit(User user, decimal amount, string createdBy, DateTime createdAt) : base(createdBy, createdAt)
        {
            User = user;
            Amount = amount;
        }
    }
}
