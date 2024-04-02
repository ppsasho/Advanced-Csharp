namespace Extension_Methods
{
    public static class StringHelper
    {
        public static string AddQuotes(this string s)
        {
            return $"\" {s} \"";
        }
        public static string RemoveWordsFromBeginning(this string text, int wordNumber)
        {
            if(string.IsNullOrEmpty(text)) throw new Exception("Empty string");
            List<string> words = text.Split(" ").ToList();

            if (words.Count < wordNumber) throw new Exception($"That text has less words than {wordNumber} words");
            List<string> restOfWords = words.Skip(wordNumber).Take(words.Count - wordNumber).ToList();
            return string.Join(" ", restOfWords);
        }
    }
}
