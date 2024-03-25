namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phrase> phrases = new();
            while (true)
            {
                string input = GetInput("Enter a word: (enter x to stop)");
                if (input.ToUpper() == "X") break;
                if (input.Contains(' '))
                {
                    Console.WriteLine("Only enter one word, spaces aren't allowed");
                    continue;
                }
                if(phrases.Any(x => x.Word == input))
                {
                    Console.WriteLine("You already entered that word.");
                    continue;
                }
                Phrase newPhrase = new(input);
                phrases.Add(newPhrase);

                string sentence = GetInput("Enter your sentence:");

                foreach (Phrase phrase in phrases) if (sentence.ToLower().Contains(phrase.Word.ToLower())) phrase.Counter++;
                foreach (Phrase phrase in phrases) Console.WriteLine($"{phrase.Word}: {phrase.Counter} occurances");

                switch (GetInput("Would you like to try again? (Y X):"))
                {
                    case "y":
                        phrases = new List<Phrase>();
                        continue;
                    case "x":
                    default:
                        break;
                }
                break;
            }
        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                string input = Console.ReadLine();
                if (input != "") return input;
                Console.WriteLine("Please don't leave empty fields!");
                continue;
            }
        }
    }
}
