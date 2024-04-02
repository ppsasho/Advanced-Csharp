namespace Dog_Shelter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog1 = new(1, "Jake", "black");
            Dog dog2 = new(2, "Max", "beige");
            Dog dog3 = new(3, "Bay", "white");
            DogShelter.AddDog(dog1);
            DogShelter.AddDog(dog2);
            DogShelter.AddDog(dog3);
            Console.WriteLine(DogShelter.GetAllDogs());
        }
    }
}
