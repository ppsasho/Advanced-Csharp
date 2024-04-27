namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendMessagesWithThreads();
        }
        //Manual threads
        static void SendMessagesWithThreads()
        {
            Console.WriteLine("Getting ready..");
            Thread.Sleep(2000);
            Thread myThread = new(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("First msg.");
            });
            myThread.Start();
            new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Second msg.");
            }).Start();
            new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Third msg.");
            }).Start();
            Console.WriteLine("All msgs received.");
        }
    }
}
