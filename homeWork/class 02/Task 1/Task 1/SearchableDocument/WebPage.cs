namespace SearchableDocument
{
    public class WebPage : ISearchable
    {
        public string HtmlDocument { get; set; }
        public WebPage(string htmlDocument) 
        {
            HtmlDocument = htmlDocument;
        }
        public string Search(string word)
        {
            if (HtmlDocument.ToLower().Contains(word.ToLower())) return $"The word: \"{word}\" was found in the HTML document!";
            return $"The word: \"{word}\" wasn't found in the HTML document.";
        }
    }
}
