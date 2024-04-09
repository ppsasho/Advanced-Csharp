using System.Security.Cryptography.X509Certificates;

namespace Filtered_Results
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var allCarsFromEurope = CarsData.Cars.Where(x => x.Origin == "Europe").ToList();
            //PrintCars(allCarsFromEurope);

            var sixAndFourCylinderCars = CarsData.Cars.Where(x => x.Cylinders > 6 || (x.Cylinders == 4 && x.HorsePower > 110)).ToList();
            //PrintCars(sixAndFourCylinderCars);

            var originCounts = CarsData.Cars.GroupBy(x => x.Origin)
                                            .Select(group => new
                                            {
                                                Origin = group.Key,
                                                Count = group.Count()
                                            })
                                            .OrderBy(x => x.Origin);
            foreach (var origin in originCounts) Console.WriteLine(origin);

            var carsWith200HP = CarsData.Cars.Where(x => x.HorsePower > 200);
            var carWithLowestMPG = carsWith200HP.MinBy(x => x.MilesPerGalon);
            var carWithHighestMPG = carsWith200HP.MaxBy(x => x.MilesPerGalon);
            var avgMPG = carsWith200HP.Select(x => x.MilesPerGalon).Sum() / carsWith200HP.Count();
            Console.WriteLine($"Lowest MPG: {carWithHighestMPG?.Model}\nHighest MPG: {carWithLowestMPG?.Model}\nAvg MPG: {avgMPG}");

            List<Car> top3Cars = new();
            var fastestCars = CarsData.Cars.OrderByDescending(x => x.AccelerationTime);
            foreach (Car car in fastestCars) if (top3Cars.Count > 2) break; else top3Cars.Add(car);
            Console.WriteLine("Top 3 cars:");
            PrintCars(top3Cars);

            var sixPlusCylinderCarsWeight = CarsData.Cars.Where(x => x.Cylinders > 6).Select(x => x.Weight).Sum();
            Console.WriteLine($"Total weight: {sixPlusCylinderCarsWeight}");

            var EvenCylinders = CarsData.Cars.Where(x => x.Cylinders % 2 == 0).Select(x => x.MilesPerGalon);
            var avgMPGForEvenCylinders = Math.Round(EvenCylinders.Sum() / EvenCylinders.Count());
            Console.WriteLine($"Avg MPG for cars with even cylinder amount: {avgMPGForEvenCylinders}");
        }
        static void PrintCars(IEnumerable<Car> cars) 
        {
            foreach (var car in cars) Console.WriteLine($"{car.GetCarInfo()}\n");
        }
    }
}
