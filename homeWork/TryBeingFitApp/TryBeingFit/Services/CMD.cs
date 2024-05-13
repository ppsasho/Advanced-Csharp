using Models.Enums;
using Storage;

namespace Models
{
    public class CMD
    {
        private readonly Data2 _storage = new();
        public void DefaultOption()
        {
            Console.Clear();
            Console.WriteLine("Please make sure you choose one of the options.");
        }

        public string GetLiveTrainings()
        {
            var liveTrainings = _storage.ReadLiveTrainings();
            if (!liveTrainings.Any())
            {
                Console.WriteLine($"There are no live trainings scheduled, please check again later.");
                switch (CurrentSession.User.AccountType)
                {
                    case AccountType.Standard:
                        StandardLogIn();
                        break;
                    case AccountType.Premium:
                        PremiumLogIn();
                        break;
                    case AccountType.Trainer:
                        TrainerLogIn();
                        break;
                }
            }
            string result = string.Empty;
            foreach (var training in liveTrainings) result += $"\n(ID: {training.Id})\t[{training.Title}] {training.GetRemainingTime()}\n";
            return result;
        }
        public bool MoreLiveInfo()
        {
            User user = CurrentSession.User;
            var liveTrainings = _storage.ReadLiveTrainings();
            while (true)
            {
                int id = UserServices.GetNumber("Enter the id of the live training that you want to participate in:");
                if (!liveTrainings.Any(x => x.Id.Equals(id)))
                {
                    Console.WriteLine("The id you entered doesn't exist in the list of live trainings");
                    continue;
                }

                LiveTraining live = liveTrainings.First(x => x.Id.Equals(id));
                Console.WriteLine(live.GetInfo());
                switch (UserServices.GetInput("Do you want to:\n1) Get added to the participants list?\n2) Go back to the Live trainings menu"))
                {
                    case "1":
                        liveTrainings[liveTrainings.IndexOf(live)].Participants.Add(user);
                        _storage.Update(live);
                        Console.Clear();
                        Console.WriteLine("You have been added to the live training successfully!");
                        return LiveTrain();
                    case "2":
                        Console.Clear();
                        return LiveTrain();
                    default:
                        DefaultOption();
                        continue;
                }

            }
        }
        public bool LiveTrain()
        {
            User user = CurrentSession.User;
            while (true)
            {
                Console.WriteLine(GetLiveTrainings());
                switch (UserServices.GetInput("Would you like to:\n1) Participate in a live training\n2) Go back to your profile"))
                {
                    case "1":
                        return MoreLiveInfo();

                    case "2":
                        switch (user.AccountType)
                        {
                            case AccountType.Standard:
                                Console.Clear();
                                return StandardLogIn();

                            case AccountType.Premium:
                                Console.Clear();
                                return PremiumLogIn();

                            case AccountType.Trainer:
                                Console.Clear();
                                return TrainerLogIn();
                        }
                        break;

                    default:
                        DefaultOption();
                        continue;
                }
            }
        }

        
        public bool CreateLiveTraining()
        {
            User trainer = CurrentSession.User;
            while (true)
            {
                string title = UserServices.GetInput("Enter the title for your training:");
                string link = UserServices.GetInput("Enter the link for your live training:");
                DateTime date = UserServices.GetDateTime("Enter the date for your live training(dd/MM/yyyy HH:mm:ss):");

                LiveTraining live = new(link, title, date, trainer);
                _storage.AddLive(live);
                switch (UserServices.GetInput("Would you like to:\n1) Create another live training\n2) Go back to your profile"))
                {
                    case "1":
                        Console.Clear();
                        continue;
                    case "2":
                        Console.Clear();
                        return TrainerLogIn();
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }
        public bool RescheduleTraining()
        {
            User trainer = CurrentSession.User;
            var liveTrainings = _storage.ReadLiveTrainings();
            while (true)
            {
                var trainerLiveTrainings = liveTrainings.Where(x => x.Trainer.Username.Equals(trainer.Username));
                if (!trainerLiveTrainings.Any())
                {
                    switch (UserServices.GetInput("There are no live training made by you, would you like to:\n1) Create a live training\n2) Go back to your profile"))
                    {
                        case "1":
                            return CreateLiveTraining();
                        case "2":
                            return TrainerLogIn();
                        default:
                            DefaultOption();
                            continue;
                    }
                }
                foreach (var item in trainerLiveTrainings) Console.WriteLine($"(ID {item.Id}) - {item.GetInfo()}");
                int id = UserServices.GetNumber("Enter the Id of the training you want to reschedule:");
                if (!trainerLiveTrainings.Any(x => x.Id.Equals(id)))
                {
                    Console.Clear();
                    Console.WriteLine("Please check that you entered a valid Id!");
                    continue;
                }
                LiveTraining live = trainerLiveTrainings.First(x => x.Id.Equals(id));
                liveTrainings[liveTrainings.IndexOf(live)].ReSchedule(UserServices.GetDateTime("Enter the new date for your training.\nPlease follow this format (dd/MM/yyyy HH:mm:ss):"));
                _storage.Update(live);
                Console.WriteLine("Training successfully rescheduled");
                switch (UserServices.GetInput("Would you like to:\n1) Reschula a live training again\n2) Go back to your profile"))
                {
                    case "1":
                        Console.Clear();
                        continue;

                    case "2":
                    default:
                        Console.Clear();
                        return TrainerLogIn();
                }
            }
        }
        public bool UI()
        {
            Console.WriteLine("Welcome to Try Being Fit!");
            switch (UserServices.GetInput("Are you a:\n1) User\n2) Trainer"))
            {
                case "1":
                    Console.Clear();
                    switch (UserServices.GetInput("Do you want to:\n1) Log in\n2) Register"))
                    {
                        case "1":
                            Console.Clear();
                            return SignIn("user");

                        case "2":
                            Console.Clear();
                            return Register();

                        default:
                            Console.Clear();
                            return DefaultMessage();
                    }
                case "2":
                    Console.Clear();
                    return SignIn("trainer");
                default:

                    return DefaultMessage();
            }
        }
        

        public bool DefaultMessage()
        {
            DefaultOption();
            return false;
        }
        
        public string Welcome()
        {
            return $"Welcome {CurrentSession.User.FirstName}!";
        }

        public bool StandardLogIn()
        {
            User user = CurrentSession.User;
            while (true)
            {
                Console.WriteLine(Welcome());
                switch (UserServices.GetInput("Would you like to:\n1) Train\n2) Upgrade to premium\n3) Account\n4) Log out"))
                {
                    case "1":
                        Console.Clear();
                        return VideoTrain();
                    case "2":
                        Console.Clear();
                        UpgradeUser();
                        return PremiumLogIn();
                    case "3":
                        Console.WriteLine(user.Account());
                        switch (UserServices.GetInput("Would you like to:\n1) Go back\n2) Log out"))
                        {
                            case "1":
                                Console.Clear();
                                continue;
                            case "2":
                                CurrentSession.User = null;
                                Console.Clear();
                                return false;
                            default:
                                DefaultOption();
                                continue;
                        }
                    case "4":
                        Console.Clear();
                        return false;
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }
        public void UpgradeUser()
        {
            CurrentSession.User.AccountType = AccountType.Premium;
            _storage.Update(CurrentSession.User);
            Console.WriteLine("You were successfully upgraded to premium!");
        }

        public bool PremiumLogIn()
        {
            User user = CurrentSession.User;
            while (true)
            {
                Console.WriteLine(Welcome());
                switch (UserServices.GetInput("Would you like to:\n1) Train\n2) Account\n3) Log out"))
                {
                    case "1":
                        while (true)
                        {
                            switch (UserServices.GetInput("Would you like to go to:\n1) Video trainings\n2) Live trainings"))
                            {
                                case "1":
                                    return VideoTrain();
                                case "2":
                                    return LiveTrain();
                                default:
                                    DefaultOption();
                                    continue;
                            }
                        }
                    case "2":
                        Console.WriteLine(user.Account());
                        switch (UserServices.GetInput("Would you like to:\n1) Go back\n2) Log out"))
                        {
                            case "1":
                                Console.Clear();
                                continue;
                            case "2":
                                CurrentSession.User = null;
                                Console.Clear();
                                return false;
                            default:
                                DefaultOption();
                                continue;
                        }
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Thanks for using Try Being Fit!");
                        return false;
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }
        public bool StartLiveTraining()
        {
            User trainer = CurrentSession.User;
            var storage = new Data2();
            var liveTrainings = _storage.ReadLiveTrainings();
            var trainerTrainings = liveTrainings.Where(x => x.Trainer.Username.Equals(trainer.Username)).ToList();
            while (true)
            {
                if (trainerTrainings.Count < 1)
                {
                    switch (UserServices.GetInput("There's no live trainings scheduled by you, would you like to:\n1) Create a live training\n2) Go back to your profile"))
                    {
                        case "1":
                            Console.Clear();
                            return CreateLiveTraining();

                        case "2":
                            Console.Clear();
                            return CreateLiveTraining();

                        default:
                            DefaultOption();
                            continue;
                    }
                }
                Console.WriteLine(GetLiveTrainings());
                int id = UserServices.GetNumber("Enter the id of the live training that you would like to start");
                if (!liveTrainings.Any(x => x.Id.Equals(id)))
                {
                    Console.Clear();
                    Console.WriteLine("The Id entered doesn't exist in the current list of live trainings, please try again.");
                    continue;
                }
                LiveTraining live = liveTrainings.First(x => x.Id.Equals(id));
                Console.WriteLine("Live training started.");
                Console.WriteLine(live.GetInfo());
                liveTrainings.Remove(live);
                _storage.SaveItems(liveTrainings);
                switch (UserServices.GetInput("Would you like to:\n1) Go back to your profile\n2) Start another live training"))
                {
                    case "1":
                        Console.Clear();
                        return TrainerLogIn();
                    case "2":
                    default:
                        Console.Clear();
                        continue;
                }
            }
        }
        public bool TrainerLogIn()
        {
            User trainer = CurrentSession.User;
            while (true)
            {
                Console.WriteLine(Welcome());
                switch (UserServices.GetInput("Would you like to:\n1) Create a live training\n2) Reschedule a live training\n3) Account\n4) Train\n5) Start a live training\n6) Log out"))
                {
                    case "1":
                        return CreateLiveTraining();
                    case "2":
                        return RescheduleTraining();
                    case "3":
                        Console.WriteLine(trainer.Account());
                        switch (UserServices.GetInput("Would you like to:\n1) Go back\n2) Log out"))
                        {
                            case "1":
                                Console.Clear();
                                continue;
                            case "2":
                                CurrentSession.User = null;
                                Console.Clear();
                                return false;
                            default:
                                DefaultOption();
                                continue;
                        }
                    case "4":
                        switch (UserServices.GetInput("Would you like to train using:\n1) Video trainings\n2) Live trainings "))
                        {
                            case "1":
                                return VideoTrain();
                            case "2":
                                return LiveTrain();
                            default:
                                DefaultOption();
                                continue;
                        }
                    case "5":
                        return StartLiveTraining();
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Thanks for using Try being fit!");
                        return UI();
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }

        public bool Register()
        {
            var users = _storage.ReadUsers();
            while (true)
            {
                string firstName = UserServices.GetInput("Enter your first name:");
                string lastName = UserServices.GetInput("Enter your last name:");
                if (firstName.Length < 2 || lastName.Length < 2)
                {
                    Console.Clear();
                    Console.WriteLine("Your name must not be shorter than 2 chrs");
                    continue;
                }
                while (true)
                {
                    string username = UserServices.GetInput("Enter your username:");
                    if (username.Length < 6)
                    {
                        Console.WriteLine("Your username must contain at least 6 chrs.");
                        continue;
                    }
                    else if (users.Any(x => x.Username == username))
                    {
                        Console.WriteLine("That username already exists!");
                        continue;
                    }
                    User user = new StandardUser(firstName, lastName, username, UserServices.GetInput("Enter your new password (Make sure theres at least 6 characters including a number)"));
                    _storage.AddUser(user);
                    Console.WriteLine("User successfully created!");
                    switch (UserServices.GetInput("Would you like to login with your new account? (Y N)").ToUpper())
                    {
                        case "Y":
                            Console.Clear();
                            CurrentSession.Set(user);
                            return StandardLogIn();
                        case "N":
                            Console.Clear();
                            return false;
                    }
                }

            }
        }
        public bool MoreVideoInfo(VideoTraining video)
        {
            User user = CurrentSession.User;
            while (true)
            {
                Console.WriteLine(video.GetInfo());
                switch (UserServices.GetInput("\nWould you like to:\n1) Give the video a rating\n2) Go Back to all the videos"))
                {
                    case "1":
                        decimal rating = UserServices.GetRating("Enter a rating for the video (1 to 5)");
                        int index = Data2.VideoTrainings.IndexOf(video);
                        Data2.VideoTrainings[index].ChangeRating(rating);
                        Console.Clear();
                        Console.WriteLine($"Thanks for taking the time to give ({video.Title}) a rating!");
                        return VideoTrain();
                    case "2":
                        Console.Clear();
                        return VideoTrain();
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }
        public bool VideoTrain()
        {
            User user = CurrentSession.User;
            while (true)
            {
                Console.WriteLine("Videos:\n");
                Console.WriteLine(UserServices.GetVideoTrainings());
                switch (UserServices.GetInput("Would you like to: \n1) Train using one of the videos\n2) Go back to your profile"))
                {
                    case "1":
                        int id = UserServices.GetNumber("Enter the id of the video that you want to see.");
                        if (!Data2.VideoTrainings.Any(x => x.Id == id))
                        {
                            Console.Clear();
                            Console.WriteLine("Please make sure you enter one of the video id's shown below!");
                            continue;
                        }
                        else
                        {
                            VideoTraining video = Data2.VideoTrainings.First(x => x.Id.Equals(id));
                            Console.Clear();
                            return MoreVideoInfo(video);
                        }
                    case "2":
                        switch (user.AccountType)
                        {
                            case AccountType.Standard:
                                return StandardLogIn();
                            case AccountType.Premium:
                                return PremiumLogIn();
                            case AccountType.Trainer:
                                return TrainerLogIn();
                        }
                        break;
                    default:
                        DefaultOption();
                        continue;
                }
            }
        }

        public bool SignIn(string accountType)
        {
            while (true)
            {
                var users = _storage.ReadUsers();
                string username = UserServices.GetInput("Enter your username:");
                if (username.Length < 6)
                {
                    Console.WriteLine("The username you entered is shorter than the minimal requirement(6 chrs)");
                    continue;
                }
                if (accountType == "trainer")
                {
                    if (!Data2.Trainers.Any(x => x.Username == username))
                    {
                        Console.WriteLine("No trainers with that username exist!");
                        continue;
                    }
                }
                else if (!users.Any(x => x.Username == username.Trim()))
                {
                    Console.WriteLine("This username doesn't exist!");
                    continue;
                }

                while (true)
                {
                    string password = UserServices.GetInput("Enter your password:");
                    if (accountType == "trainer")
                    {
                        if (Data2.Trainers.Any(x => x.Username == username && x.CheckPassword(password)))
                        {
                            Trainer trainer = Data2.Trainers.First(x => x.Username.Equals(username));
                            Console.Clear();
                            CurrentSession.Set(trainer);
                            return TrainerLogIn();
                        }
                    }
                    else if (users.Any(x => x.Username == username && x.CheckPassword(password)))
                    {
                        User user = users.First(x => x.Username.Equals(username));
                        CurrentSession.Set(user);
                        switch (user.AccountType)
                        {
                            case AccountType.Standard:
                                return StandardLogIn();
                            case AccountType.Premium:
                                return PremiumLogIn();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The password you entered is incorrect.");
                        continue;
                    }
                }

            }
        }
    }
}
