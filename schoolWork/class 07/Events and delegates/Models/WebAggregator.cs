namespace Models
{
    public class WebAggregator
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public void NewMarketPromotion(Product p, int price)
        {
            Console.WriteLine($"The product {p.Name} has a new price {price}. this will be presente on our website for everyone.");
        }
    }
}
