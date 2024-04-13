using Models;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Market supermarket = new Market()
            {
                Name = "Tinex",
                Products = new() {
                new Product {
                Name = "Chips",
                Price = 60,
                Category = CategoryEnum.Snack },
                new Product
                {
                    Name = "Cheese",
                    Price = 150,
                    Category = CategoryEnum.Milk,
                }
            }
            };
            Consumer consumer = new Consumer() { FirstName = "Sasho", LastName = "Popovski", FavoriteCategory = CategoryEnum.All };
            Consumer consumer2 = new Consumer() { FirstName = "Nikola", LastName = "Nikolovski", FavoriteCategory = CategoryEnum.Milk };
            supermarket.Subscribe(consumer.NewPromotion);
            supermarket.Subscribe(consumer2.NewPromotion);
            supermarket.CreatePromotion();

        }
    }
}
