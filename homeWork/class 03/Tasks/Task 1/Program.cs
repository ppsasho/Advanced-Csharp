namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Data
            User u1 = new(0, "David", 20);
            User u2 = new(1, "Filip", 23);
            User u3 = new(2, "Marko", 19);
            User u4 = new(3, "Daniel", 25);
            User u5 = new(4, "David", 21);
            User u6 = new(5, "Leonid", 23);
            User u7 = new(6, "Georgi", 19);
            User u8 = new(7, "Dimitar", 25);

            UserDatabase.Users.AddRange(new List<User> { u1, u2, u3, u4, u5, u6, u7, u8});
            #endregion
            #region UI
            while (true) 
            {
                switch(GetInput("Would you like to search users by:\n\t1) Id\n\t2) Name\n\t3) Age"))
                {
                    case "1":
                        User u = Search(GetNumber("Enter the id of the user: "));
                        if (u != null) Console.WriteLine($"A user was found!\n{u.GetInfo()}");
                        else Console.WriteLine("No user was found with that id!");
                        break;

                    case "2":
                        List<User> ulist = Search(GetInput("Enter a name to search: "));
                        if (ulist.Count > 0) foreach (User user in ulist) Console.WriteLine(user.GetInfo());
                        else Console.WriteLine("No users were found with that name!");
                        break;

                    case "3":
                        List<User> ulist1 = Search("searching", GetNumber("Enter the age of the user: ")).ToList();
                        if (ulist1.Count > 0) foreach (User user in ulist1) Console.WriteLine(user.GetInfo());
                        else Console.WriteLine("No users were found with that age!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please check you only entered one of the numbers.");
                        continue;
                }

                switch(GetInput("Would you like to search again? (Y N):").ToUpper())
                {
                    case "Y":
                        continue;
                    case "N":
                    default:
                        break;
                }
                break;
            }
            #endregion
        }
        #region Methods
        static List<User> Search(string msg, int age)
        {
            List<User> users = UserDatabase.Users.Where(x => x.Age.Equals(age)).ToList();
            return users;
        }
        static List<User> Search(string name)
        {
            List<User> users = UserDatabase.Users.Where(x => x.Name.ToLower().Equals(name.ToLower())).ToList();
            return users;
        }
        static User Search(int id)
        {
            User u = UserDatabase.Users.FirstOrDefault(x => x.Id.Equals(id));
            return u;
        }
        static int GetNumber(string msg)
        {
            while (true)
            {
                if (int.TryParse(GetInput(msg), out int id)) return id;

                Console.Clear();
                Console.WriteLine("Please make sure you enter a number.");
                continue;
            }
        }
        static string GetInput(string msg)
        {
            while (true) 
            {
                Console.WriteLine(msg);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input)) return input;
                Console.WriteLine("Please don't leave empty inputs");
                continue;
            }
        }
        #endregion
    }
}
