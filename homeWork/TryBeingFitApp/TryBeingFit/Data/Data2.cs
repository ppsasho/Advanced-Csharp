using Models;
using Newtonsoft.Json;

namespace Storage
{
    public class Data2
    {
        public static List<VideoTraining> VideoTrainings = new()
        {
            new("https://www.youtube.com/watch?v=abcdefg12345", "Upper Body workout\t", 1),
            new("https://www.youtube.com/watch?v=qwerty09876", "Lower Body workout\t", 2),
            new("https://www.youtube.com/watch?v=zyxwvuts7654", "Core Body workout\t", 3),
            new("https://www.youtube.com/watch?v=0987poiuytre", "Cardio workout\t\t", 4),
            new("https://www.youtube.com/watch?v=mnbvcxz43210", "Flexibility workout\t", 5)
        };
        public static List<Trainer> Trainers = new()
        {
            new("Brad", "Schoenfeld", "bschoen", "bschoen1"),
            new("Matt", "Roberts", "mroberts", "mroberts1"),
            new("Louise", "Parker", "lparker", "lparker1"),
            new("Shaun", "Stafford", "sstafford", "sstafford1")
        };
        public void Update(User user)
        {
            var users = ReadUsers();
            var found = users.FirstOrDefault(x => x.Username.Equals(user.Username)) ??
                throw new KeyNotFoundException($"User with username {user.Username} does not exist.");
            users[users.IndexOf(found)] = user;
            SaveItems(users);
        }
        public void Update(LiveTraining live)
        {
            var livetrainings = ReadLiveTrainings();
            var found = livetrainings.FirstOrDefault(x => x.Id.Equals(live.Id)) ??
                throw new KeyNotFoundException($"live training with Id {live.Id} does not exist.");
            livetrainings[livetrainings.IndexOf(found)] = live;
            SaveItems(livetrainings);
        }
        public void AddLive(LiveTraining liveTraining)
        {
            var liveTrainings = ReadLiveTrainings();
            if (liveTrainings.Any())
            {
                int max = liveTrainings.Max(x => x.Id);
                liveTraining.Id = max + 1;
            }
            else
            {
                liveTraining.Id = 1;
            }
            liveTrainings.Add(liveTraining);
            SaveItems(liveTrainings);
        }
        public void AddUser(User user)
        {
            var users = ReadUsers();
            users.Add(user);
            SaveItems(users);
        }
        public List<User> ReadUsers()
        {
            string folderPath = @"..\..\..\Data";
            string fileName = $"Users.json";
            string filePath = $@"{folderPath}\{fileName}";
            var result = new List<User>();

            if (!Directory.Exists(folderPath))
            {
                return result;
            }

            if (!File.Exists(filePath))
            {
                return result;
            }

            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    string content = sr.ReadToEnd();

                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    result = JsonConvert.DeserializeObject<List<User>>(content, settings) ?? new List<User>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error was found!\n", ex.ToString());
                return result;
            }

            return result;
        }
        public List<LiveTraining> ReadLiveTrainings()
        {
            string folderPath = @"..\..\..\Data";
            string fileName = $"LiveTrainings.json";
            string filePath = $@"{folderPath}\{fileName}";
            var result = new List<LiveTraining>();

            if (!Directory.Exists(folderPath))
            {
                return result;
            }

            if (!File.Exists(filePath))
            {
                return result;
            }

            try
            {
                using (var sr = new StreamReader(filePath))
                {
                    string content = sr.ReadToEnd();

                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    result = JsonConvert.DeserializeObject<List<LiveTraining>>(content, settings) ?? new List<LiveTraining>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error was found!\n", ex.ToString());
                return result;
            }

            return result;
        }
        public void SaveItems(List<User> users)
        {
            string folderPath = @"..\..\..\Data";
            string fileName = $"Users.json";
            string filePath = $@"{folderPath}\{fileName}";

            if(!Directory.Exists(folderPath)) 
                Directory.CreateDirectory(folderPath);

            if(!File.Exists(filePath))
                File.Create(filePath).Close();

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string content = JsonConvert.SerializeObject(users, settings);

            using(var sw = new StreamWriter(filePath)) 
            {
                sw.WriteLine(content);
            }
        }

        public void SaveItems(List<LiveTraining> liveTrainings)
        {
            string folderPath = @"..\..\..\Data";
            string fileName = $"LiveTrainings.json";
            string filePath = $@"{folderPath}\{fileName}";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string content = JsonConvert.SerializeObject(liveTrainings, settings);

            using (var sw = new StringWriter())
            {
                sw.WriteLine(content);
            }
        }
    }
}
