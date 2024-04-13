namespace Delegate
{
    internal class Program
    {
        public delegate void GreetingDelegate(string name);
        static void Main(string[] args)
        {
            GreetingDelegate greetings;
            greetings = SayHi;
            greetings += GreetUser;
            greetings += (x) => Console.WriteLine($"Have a nice day {x}");
            //greetings("Sasho");
            WelcomeUser("Sasho", greetings);
        }
        public static void WelcomeUser(string name, GreetingDelegate function)
        {
            function(name);
        }
        public static void GreetUser(string name)
        {
            Console.WriteLine($"Welcome to our page {name}");
        }
        public static void SayHi(string name)
        {
            Console.WriteLine($"Hi {name}");
        }
    }
}
