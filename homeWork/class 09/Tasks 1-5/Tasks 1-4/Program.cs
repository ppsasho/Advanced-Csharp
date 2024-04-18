namespace Tasks_1_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var alphabetList = new List<char>()
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
            var folder = "Files";
            var filePath = @$"{folder}\names.txt";

            if(!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            else Console.WriteLine("Folder is already created");

            File.WriteAllText(filePath, "");

            while (true)
            {
                var names = new List<string>();

                while (true)
                {
                    var name = GetInput("Enter a name: ");
                    names.Add(name);
                    switch(GetInput("Would you like to enter a new name? (Y N):").ToUpper())
                    {
                        case "Y": continue;

                        case "N":
                        default : break;
                    }
                    break;
                }

                File.AppendAllLines(filePath, names);

                using (var sr = new StreamReader(filePath))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line)) break;

                        Action<char> checkFileForNames = (letter) =>
                        {
                            if (line.ToLower().StartsWith(letter)){
                                string newFilePath = @$"{folder}\namesStartingWith_{letter.ToString().ToUpper()}.txt";
                                File.AppendAllText(newFilePath, $"{line}\n");
                            }
                        };
                        alphabetList.ForEach(checkFileForNames);
                    }
                    Console.WriteLine("All entered names have been filtered!");
                };

                switch(GetInput("Would you like to try again? (Y N): ").ToUpper())
                {
                    case "Y": continue;

                    case "N":
                    default: break;
                }
                break;
            }
        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input)) return input;
                    else Console.WriteLine("Please don't leave empty inputs.");
                    continue;
            }
        }
    }
}
