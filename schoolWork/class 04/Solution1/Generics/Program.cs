using System.Security.Cryptography.X509Certificates;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new() { "Sasho", "Boris", "Risto", "Slave" };
            List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };
            List<bool> bools = new() { true, false, false, true };

            Console.WriteLine("Printing names");
            ListHelper.PrintItems<string>(names);

            Console.WriteLine("Printing numbers");
            ListHelper.PrintItems<int>(numbers);

            Console.WriteLine("Printing booleans");
            ListHelper.PrintItems<bool>(bools);

            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string> (1, "Sasho"),
                new KeyValuePair<int, string> (2, "Nikola")
            };
            ListHelper.PrintItems(list);

            List<User> users = new() { new User("Sasho", "Popovski"), new User("David", "Davidsky") };
            ListHelper.PrintUsers(users);

        }
    }
}
