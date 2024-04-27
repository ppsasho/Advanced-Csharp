namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process starting..........");
            //Thread.Sleep(3000);

            Task myTask = new(() =>
            {
                Thread.Sleep(2222);
                Console.WriteLine("Running after 2ish scnds");
            });
            //myTask.Start();

            Task<int> myTask2 = new(() =>
            {
                Thread.Sleep(3000);
                Random rnd = new Random();
                return rnd.Next(1, 7);
            });
            myTask2.Start();
            Console.WriteLine($"The number received: {myTask2.Result}");

            Console.WriteLine("Getting number..");

            Task.Run(() =>
            {
                Thread.Sleep(3333);
                Console.WriteLine("This is finished.");
            });

            Console.ReadLine();
        }
    }
}
