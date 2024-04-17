namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectFolderPathAbsolute = @"C:\Users\Code\Desktop\G3\Sasho\A-CSharp\Advanced-Csharp\schoolWork\class 09\Reading and Writing on File System";
            string relativePath = @"..\Logs\file1.txt";

            List<string> students = new() { "Sasho", "Mario", "Luka", "Teodor", "Maxim" };

            var folderPath = @"..\Files";
            var filePath = $@"{folderPath}\test1.txt";

            Console.WriteLine(Directory.GetCurrentDirectory());

            Console.WriteLine(Directory.Exists(@"C:\Users\Code\Desktop\G3\Sasho\A-CSharp\Advanced-Csharp\schoolWork\class 07\Events and delegates"));

            if (!Directory.Exists(@"C:\Users\Code\Desktop\G3\Sasho\A-CSharp\Advanced-Csharp\schoolWork\class 07\Events and delegates")) 
                Directory.CreateDirectory(@"C:\Users\Code\Desktop\G3\Sasho\A-CSharp\Advanced-Csharp\schoolWork\class 09\Logs");

                else Console.WriteLine("The folder already exists in the given location");

            if (!Directory.Exists(@"..\Files")) 
                Directory.CreateDirectory(@"..\Files");
                else Console.WriteLine("Folder named Files already exists");

            if (!File.Exists(@"..\Files\test1.txt"))
            {
                FileStream file = File.Create(@"..\Files\test1.txt");
                file.Close();
                File.WriteAllText(filePath, "Hello my friend");
            }   else Console.WriteLine("File named test1.txt already exists");

            File.AppendAllLines(filePath, students);

            var textLines = File.ReadAllLines(filePath).ToList();

            var newTextLines = textLines.Select((x, index) => $"{index + 1}. {x}").ToList();
            File.WriteAllLines(filePath, newTextLines);



        }
    }
}
