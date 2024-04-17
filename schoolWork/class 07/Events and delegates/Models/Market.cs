﻿namespace Models
{
    public class Market
    {
        public delegate void PromotionDelegate(Product p, int newPrice);
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }

        public event PromotionDelegate? Subscribers;//NotifyUsers
        public void Subscribe(PromotionDelegate func) 
        {
            if (Subscribers == null)
            {
                Subscribers = func;
            } else
            {
                Subscribers += func;
            }

        }
        public void Unsubscribe(PromotionDelegate func)
        {
            if(Subscribers != null)
            {
                Subscribers -= func;
            }
        }
        public void CreatePromotion()
        {
            var rnd = new Random();
            var index = rnd.Next(0, Products.Count);
            var productOnPromotion = Products[index];
            var newPriceDouble = productOnPromotion.Price * 0.8M;
            var newPrice = (int)Math.Round(newPriceDouble);
            Subscribers(productOnPromotion, newPrice);
        }
    }
}
