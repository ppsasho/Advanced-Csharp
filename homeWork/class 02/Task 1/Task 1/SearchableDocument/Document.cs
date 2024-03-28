namespace SearchableDocument
{
    public class Document : ISearchable
    {
        public string TextDocument { get; set; }
        public Document(string textDocument)
        {
            TextDocument = textDocument;
        }
        public string Search(string word)
        {
            if (TextDocument.ToLower().Contains(word.ToLower())) return $"The word: \"{word}\" was found in the text document!";
            return $"The word: \"{word}\" was not found in the text document.";
        }
    }
}
