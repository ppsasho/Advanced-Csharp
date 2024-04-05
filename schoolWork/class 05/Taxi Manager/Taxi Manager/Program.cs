using DataAcess;
using Models;

namespace Taxi_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage.Users.Add(new User(0, "Sasho", "Popovski", "ppsasho", Models.Enum.RoleEnum.Admin, "sashopp1234"));

            var users = Storage.Users.GetAll();
            foreach (var user in users) Console.WriteLine(user.Username);
            var cars = Storage.Cars.GetAll();
        }
    }
}
