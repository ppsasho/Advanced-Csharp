namespace Async_Await_example2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetMessage();
            Console.WriteLine("End of the main");
            Thread.Sleep(10000);
        }

        public static async Task GetMessage()
        {
            Task.Run(() =>
            {
                Console.WriteLine("Enter GetMessage");
                Thread.Sleep(5000);
                Console.WriteLine("End of GetMessage");
            });
        }
    }
}
