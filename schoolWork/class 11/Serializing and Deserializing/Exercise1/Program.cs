using Newtonsoft.Json;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Data";
            string filePath = $@"{folderPath}\dogs.json";

            if(!Directory.Exists(folderPath)) 
                Directory.CreateDirectory(folderPath);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            List<Dog> dogs = new();

            using (var sr = new StreamReader(filePath))
            {
                var content = sr.ReadToEnd();
                dogs = JsonConvert.DeserializeObject<List<Dog>>(content);

                if (dogs == null)
                {
                    dogs = new List<Dog>();
                }
            }

            while (true) 
            {
                var dogName = GetInput("Enter your dog's name:");
                var dogColor = GetInput("Enter your dog's color:");
                var dogAge = GetNumber("Enter your dog's age:");

                var dog = new Dog(dogName, dogColor, dogAge);
                dogs.Add(dog);

                switch(GetInput("Would you like to add another dog? (Y N)").ToUpper()) 
                {
                    case "Y":
                        continue;

                    case "N":
                    default:
                        break;
                }
                break;
            }

            using(var sw = new StreamWriter(filePath)) 
            {
                foreach(var dog in dogs)
                {
                    var jsonDog = JsonConvert.SerializeObject(dog);
                    sw.WriteLine(jsonDog);
                }
            }
        }
        static int GetNumber(string msg)
        {
            while (true)
            {
                if (int.TryParse(GetInput(msg), out int number)) return number;
                else Console.WriteLine("Please make sure to enter a number!");
                continue;
            }
        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write(msg);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) return input;
                else Console.WriteLine("Please don't leave empty inputs!");
                continue;
            }
        }
    }
}
