namespace Models
{
    public class Fish : Pet
    {

        public decimal Size { get; set; }
        public string Color { get; set; }
        public Fish(string name, PetEnum type, int age, decimal size, string color) : base(name, type, age)
        {
            Size = size;
            Color = color;
        }
        public override string GetInfo()
        {
            return $"Fish: {Name} ({Age}) - {Color}";
        }
    }
}
