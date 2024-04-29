namespace Async_Await
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainThread();
            Console.ReadLine();
        }
        static async Task MainThread()
        {
            SendMessageAsync("Hello there");
            ShowAd("Computer");
        }

        //synchronous
        static void SendMessage(string msg)
        {
            Console.WriteLine("Sending message..");
            Thread.Sleep(1500);
            Console.WriteLine($"The message ({msg}) was sent");

        }
        //Asynchronous
        static async Task SendMessageAsync(string msg)
        {
            Console.WriteLine("Sending message");
            await Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine($"The message ({msg}) was sent");
            });
        }
        static void PrintInColor(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        static void ShowAd(string product)
        {
            Console.WriteLine("While you wait, let us show you an ad.");
            Console.WriteLine("Buy the best product in za warudo");
            PrintInColor(product, ConsoleColor.Yellow);
            PrintInColor("Free shipping worldwide!", ConsoleColor.Blue);
            PrintInColor("Do you want a break from the ads?", ConsoleColor.Green);
        }

    }
}
