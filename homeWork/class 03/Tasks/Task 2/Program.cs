namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car();
            Vehicle motorBike = new MotorBike();
            Vehicle boat = new Boat();
            Vehicle plane = new Airplane();

            Console.WriteLine(car.DisplayInfo());
            Console.WriteLine(motorBike.DisplayInfo());
            Console.WriteLine(boat.DisplayInfo());
            Console.WriteLine(plane.DisplayInfo());
            
            Console.WriteLine("\n" + car.Drive());
            Console.WriteLine(motorBike.Wheelie());
            Console.WriteLine(boat.Sail());
            Console.WriteLine(plane.Fly());
        }
    }
}
