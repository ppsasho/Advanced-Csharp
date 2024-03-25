namespace ConsoleApp
{
    public class Phrase
    {
        public string Word {  get; set; }
        public int Counter { get; set; }
        public Phrase(string word)
        {
            Word = word;
            Counter = 0;
        }
    }
}
