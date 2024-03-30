using Models;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p1 = new BasketballPlayer(0, "Lebron", "James", "ljames", "ljames1234", 205);
            var p2 = new FootballPlayer(1, "Leonardo", "Messi", "lmessi", "lmessi1254", "Right");
            Console.WriteLine(Helper.GetStats(p1, 10));
            Console.WriteLine(Helper.GetStats(p1));
            Console.WriteLine(Helper.GetStats(p2));
            Console.WriteLine(Helper.GetStats(p2, 11));
        }
    }
}
