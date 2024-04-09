using System.Reflection.Metadata;

namespace Models
{
    public static class Data
    {
        public static List<User> Users = new();
        public static List<Trainer> Trainers = new();
        public static List<VideoTraining> VideoTrainings = new();
        static Data() 
        {
            LoadUsers();
        }
        public static void LoadUsers()
        {
            VideoTrainings = new List<VideoTraining>()
            {
                new("https://teams.microsoft.com/dl/launcher/launcher.html?url=%2F_%23%2Fl%2Fmeeting%2F4321%3Fid%3D0123456789%26b%3D1%26k%3D1", "Upper Body workout", 1),
                new("https://teams.microsoft.com/dl/launcher/launcher.html?url=%2F_%23%2Fl%2Fmeetup%2F5432%3Fid%3D9876543210%26b%3D1%26k%3D1", " Lower Body workout", 2),
                new("https://teams.microsoft.com/dl/launcher/launcher.html?url=%2F_%23%2Fl%2Fcall%2F6543%3Fid%3D2468013579%26b%3D1%26k%3D1", "Core Body workout", 3),
                new("https://teams.microsoft.com/dl/launcher/launcher.html?url=%2F_%23%2Fl%2Fevent%2F7654%3Fid%3D1357924680%26b%3D1%26k%3D1", "Cardio workout", 4),
                new("https://teams.microsoft.com/dl/launcher/launcher.html?url=%2F_%23%2Fl%2Fevent%2F7654%3Fid%3D1357924680%26b%3D1%26k%3D1", "Flexibility workout", 5)
            };
            Trainers = new List<Trainer>()
            {
                new("Brad", "Schoenfeld", "bschoen", "bschoen1"),
                new("Matt", "Roberts", "mroberts", "mroberts1"),
                new("Louise", "Parker", "lparker", "lparker1"),
                new("Shaun", "Stafford", "sstafford", "sstafford1")
            };
            Users = new List<User>()
            {
                new StandardUser("Sasho", "Popovski", "ppsasho", "ppsasho1"),
            };
        }
    }
}
