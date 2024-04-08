namespace Models
{
    public class PremiumUser : User
    {
        public PremiumUser(string firstName, string lastName, string username, string password) : base(firstName, lastName, username, password)
        {
        }

        public override string Account()
        {
            return $"Info ~ {FirstName} {LastName} | [user: {Username}] - Premium User";
        }

        public override string Train()
        {
            return $"You({FirstName}) are training.";
        }
    }
}
