namespace Models
{
    public class StandardUser : User
    {
        public StandardUser(string firstName, string lastName, string username, string password) : base(firstName, lastName, username, password)
        {
        }

        public override string Account()
        {
            return $"{FirstName} {LastName} [user: {Username}] - Standard User";
        }

        public override string Train()
        {
            return $"You({FirstName}) are training.";
        }
        //public string UpgradeToPremium()
        //{

        //}
    }
}
