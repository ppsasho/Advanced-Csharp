using System.Text;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Sasho", "Popovski", 19);
            var parsedUser = DeSerialize(SerializeUser(user));

        }
        static string SerializeUser(User user) 
        {
            //string result = "{\n";
            //result += "\"Name\": \"Sasho\"";
            var result = new StringBuilder();
            result.AppendLine("{");
            result.AppendLine($"\"Name\": \"{user.Name}\",");
            result.AppendLine($"\"LastName\": \"{user.LastName}\",");
            result.AppendLine($"\"Age\": {user.Age}");
            result.AppendLine("}");
            return result.ToString();
        }

        static User DeSerialize(string json)
        {
            string[] properties = json.Replace("\r\n", "").Replace("{", "").Replace("}", "").Replace("\"", "").Split(",");
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            foreach(string property in properties)
            {
                var prop = property.Split(":");
                pairs.Add(prop[0], prop[1]);
            }
            var result = new User()
            {
                Name = pairs["Name"],
                LastName = pairs["LastName"],
                Age = int.Parse(pairs["Age"])
            };
            return result;
        }
    }
}
