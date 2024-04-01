namespace Generics
{
    public class ListHelper
    {
        public static void PrintItems<T>(List<T> items)
        {
            foreach(T item in items)
            {
                Console.WriteLine(item);
            }
        }
        public static void PrintUsers<T>(List<T> users) where T : User 
        {
            foreach(T user in users) Console.WriteLine($"User: {user.FirstName} {user.LastName}");
        }
    }
}
