namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var folder = "Exercises";
            var filePath = @$"{folder}\calculations.txt";

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            else Console.WriteLine("Folder is already created");

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Calculation no.{i + 1}");
                int a = GetNumber("Enter your first number:");
                int b = GetNumber("Enter your second number:");
                string result = $"{Sum(a, b)} Solved at: {DateTime.UtcNow}";
                Console.Clear();

                Console.WriteLine(result);
                File.AppendAllText(filePath, $"{result}\n");
            }
        }
        #region Methods
        static int GetNumber(string msg)
        {
            while (true)
            {
                if (int.TryParse(GetInput(msg), out int number)) return number;
                else Console.WriteLine("Please make sure to enter a number");
                continue;
            }
        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input)) return input;
                else Console.WriteLine("Please don't leave empty inputs.");
                continue;
            }
        }
        static string Sum(int a, int b)
        {
            return $"{a} + {b} = {a + b}";
        }
        #endregion
    }
}
