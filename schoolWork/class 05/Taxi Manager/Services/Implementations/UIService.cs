using DataAcess;
using Models.Enum;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UIService : IUIService
    {
        private IUserService _userService;
        public UIService()
        {
            _userService = new UserService();
        }
        public void Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please login!");
                    Console.Write("Username:");
                    var username = Console.ReadLine();

                    Console.WriteLine("Password: ");
                    var password = Console.ReadLine();

                    _userService.Login(username, password);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successfull Login! Welcome {CurrentSession.User.FirstName} user: [{CurrentSession.User.Role}]");
                    Console.ForegroundColor= ConsoleColor.White;
                    break;
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Please try again;");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }

        public void LogOut()
        {
            Console.WriteLine("Thank you for using our app!");
            _userService.LogOut();
        }
        private void ShowAdminMenu()
        {
            Console.WriteLine("1. Create new user");
            Console.WriteLine("2. Terminate user");
            Console.WriteLine("3. Log out");
            int option = ChooseAnOption(1, 3);
        }
        private void CreateNewUser()
        {
            Console.WriteLine("Please add info for the new user!");
            Console.WriteLine("First name: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Username: ");
            var username = Console.ReadLine();

            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Select role (1. Admin; 2. Maintenance; 3. Manager; 4. Driver");
            var roleNumber = ChooseAnOption((int)RoleEnum.Admin, (int)RoleEnum.Driver);

            if(roleNumber == (int)RoleEnum.Driver) 
            {
                Console.WriteLine("License number: ");
                var licenseNumber = Console.ReadLine();

                Console.WriteLine("License expiry date: ");
                var licenseExpiryDate = Console.ReadLine();
            }


        }
        private int ChooseAnOption(int min, int max)
        {
            while(true)
            {
                Console.WriteLine("Please choose an option: ");
                var input = Console.ReadLine();

                if(!int.TryParse(input, out int number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if(number >= min && number <= max)
                {
                    return number;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong option, please select between the minimun {min} and maximum {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

            }
        }
    }
}
