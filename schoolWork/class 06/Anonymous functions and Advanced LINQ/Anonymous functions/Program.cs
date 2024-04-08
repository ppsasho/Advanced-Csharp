namespace Anonymous_functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Enter a number: ";
            Func<int, int, string> sumFunc = (a, b) => $"The result of summing {a} and {b} is: {a + b}.";
            Console.WriteLine(sumFunc(346346, 2355523));

            //Console.WriteLine(Sum(GetInput(message), GetInput(message), sumFunc));

            Action<string, string> printFullName = (firstName, lastName) => Console.WriteLine($"{firstName} {lastName}");
            //printFullName(GetInput("Enter your first name:"), GetInput("Enter your last name:"));

            List<string> studentList = new List<string>() { "Sasho", "David", "Filip", "Martin"};

            Action<string, List<string>> printStudents = (msg, list) =>
            {
                Console.Write(msg);
                Console.WriteLine(string.Join(", ", list));
            };
            printStudents("Students: ", studentList);

            Action<string, ConsoleColor> printInColor = (msg, color) =>
            {
                Console.ForegroundColor = color;
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.White;
            };

            printInColor("Hello in cyan", ConsoleColor.Cyan);
        }
        static string GetInput(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        static string Sum(string a, string b, Func<int, int, string> operation)
        {
            int num1 = int.Parse(a);
            int num2 = int.Parse(b);
            string result = operation(num1, num2);
            return result;
        }

    }
}
