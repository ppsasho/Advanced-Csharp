namespace Models
{
    public class Consumer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public CategoryEnum FavoriteCategory { get; set; }
        public void NewPromotion(Product product, int newPrice)
        {
            Console.WriteLine($"{FullName} has received a promotion about {product.Name} with a new price of {newPrice}");

            if(FavoriteCategory.Equals( product.Category ) ) 
            {
                Console.WriteLine($"{FullName}: This is a good day.");
            }
            if(FavoriteCategory.Equals( CategoryEnum.All))
            {
                Console.WriteLine($"{FullName}: Every day is a good day.");
            }
        }

    }
}
