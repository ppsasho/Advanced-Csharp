using Models.Enum;

namespace Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public RoleEnum Role { get; set; }
        public User(int id, string firstName, string lastName, string username, RoleEnum role, string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            SetPassword(password);
            Role = role;
        }

        public void SetPassword(string password) 
        {
            if(string.IsNullOrEmpty(password)) throw new ArgumentException("Password is required.");
            if (password.Length < 8) throw new ArgumentException("Password is not withing the required length (8 characters)");

            Password = password;
        }
    }
}
