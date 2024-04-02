namespace Task_1
{
    public static class CMD
    {
        public static List<bool> GetBools(string msg)
        {
            List<bool> list = new();
            while (true)
            {
                list.Add(GetBool(msg));
                switch (GetInput("Would you like to add another item? (Y N)").ToUpper())
                {
                    case "Y":
                        continue;
                    case "N":
                    default:
                        return list;
                }
            }
        }
        public static List<double> GetNumbers(string msg)
        {
            List<double> list = new();
            while (true)
            {
                list.Add(GetNumber(msg));
                switch (GetInput("Would you like to add another item? (Y N)").ToUpper())
                {
                    case "Y":
                        continue;
                    case "N":
                    default:
                        return list;
                }
            }
        }
        public static List<string> GetStrings(string msg)
        {
            List<string> list = new();
            while (true)
            {
                list.Add(GetInput(msg));
                switch (GetInput("Would you like to add another item? (Y N)").ToUpper())
                {
                    case "Y":
                        continue;
                    case "N":
                    default:
                        return list;
                }
            }
        }
        public static bool GetBool(string msg)
        {
            while (true)
            {
                if (bool.TryParse(GetInput(msg), out bool result)) return result;
            }
        }
        public static double GetNumber(string msg)
        {
            while (true)
            {
                if (double.TryParse(GetInput(msg), out double result)) return result;
                Console.WriteLine("Please make sure you enter a number.");
                continue;
            }
        }
        public static bool DefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Please choose one of the numbers!");
            return false;
        }
        public static string GetInput(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) return input;
                Console.WriteLine("Please don't leave empty inputs!");
                continue;
            }
        }
    }
}
