using Newtonsoft.Json;
using Serialization;

namespace JSONWithNewtonsoft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Today;
            var convertedDate = JsonConvert.SerializeObject(today);

            var user = new User("Sasho", "Popovski", 19);
            var userSerialized = JsonConvert.SerializeObject(user);
            var userDeserialized = JsonConvert.DeserializeObject<User>(userSerialized);

        }
    }
}
