using Models;
using Models.Enums;
using System.Reflection.Metadata;

namespace TryBeingFit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (!UI());
        }
        static string GetInput(string msg)
        {
            while (true)
            {
                Console.Write($"{msg}\n\t");
                string input = Console.ReadLine();
                if(!string.IsNullOrEmpty(input)) return input;
                Console.WriteLine("Please don't leave empty inputs!");
                continue;
            }
        }
        static bool DefaultMessage()
        {
            Console.WriteLine("Please make sure you choose one of the options.");
            return false;
        }
        static User UpgradeUser(User user)
        {
            user.AccountType = AccountType.Premium;
            Console.WriteLine("You were successfully upgraded to premium!");
            return user;
        }
        static string GetVideoTrainings()
        {
            string result = string.Empty;
            foreach(var video in Data.VideoTrainings) result+= $"ID: {video.Id}\n{video.Title}\n";
            return result;
        }
        static bool VideoTrain()
        {
            Console.WriteLine("Videos:\n");
            Console.WriteLine(GetVideoTrainings());
            Console.ReadLine();
            return false;
        }

        static bool StandardLogIn(User user)
        {
            while(true)
            {
                Console.WriteLine($"Welcome {user.FirstName}!(Standard user)");
                switch (GetInput("Would you like to:\n1) Train\n2) Upgrade to premium\n3) Log out"))
                {
                    case "1":
                        Console.Clear();
                        return VideoTrain();
                    case "2":
                        Console.Clear();
                        return PremiumLogIn(UpgradeUser(user));
                    case "3":
                        Console.Clear();
                        return false;
                    default:
                        return DefaultMessage();
                }
            }
        }
        static bool PremiumLogIn(User user)
        {
            Console.WriteLine($"Welcome {user.FirstName}!(Premium user)");
            Console.ReadLine();
            return false;
        }
        static bool SignIn()
        {
            while(true)
            {
                string username = GetInput("Enter your username:");
                if(username.Length < 6)
                {
                    Console.WriteLine("The username you entered is shorter than the minimal requirement(6 chrs)");
                    continue;
                } if(!Data.Users.Any(x => x.Username.ToLower() == username.ToLower())) {
                    Console.WriteLine("This username doesn't exist!");
                    continue;
                }
                while (true)
                {
                    string password = GetInput("Enter your password:");
                    if (Data.Users.Any(x => x.Username.ToLower() == username.ToLower() && x.CheckPassword(password))){
                        User user = Data.Users.First(x => x.Username == username);
                            switch (user.AccountType)
                            {
                                case AccountType.Standard:
                                    return StandardLogIn(user);
                                case AccountType.Premium:
                                    return PremiumLogIn(user);
                            }
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("The password you entered is incorrect.");
                        continue;
                    }
                }

            }
        }
        static bool Register()
        {
            while (true)
            {
                string firstName = GetInput("Enter your first name:");
                string lastName = GetInput("Enter your last name:");
                if(firstName.Length < 2 || lastName.Length < 2) 
                {
                    Console.Clear();
                    Console.WriteLine("Your names must not be shorter than 2 chrs");
                    continue;
                }
                while(true)
                {
                    string username = GetInput("Enter your username:");
                    if(username.Length < 6)
                    {
                        Console.WriteLine("Your username must contain at least 6 chrs.");
                        continue;
                    } else if(Data.Users.Any(x => x.Username == username))
                    {
                        Console.WriteLine("That username already exists!");
                        continue;
                    }
                    string password = GetInput("Enter your password");
                    User user = new StandardUser(firstName, lastName, username, password);
                    Data.Users.Add(user);
                    Console.WriteLine("User successfully created!");
                    switch(GetInput("Would you like to login with your new account? (Y N)").ToUpper())
                    {
                        case "Y":
                            Console.Clear();
                            return StandardLogIn(user);
                        case "N":
                            Console.Clear();
                            return false;
                    }
                }
                
            }
        }
        static bool UI()
        {
            while(true)
            {
                Console.WriteLine("Welcome to Try Being Fit!");
                switch(GetInput("Are you a:\n1) User\n2) Trainer")) 
                {
                    case "1":
                        Console.Clear();
                        switch(GetInput("Do you want to:\n1) Log in\n2) Register"))
                        {
                            case "1":
                                return SignIn();
                            case "2":
                                return Register();
                            default:
                                return DefaultMessage();
                        }
                    case "2":
                    default:
                        return DefaultMessage();
                }
            }
        }
    }
}
