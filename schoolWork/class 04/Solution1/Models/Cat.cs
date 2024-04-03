namespace Models
{
    public class Cat : Pet
    {
        public bool IsLazy { get; set; }
        public int LivesLeft { get; set; }
        public Cat(string name, int age, int livesLeft, bool isLazy) : base(name, PetEnum.Cat, age)
        {
            LivesLeft = livesLeft;
            IsLazy = isLazy;
        }

        public override string GetInfo()
        {
            return $"Cat: {Name} ({Age}) - lives left: {LivesLeft}";
        }
    }
}
