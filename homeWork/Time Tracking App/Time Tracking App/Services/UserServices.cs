using Storage;

namespace Services
{
    public static class UserServices
    {
        public static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write($"{msg}\n\t");
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) return input;
                Console.WriteLine("Please don't leave empty inputs!");
            }
        }
        public static DateTime StartActivity()
        {
            Console.WriteLine("Press enter to start activity..");
            Console.ReadLine();
            return DateTime.UtcNow;
        }
        public static DateTime EndActivity()
        {
            Console.WriteLine("Press enter to end activity");
            Console.ReadLine();
            return DateTime.UtcNow;
        }
        public static void PressEnterToGoBack()
        {
            Console.WriteLine("\nPress enter to go back");
            Console.ReadLine();
            Console.Clear();
        }

        public static int GetNumber(string msg)
        {
            while (true)
            {
                if (int.TryParse(GetInput(msg), out int number)) return number;
                Console.Clear();
                Console.WriteLine("Please make sure to enter a number!");
                continue;
            }
        }

        public static bool LogOut()
        {
            CurrentSession.Remove();
            return false;
        }
    }
}
