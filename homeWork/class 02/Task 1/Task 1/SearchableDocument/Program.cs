using System.Reflection.Metadata.Ecma335;

namespace SearchableDocument
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string document = "Meditation is a practice that offers numerous benefits for both the mind and body. By allowing individuals to cultivate mindfulness and awareness, meditation can help reduce stress levels and promote overall well-being. Research suggests that regular meditation practice can lead to improvements in focus, concentration, and cognitive function. Additionally, meditation has been shown to lower blood pressure, improve sleep quality, and boost immune function. With its ability to enhance self-awareness and promote relaxation, meditation serves as a valuable tool for managing daily stressors and fostering a greater sense of inner peace.";
            string webPage = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Welcome to My Website</title>\r\n</head>\r\n<body>\r\n\r\n<div>\r\n    <h1>Welcome to My Website</h1>\r\n    <p>This is a generic website. Feel free to explore!</p>\r\n</div>\r\n\r\n</body>\r\n</html>\r\n";
            ISearchable searchable;
            while (true) 
            {
                switch(GetInput("Would you like to search:\n1) Document\n2) WebPage\n\t"))
                {
                    case "1":
                        searchable = new Document(document);
                        break;
                    case "2":
                        searchable = new WebPage(webPage);
                        break;
                    default:
                        Console.WriteLine("Please choose one of the numbers.");
                        continue;
                }

                string word = GetInput("Enter the word you would like to search: ");
                Console.WriteLine(searchable.Search(word));

                switch(GetInput("Would you like to try searching again? (Y N): ").ToUpper())
                {
                    case "Y":
                        Console.Clear();
                        Console.WriteLine("Thanks for using Searchable!");
                        continue;
                    case "N":
                        Console.Clear();
                        Console.WriteLine("Thanks for using Searchable!");
                        break;
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
                if (input != "") return input;
                Console.WriteLine("Please don't leave empty fields!");
            }
        }
    }
}
