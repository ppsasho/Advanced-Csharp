namespace Models
{
    public class User : BaseClass
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public User(string name, string username, string createdBy, DateTime createdAt) : base(createdBy, createdAt)
        {
            Name = name;
            Username = username;
            //AuditHelper<BaseClass>.SetCreateParams(this, createdBy);
        }

    }
}
