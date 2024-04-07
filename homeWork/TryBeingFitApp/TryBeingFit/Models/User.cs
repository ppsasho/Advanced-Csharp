namespace Models
{
    public abstract class User
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }

        public User(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            SetPassword(password);
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("Password can't be empty.");
            if (password.Length < 6) throw new ArgumentException("Password length isn't within the minimal range! (6 characters).");
            if (!password.Any(x => char.IsNumber(x))) throw new ArgumentException("Password must contain at least one number.)");
            Password = password;
        }
        public abstract string Account();
        public abstract string Train();
    }
}
