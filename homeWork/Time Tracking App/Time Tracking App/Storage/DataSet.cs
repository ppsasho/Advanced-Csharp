using Models;
using Newtonsoft.Json;
namespace Storage
{
    public class DataSet : IDataSet<User>
    {
        public void Add(User user)
        {
            var users = ReadUsers();

            users.Add(user);
            SaveUsers(users);
        }

        public List<User> GetAll()
        {
            return ReadUsers();
        }

        public void Update(User user)
        {
            var users = ReadUsers();
            User found = users.FirstOrDefault(x => x.Username == user.Username) ?? throw new KeyNotFoundException($"User with username: [{user.Username}] was not found!");

            users[users.IndexOf(found)] = user;
            SaveUsers(users);
        }
        private List<User> ReadUsers()
        {   
            string folderPath = @"..\..\..\Data";
            string fileName = $"Users.json";
            string filePath = $@"{folderPath}\{fileName}";
            var result = new List<User>();

            if (!Directory.Exists(folderPath)) return result;

            if (!File.Exists(filePath)) return result;

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
                Console.WriteLine($"Error found while reading users!\n{ex}");
                return result;
            }

            return result;
        }

        private void SaveUsers(List<User> users)
        {
            string folderPath = @"..\..\..\Data";
            string fileName = $"Users.json";
            string filePath = $@"{folderPath}\{fileName}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            JsonSerializerSettings settings = new() { TypeNameHandling = TypeNameHandling.All };
            string convertedUsers = JsonConvert.SerializeObject(users, settings);

            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(convertedUsers);
            }
        }
    }
}
