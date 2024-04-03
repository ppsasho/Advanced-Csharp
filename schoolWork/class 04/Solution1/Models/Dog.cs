namespace Models
{
    public class Dog : Pet
    {
        public bool GoodBoy { get; set; }
        public string FavoriteFood { get; set; }
        public Dog(string name, int age, bool goodBoy, string favoriteFood) : base(name, PetEnum.Dog, age)
        {
            GoodBoy = goodBoy;
            FavoriteFood = favoriteFood;
        }

        public override string GetInfo()
        {
            string result =  $"{Name} ({Age}) - favorite food = {FavoriteFood}.";

            if(GoodBoy) 
            {
                result += "He's a good boy.";
            }
            return result;
        }
    }
}
