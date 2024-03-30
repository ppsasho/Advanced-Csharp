namespace Static_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your domain name:");
            //string input = Console.ReadLine();

            //string username = Helper.GetUsername(input);
            //string fullName = Helper.GetFullName(username);
            //Console.WriteLine(fullName);

            var chelsea = new LiveScore("Chelsea", new List<string> { "W", "W", "L", "D", "W", "W" });
            chelsea.AddWin();
            int chelseaPoints = LiveScore.GetPoints(chelsea);
            Console.WriteLine($"Chelsea's points this year: {chelseaPoints}");
        }
    }
}
