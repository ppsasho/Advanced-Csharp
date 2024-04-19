namespace Garbage_Collector_test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Look at the right side where the Diagnostic tools show the Process memory, you will see yellow lines\n(The garbage collector) appear on the blue graph every few seconds removing the objects created in the loop. ");
            //while (true) 
            //{
            //    var s = new Dictionary<int, User>();
            //    s.Add(1, new User("Sasho", "Popovski"));
            //    s.Add(2, new User("Sasho", "Popovski"));
            //    s.Add(3, new User("Sasho", "Popovski"));
            //    s.Add(4, new User("Sasho", "Popovski"));
            //    s.Add(5, new User("Sasho", "Popovski"));
            //    s.Add(6, new User("Sasho", "Popovski"));
            //    s.Add(7, new User("Sasho", "Popovski"));
            //    s.Add(8, new User("Sasho", "Popovski"));
            //    s.Add(9, new User("Sasho", "Popovski"));
            //}
            var folderPath = "Data";
            var filePath = $@"{folderPath}\customText.txt";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            else Console.WriteLine("Folder is already created!");

            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            else Console.WriteLine("File is already created!");

            for(var i = 0; i < 1; i++)
            {
                using(var customWriter = new CustomWriter(filePath))
                {
                    customWriter.WriteLine($"[{DateTime.Now}] This is the first line", 1);
                    customWriter.WriteLine($"[{DateTime.Now}] This is the second line", 2);
                }
            }

            Thread.Sleep(3000);

            Thread.Sleep(3000);

        }
    }
}
