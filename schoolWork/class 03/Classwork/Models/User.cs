namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; private set; }
        public string FullName => $"{FirstName} {LastName}";
        public User(int id, string firstName, string lastName, string userName, string password) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            setPassword(password);
        }

        public void setPassword(string password) 
        {
            if(string.IsNullOrEmpty(password)) 
            {
                throw new Exception("Password is required!");
            }
            if(password.Length < 8)
            {
                throw new Exception("Password is not at least 8 characters long");
            }
            Password = password;
        }
        public virtual string GetData()
        {
            return FullName;
        }
    }
}
