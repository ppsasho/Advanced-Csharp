using Exercise_3;

namespace Models
{
    public class Teacher : User
    {
        public string Subject { get; set; }
        public Teacher(string username, string name, string password, string subject) : base(username, name, password)
        {
            Subject = subject;
        }
        public override string GetUser()
        {
            return base.GetUser() + $"\nSubject: {Subject}";
        }
    }
}
