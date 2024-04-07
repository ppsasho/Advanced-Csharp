namespace Models
{
    public class Trainer : User
    {
        public Trainer(string firstName, string lastName, string username, string password) : base(firstName, lastName, username, password)
        {
        }

        public override string Account()
        {
            return $"{FirstName} {LastName} [user: {Username}] - Trainer";
        }

        public override string Train()
        {
           return $"You are training these users: ";
        }
    }
}
