using Models;

namespace Exercise_3
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name {  get; set; }
        private string Password { get; set; }
        public User(string username, string name, string password) 
        {
            Random rnd = new Random();
            Id = rnd.Next(1, int.MaxValue);
            Username = username;
            Name = name;
            Password = password;
        }

        public virtual string GetUser()
        {
            return $"{Id}: {Name} [{Username}]";
        }

        //public abstract string GetUser();

    }
}
