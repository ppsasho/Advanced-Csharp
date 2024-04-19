namespace OptionalParams_Nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? a;
            string text;
            text = null;
            bool? success;
            success = null;

            PrintMessage("Hello user!", 1);
            PrintMessage("Thanks for visiting this app!", 2, ConsoleColor.Green);

            // If you are skipping the first optional parameter and sending the second optional parameter in a function, use the paramater name in the function
            // and add the colon with the value for the parameter.
            PrintMessage("I hope you have a nice day!", 3, backgroundColor: ConsoleColor.DarkCyan);
        }
        static void PrintMessage(string msg, int lineNumber,
            ConsoleColor color = ConsoleColor.Blue, ConsoleColor backgroundColor = ConsoleColor.Yellow)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine($"{lineNumber}. - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
