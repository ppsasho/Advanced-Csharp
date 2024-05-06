namespace Models
{
    public abstract class Base
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public Base(string firstName, string lastName, int age, string username, string password) 
        {
            if (CheckName(firstName) && CheckName(lastName))
            {
                FirstName = firstName;
                LastName = lastName;
            }
            SetAge(age);
            SetUsername(username);
            SetPassword(password);
            IsActive = true;
        }
        private void SetUsername(string username)
        {
            if (username.Length < 5) throw new ArgumentException("Can't have a username shorter than 5 chars!");
            Username = username;
        }
        public void SetPassword(string password)
        {
            if (password.Length < 6) throw new ArgumentException("Password can't be shorter than 6 chars!");
            if (!password.Any(x => char.IsNumber(x))) throw new ArgumentException("Password must contain at least one number!");
            if (!password.Any(x => char.IsUpper(x))) throw new ArgumentException("Password must contain at least one uppercase character!");
            Password = password;
        }
        private void SetAge(int age)
        {
            if (age < 18 || age > 120) throw new ArgumentException("You can't create an account if your under the age of 18 or over the age of 120!");
            Age = age;
        }
        private bool CheckName(string name)
        {
            if (name.Length < 2) throw new ArgumentException("Your name can't be shorter than 2 chars!");
            if (name.Any(x => char.IsNumber(x))) throw new ArgumentException("You can't have numbers in your names!");
            return true;
        }
        public void ChangeFirstName(string name)
        {
            if (CheckName(name)) FirstName = name;
        }
        public void ChangeLastName(string name)
        {
            if(CheckName(name)) LastName = name;
        }
        public void ActivateAccount()
        {
            IsActive = true;
        }
        public void DeactivateAccount()
        {
            IsActive = false;
        }
    }
}
