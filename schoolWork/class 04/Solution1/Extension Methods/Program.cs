namespace Extension_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello Sasho, welcome to our webpage :)";
            string newText = text.RemoveWordsFromBeginning(3);

            string unquotedText = "This text is unquoted";
            Console.WriteLine(unquotedText);

            string quotedString = unquotedText.AddQuotes();
            Console.WriteLine(quotedString);

            Console.WriteLine($"Unchanged text: \n{text}");
            Console.WriteLine($"New text where 3 words are removed from the beginning: \n{newText}");
        }
    }
}
