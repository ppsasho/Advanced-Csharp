namespace WorkingDays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime result;
            while (true)
            {
                string date = GetInput("Enter the current date: (DD-MM-YYYY)");
                bool success = DateTime.TryParse(date, out result);
                if(!success)
                {
                    Console.WriteLine("Please check your format was correct.");
                    continue;
                }
                break;
            }
            if(result.DayOfWeek == DayOfWeek.Sunday || result.DayOfWeek == DayOfWeek.Saturday) 
            {
                Console.WriteLine("It's the Weekend.");
            }
            DateTime Jan1st = new DateTime(2024/ 01 / 01);
            DateTime Jan7th = new DateTime(2024 / 07 / 01);
            DateTime April20th = new DateTime(2024 / 20 / 04);
            DateTime May1st = new DateTime(2024 / 01 / 05 );
            DateTime May25th = new DateTime(2024 / 25 / 05 );
            DateTime Aug3rd = new DateTime(2024 / 03 / 08 );
            DateTime Sep8th = new DateTime(2024 / 08 / 09 );
            DateTime Oct12th = new DateTime(2024 / 12 / 10);
            DateTime Oct23rd = new DateTime(2024 / 23 / 10);
            DateTime Dec8th = new DateTime(2024 / 08 / 12 );
            Console.WriteLine(Dec8th.Month.ToString());
            List<DateTime> dates = new()
            {
                Jan1st, Jan7th, April20th, May1st, May25th, Aug3rd, Sep8th, Oct12th, Oct23rd, Dec8th
            };
            foreach (DateTime date in dates) if (date.Month == result.Month && date.Day == result.Day)
                {
                    Console.WriteLine("It's not a working day!");
                }

        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                string input = Console.ReadLine();
                if (input != "") return input;
                Console.WriteLine("Please don't leave empty fields!");
                continue;
            }
        }
    }
}
