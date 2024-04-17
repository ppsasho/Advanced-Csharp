using Serilog;
namespace Logger
{
    internal class Student
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal string FullName { get; set; }
        internal Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = firstName + " " + lastName;
            Log.Information($"New student created {FullName}");
        }
    }
}
