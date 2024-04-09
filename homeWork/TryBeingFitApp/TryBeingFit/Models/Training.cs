namespace Models
{
    public abstract class Training
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public decimal Rating { get; set; }
        public int Id { get; set; }
        public Training(string link, string title, int id)
        {
            Link = link;
            Title = title;
            Rating = 0;
            Id = id;
        }
        public string GetInfo()
        {
            return $"Title: {Title}\nLink: {Link}\t({DisplayRating()})";
        }
        public string DisplayRating()
        {
            if (Rating == 0) return $"There are no ratings yet.";
            return Rating.ToString();
        }
        public void ChangeRating(decimal rating)
        {
            if (Rating == 0) Rating = rating;
            else Rating += rating / 2;
        }
    }
}
