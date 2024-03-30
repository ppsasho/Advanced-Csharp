using Models;
namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher("sasho", "Sasho", "saso123", "C# Basic");

            var teacher2 = new Teacher("kire", "Kire", "kire123", "C# Advanced");
            Console.WriteLine(teacher2.GetUser());

            var student1 = new Student(new List<int> {1, 4, 5, 6, 7}, "jake", "Jake", "jakesky123");

            Console.WriteLine(teacher.GetUser());
            Console.WriteLine(student1.GetUser());

            DateTime now = DateTime.Now;
        }
    }
}
