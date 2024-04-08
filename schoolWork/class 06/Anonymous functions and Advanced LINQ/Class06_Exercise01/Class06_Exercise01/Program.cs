using Models.Enums;
using Models;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Class06_Exercise01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>()
            {
                new Dog("Charlie", "Black", 3, BreedEnum.Collie), // 0
                new Dog("Buddy", "Brown", 1, BreedEnum.Doberman),
                new Dog("Max", "Olive", 1, BreedEnum.Plott),
                new Dog("Archie", "Black", 2, BreedEnum.Mutt),
                new Dog("Oscar", "White", 1, BreedEnum.Mudi),
                new Dog("Toby", "Maroon", 3, BreedEnum.Bulldog), // 5
                new Dog("Ollie", "Silver", 4, BreedEnum.Dalmatian),
                new Dog("Bailey", "White", 4, BreedEnum.Pointer),
                new Dog("Frankie", "Gray", 2, BreedEnum.Pug),
                new Dog("Jack", "Black", 5, BreedEnum.Dalmatian),
                new Dog("Chanel", "Black", 1, BreedEnum.Pug), // 10
                new Dog("Henry", "White", 7, BreedEnum.Plott),
                new Dog("Bo", "Maroon", 1, BreedEnum.Boxer),
                new Dog("Scout", "Olive", 2, BreedEnum.Boxer),
                new Dog("Ellie", "Brown", 6, BreedEnum.Doberman),
                new Dog("Hank", "Silver", 2, BreedEnum.Collie), // 15
                new Dog("Shadow", "Silver", 3, BreedEnum.Mudi),
                new Dog("Diesel", "Brown", 4, BreedEnum.Bulldog),
                new Dog("Abby", "Black", 1, BreedEnum.Dalmatian),
                new Dog("Trixie", "White", 8, BreedEnum.Pointer) // 19
            };

            List<Person> people = new List<Person>()
            {
                new Person("Nathanael", "Holt", 20, JobEnum.Choreographer),
                new Person("Rick", "Chapman", 35, JobEnum.Dentist),
                new Person("Oswaldo", "Wilson", 19, JobEnum.Developer),
                new Person("Kody", "Walton", 43, JobEnum.Sculptor),
                new Person("Andreas", "Weeks", 17, JobEnum.Developer),
                new Person("Kayla", "Douglas", 28, JobEnum.Developer),
                new Person("Richie", "Campbell", 19, JobEnum.Waiter),
                new Person("Soren", "Velasquez", 33, JobEnum.Interpreter),
                new Person("August", "Rubio", 21, JobEnum.Developer),
                new Person("Rocky", "Mcgee", 57, JobEnum.Barber),
                new Person("Emerson", "Rollins", 42, JobEnum.Choreographer),
                new Person("Everett", "Parks", 39, JobEnum.Sculptor),
                new Person("Amelia", "Moody", 24, JobEnum.Waiter)
                { Dogs = new List<Dog>() {dogs[16], dogs[18] } },
                new Person("Emilie", "Horn", 16, JobEnum.Waiter),
                new Person("Leroy", "Baker", 44, JobEnum.Interpreter),
                new Person("Nathen", "Higgins", 60, JobEnum.Archivist)
                { Dogs = new List<Dog>(){dogs[6], dogs[0] } },
                new Person("Erin", "Rocha", 37, JobEnum.Developer)
                { Dogs = new List<Dog>() {dogs[2], dogs[3], dogs[19] } },
                new Person("Freddy", "Gordon", 26, JobEnum.Sculptor)
                { Dogs = new List<Dog>() {dogs[4], dogs[5], dogs[10], dogs[12], dogs[13] } },
                new Person("Valeria", "Reynolds", 26, JobEnum.Dentist),
                new Person("Cristofer", "Stanley", 28, JobEnum.Dentist)
                { Dogs = new List<Dog>() {dogs[9], dogs[14], dogs[15] } }
            };
            var peopleDescendingWithR = people.Where(x => x.FirstName.StartsWith("R")).OrderByDescending(x => x.Age).ToList();
            PrintPeople(peopleDescendingWithR);

            Console.WriteLine("--------------------------------------------------------------------");

            var allBrownDogsOlderThan3YearsAsc = dogs.Where(x => x.Color == "Brown" && x.Age > 3).OrderBy(x => x.Age).Select(x => x.Name).ToList();
            allBrownDogsOlderThan3YearsAsc.ForEach(Console.WriteLine);

            Console.WriteLine("--------------------------------------------------------------------");

            var allPeopleWithMoreThan2Dogs = people.Where(x => x.Dogs.Count > 2).OrderByDescending(x => x.FirstName).ToList();
            PrintPeople(allPeopleWithMoreThan2Dogs);

            Console.WriteLine("--------------------------------------------------------------------");

            var freddy = people.FirstOrDefault(x => x.FirstName == "Freddy");
            var freddysDogsNamesOlderThan1 = freddy.Dogs.Where(x => x.Age > 1).Select(x => x.Name).ToList();
            freddysDogsNamesOlderThan1.ForEach(Console.WriteLine);

            Console.WriteLine("--------------------------------------------------------------------");

            var firstDogByNathan = people.FirstOrDefault(x => x.FirstName == "Nathen")?.Dogs.FirstOrDefault();
            Console.WriteLine(firstDogByNathan.GetInfo());

            Console.WriteLine("--------------------------------------------------------------------");

            var bunchOfPeoplesWhiteDogs = people.Where(x => x.FirstName == "Christofer" ||
                                                            x.FirstName == "Freddy" ||
                                                            x.FirstName == "Erin" ||
                                                            x.FirstName == "Amelia")
                                                .SelectMany(x => x.Dogs)
                                                .Where(x => x.Color == "White")
                                                .OrderBy(x => x.Name)
                                                .ToList();
            foreach(var dog in bunchOfPeoplesWhiteDogs) Console.WriteLine(dog.GetInfo());
        }

        static void PrintPeople(List<Person> list)
        {
            foreach (Person p in list)
            {
                Console.WriteLine(p.GetInfo());
            }
        }
    }
}
