namespace Stream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\Store";
            string filePath = $@"{folderPath}\products.txt";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
                else Console.WriteLine("Folder already exists");

            if (!File.Exists(filePath))
                File.Create(filePath).Close();
                else Console.WriteLine("File already exists");

            //StreamWriter sw = new StreamWriter(filePath);
            //sw.Write("Welcome to my store");
            //sw.Close();
            if (!File.Exists(filePath))
            {
                using (var sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("Welcome to my store!");
                }

                using (var sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine("This is a really nice store!");
                    sw.WriteLine("Please check out all the discounts today!");
                    sw.WriteLine("Fresh bread to the right!");
                }
            }

            using (var sr = new StreamReader(filePath))
            {
                while (true)
                {
                    string s = sr.ReadLine();
                    Console.WriteLine(s);
                    Thread.Sleep(3000);
                    if (s == null) break;
                }
            }

        }
    }
}
