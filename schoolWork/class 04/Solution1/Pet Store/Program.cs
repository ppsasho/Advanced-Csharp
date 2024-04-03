using Models;

namespace Pet_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Dog("Aron", 10, true, "Mandza");
            var d2 = new Dog("Max", 4, false, "Meso");
            var dogStore = new PetStore<Dog>("Doggy Store");

            var c1 = new Cat("Maco", 6, 7, true);
            var c2 = new Cat("Luke", 4, 9, false);
            var catStore = new PetStore<Cat>("Cat Store");
            dogStore.AddPet(d1);
            dogStore.AddPet(d2);
            //dogStore.AddPet(d2);

            Console.WriteLine(dogStore.GetPets());
            dogStore.BuyPet("aron");
        }
    }
}
