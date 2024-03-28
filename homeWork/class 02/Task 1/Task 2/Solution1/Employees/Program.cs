namespace Employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new("Josh", 40000);
            Manager manager = new("Bob", 40000);
            Console.WriteLine($"{programmer.DiplayInfo()}\n{manager.DiplayInfo()}");
        }
    }
}
