using Models.Enums;
using Storage;

namespace Models
{
    public static class UserServices
    {
        public static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write($"{msg}\n\t");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) return input;
                Console.WriteLine("Please don't leave empty inputs!");
            }
        }
        public static decimal GetRating(string msg)
        {
            while (true)
            {
                if (decimal.TryParse(GetInput(msg), out decimal number))
                {
                    if (number < 1 || number > 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Please make sure your rating's not greater than 5 or lesser than 1");
                        continue;
                    }
                    return number;
                }
                Console.Clear();
                Console.WriteLine("Please make sure you enter a valid number!");
                continue;
            }
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
        public static DateTime GetDateTime(string msg)
        {
            while (true)
            {
                if (DateTime.TryParse(GetInput(msg), out DateTime dateTime))
                    if (dateTime > DateTime.Now) return dateTime;
                Console.Clear();
                Console.WriteLine("Please make sure to follow the format shown.\nAnd make sure the dates entered including time are somewhere in the future");
                continue;
            }
        }
        public static string GetVideoTrainings()
        {
            string result = string.Empty;
            foreach (var video in Data2.VideoTrainings) result += $"(ID: {video.Id})\t[{video.Title}]\n";
            return result;
        }
    }
}
