using Models;
using Storage;
namespace Services
{
    public class UI
    {
        private readonly UserData _storage = new(); 
        public UI() {} 

        private void ConsoleSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void ConsoleError(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private void DefaultOption()
        {
            Console.Clear();
            Console.WriteLine("Please make sure you choose one of the options.");
        }
        private bool DefaultMessage()
        {
            DefaultOption();
            return false;
        }
        private string Greet()
        {
            return $"Welcome {CurrentSession.CurrentUser?.Username}!";
        }
        public bool Welcome()
        {
            while(true)
            {
                switch(UserServices.GetInput("Welcome to TimeTracking!\nDo you want to:\n1) Sign in\n2) Register"))
                {
                    case "1":
                        return SignIn();

                    case "2":
                        return Register();

                    default:
                        return DefaultMessage();
                }
            }
        }

        private bool Register()
        {
            Console.WriteLine("Welcome to the register menu!");
            while (true)
            {
                string firstName = UserServices.GetInput("Enter your first name:");
                string lastName = UserServices.GetInput("Enter your last name:");
                int age = UserServices.GetNumber("Enter your age:");
                string username = UserServices.GetInput("Enter your username:");
                try
                {
                    if (_storage.Users.GetAll().Any(x => x.Username == username)) throw new ArgumentException("This username already exists!");
                    string password = UserServices.GetInput("Enter your Password:");

                    User user = new(firstName, lastName, age, username, password);

                    if (user != null)
                    {
                        _storage.Users.Add(user);
                        CurrentSession.Set(user);
                        return LogIn();
                    }
                }
                catch(Exception ex)
                {
                    ConsoleError($"{ex}");
                }
            }
        }

        private bool SignIn()
        {
            var users = _storage.Users.GetAll();
            for(int i = 0; i < 3; i++)
            {
                try
                {
                    string username = UserServices.GetInput("Enter your username:");
                    if (!users.Any(x => x.Username == username)) throw new ArgumentException("No user with that username exists!");

                    string password = UserServices.GetInput("Enter your password:");
                    if (!users.Any(x => x.Username == username && x.Password == password)) throw new ArgumentException("The entered password is incorrect!");

                    User user = users.First(x => x.Username == username);
                    CurrentSession.Set(user);
                    if(!user.IsActive)
                    {
                        Console.Clear();
                        Console.WriteLine("Your account is disabled!");
                        switch(UserServices.GetInput("Would you like to reactivate your account? (Y / N):").ToUpper())
                        {
                            case "Y":
                                CurrentSession.CurrentUser.ActivateAccount();
                                _storage.Users.Update(CurrentSession.CurrentUser);

                                Console.Clear();
                                ConsoleSuccess("You successfully reactivated your account!");
                                break;

                            case "N":
                            default:
                                CurrentSession.Remove();
                                return false;
                        }
                    }
                    
                    return LogIn();
                }
                catch(Exception ex)
                {
                    ConsoleError(ex.ToString());
                }
            }
            ConsoleError("You failed to sign in 3 times!\nPlease try again later.");
            return false;
        }
        private bool LogIn()
        {
            ConsoleSuccess(Greet());
            while (true)
            {
                switch(UserServices.GetInput("Would you like to:\n1) Track\n2) User statistics\n3) Account management\n4) Log out"))
                {
                    case "1":
                        return Track();

                    case "2":
                        return UserStatistics();

                    case "3":
                        return AccountManagement();

                    case "4":
                        Console.Clear();
                        return UserServices.LogOut();
                }
            }
        }
        private bool Track()
        {
            ConsoleSuccess(Greet());
            while (true)
            {
                switch(UserServices.GetInput("Would you like to track your:\n1) Reading\n2) Exercising\n3) Working\n4) Create your activity\n5) Go back"))
                {
                    case "1":
                        return Reading();

                    case "2":
                        return Exercising();
                        
                    case "3":
                        return Working();

                    case "4":
                        return CreateCustomActivity();

                    case "5":
                        Console.Clear();
                        return LogIn();

                    default:
                        DefaultOption();
                        continue;

                }
            }
        }

        private bool CreateCustomActivity()
        {
            string name = UserServices.GetInput("Enter the name for your activity:");

            var start = UserServices.StartActivity();

            var end = UserServices.EndActivity();

            var customInfo = UserServices.GetInput("Enter a description for your activity :] \n\t:");

            Hobby hobby = new(start, end, name, "hobby", customInfo);
            CurrentSession.CurrentUser.Hobbies.Add(hobby);
            _storage.Users.Update(CurrentSession.CurrentUser);

            Console.Clear();
            Console.WriteLine("Activity successfully ended!");
            return LogIn();

        }

        private bool Working()
        {
            while (true)
            {
                string type;
                switch (UserServices.GetInput("Where are you working?\n1) At the office\n2) From home"))
                {
                    case "1":
                        type = "At the office";
                        break;

                    case "2":
                        type = "From home";
                        break;

                    default:
                        DefaultOption();
                        continue;
                }

                var start = UserServices.StartActivity();

                var end = UserServices.EndActivity();

                Working work = new(start, end, type);
                CurrentSession.CurrentUser.Workings.Add(work);
                _storage.Users.Update(CurrentSession.CurrentUser);

                Console.Clear();
                Console.WriteLine("Activity successfully ended!");
                return LogIn();
            }
        }

        private bool Exercising()
        {
            while (true)
            {
                string type;
                switch (UserServices.GetInput("What type of exercise is it?\n1) General\n2) Running\n 3) Sport"))
                {
                    case "1":
                        type = "General";
                        break;

                    case "2":
                        type = "Running";
                        break;

                    case "3":
                        type = "Sport";
                        break;

                    default:
                        DefaultOption();
                        continue;
                }

                var start = UserServices.StartActivity();

                var end = UserServices.EndActivity();

                Exercising exercise = new(start, end, type);
                CurrentSession.CurrentUser.Exercises.Add(exercise);
                _storage.Users.Update(CurrentSession.CurrentUser);

                Console.Clear();
                Console.WriteLine("Activity successfully ended!");
                return LogIn();
            }
        }

        private bool Reading()
        {
            while (true)
            {
                string type;
                switch(UserServices.GetInput("What book genre are you reading?\n1) Belles Lettres\n2) Fiction\n 3) Professional Literature"))
                {
                    case "1":
                        type = "Belles Lettres";
                        break;

                    case "2":
                        type = "Fiction";
                        break;

                    case "3":
                        type = "Professional Literature";
                        break;

                    default:
                        DefaultOption();
                        continue;
                }

                var start = UserServices.StartActivity();

                var end = UserServices.EndActivity();

                var pages = UserServices.GetNumber("How many pages did you read?");

                Reading read = new(start, end, type, pages);
                CurrentSession.CurrentUser.Readings.Add(read);
                _storage.Users.Update(CurrentSession.CurrentUser);

                Console.Clear();
                Console.WriteLine("Activity successfully ended!");
                return LogIn();
            }
        }

        private bool AccountManagement()
        {
            ConsoleSuccess(Greet());
            while(true)
            {
                switch(UserServices.GetInput("Would you like to:\n1) Change your first name\n2) Change your last name\n3) Change your password\n4) Deactivate account\n5) Go back"))
                {
                    case "1":
                        Console.WriteLine($"Your current name: {CurrentSession.CurrentUser.FirstName}");
                        CurrentSession.CurrentUser?.ChangeFirstName(UserServices.GetInput("Enter your new first name:"));
                        _storage.Users.Update(CurrentSession.CurrentUser);
                        ConsoleSuccess("First name changed successfully!");
                        break;

                    case "2":
                        Console.WriteLine($"Your current last name: {CurrentSession.CurrentUser.LastName}");
                        CurrentSession.CurrentUser?.ChangeLastName(UserServices.GetInput("Enter your new last name:"));
                        _storage.Users.Update(CurrentSession.CurrentUser);
                        ConsoleSuccess("Last name changed successfully!");
                        break;

                    case "3":
                        CurrentSession.CurrentUser?.SetPassword(UserServices.GetInput("Enter your new password:"));
                        _storage.Users.Update(CurrentSession.CurrentUser);
                        ConsoleSuccess("Password changed successfully!");
                        break;

                    case "4":
                        CurrentSession.CurrentUser.DeactivateAccount();
                        _storage.Users.Update(CurrentSession.CurrentUser);
                        CurrentSession.Remove();
                        ConsoleSuccess("Account disabled successfully");
                        return Welcome();

                    case "5":
                        Console.Clear();
                        return LogIn();

                    default:
                        DefaultOption();
                        continue;
                }
                switch(UserServices.GetInput("Would you like to change something else? ( Y / N): ").ToUpper()) 
                {
                    case "Y":
                        Console.Clear();
                        continue;

                    case "N":
                    default:
                        Console.Clear();
                        return LogIn();
                }
            }
        }

        private bool UserStatistics()
        {
            ConsoleSuccess(Greet());
            while (true)
            {
                switch(UserServices.GetInput("What activity would you like to view?\n1) Reading\n2) Exercising\n3) Working\n4) Hobbies\n5) Global\n6) Go back"))
                {
                    case "1":
                        return ReadingInfo();

                    case "2":
                        return ExercisingInfo();

                    case "3":
                        return WorkingInfo();

                    case "4":
                        return HobbiesInfo();

                    case "5":
                        return GlobalInfo();
                    case "6":
                        Console.Clear();
                        return LogIn();
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }

        private bool GlobalInfo()
        {
            Console.Clear();
            Console.WriteLine($"Total time of all activities: {CurrentSession.CurrentUser.GetGlobalTime()} hours");
            Console.WriteLine($"Favorite activity: {CurrentSession.CurrentUser.GetFavoriteActivity()}");

            UserServices.PressEnterToGoBack();
            return LogIn();
        }

        private bool HobbiesInfo()
        {
            Console.Clear();
            Console.WriteLine("Total hobby time: ", CurrentSession.CurrentUser.TotalHobbyTime(), "hours");
            Console.WriteLine("Hobbies:\n", CurrentSession.CurrentUser.GetHobbyNames());

            UserServices.PressEnterToGoBack();
            return LogIn();
        }

        private bool WorkingInfo()
        {
            Console.Clear();
            Console.WriteLine($"Total Working time: {CurrentSession.CurrentUser.GetTotalWorkingTime()} hours");
            Console.WriteLine($"Avarage working time:  {CurrentSession.CurrentUser.GetAvgWorkingTime()} minutes");
            Console.WriteLine($"Favorite working type: {CurrentSession.CurrentUser.GetFavoriteWorkingType()}");

            UserServices.PressEnterToGoBack();
            Console.Clear();
            return LogIn();
        }

        private bool ExercisingInfo()
        {
            Console.Clear();
            Console.WriteLine($"Total exercising time: {CurrentSession.CurrentUser.GetTotalExercisingTime()} hours");
            Console.WriteLine($"Avarage exercising time: {CurrentSession.CurrentUser.GetAvgExercisingTime()} minutes");
            Console.WriteLine($"Favorite type: {CurrentSession.CurrentUser.GetFavoriteExercisingType()}");

            UserServices.PressEnterToGoBack();
            return LogIn();
        }

        private bool ReadingInfo()
        {
            Console.Clear();
            Console.WriteLine($"Total reading time: {CurrentSession.CurrentUser.GetTotalReadingTime()} hours");
            Console.WriteLine($"Avarage reading time: {CurrentSession.CurrentUser.GetAvgReadingTime()} minutes");
            Console.WriteLine($"Total pages: {CurrentSession.CurrentUser.GetTotalPages()}");
            Console.WriteLine($"Favorite reading type: {CurrentSession.CurrentUser.GetFavoriteReadingType()}");

            UserServices.PressEnterToGoBack();
            return LogIn();
        }
    }
}
