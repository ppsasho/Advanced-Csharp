namespace Dog_Shelter
{
    public static class DogShelter
    {
        public static List<Dog> Dogs {  get; set; } = new List<Dog>();

        public static void AddDog(Dog dog)
        {
            if (Helper.Validate(dog)) Dogs.Add(dog);
            else throw new Exception("Dog object isn't valid.");
        }
        public static string GetAllDogs()
        {
            string result = string.Empty;

            List<String> dogsBark = Dogs.Select(x => x.Bark()).ToList();
            return string.Join("\n", dogsBark);
        }
    }
}
