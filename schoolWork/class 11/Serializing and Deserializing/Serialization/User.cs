namespace Serialization
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public User(string name, string lastName, int age)
        {
            Name = name;
            LastName = lastName;
            Age = age;
        }
        public User() { }
    }
}
