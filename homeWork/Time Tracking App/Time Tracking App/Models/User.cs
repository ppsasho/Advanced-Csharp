using System.Reflection.Metadata.Ecma335;

namespace Models
{
    public class User : Base
    {
        public List<Reading> Readings { get; set; }
        public List<Exercising> Exercises { get; set; }
        public List<Working> Workings { get; set; }
        public List<Hobby> Hobbies { get; set; }
        public User(string firstName, string lastName, int age, string username, string password) : base(firstName, lastName, age, username, password)
        {
            Readings = new List<Reading>();
            Exercises = new List<Exercising>();
            Workings = new List<Working>();
            Hobbies = new List<Hobby>();
        }
        public double GetGlobalTime() => Math.Round(GetTotalReadingTime() + GetTotalExercisingTime() + GetTotalWorkingTime() + TotalHobbyTime());
        public string GetFavoriteActivity()
        {
            var activities = new Dictionary<string, int>
            {
                {"Reading", Readings.Count},
                {"Exercising", Exercises.Count },
                {"Working", Workings.Count },
                {"Hobbies", Hobbies.Count }
            };
            var highest = 
                activities.Where(x => x.Value == activities
                          .Max(x => x.Value))
                          .First(x =>      
                          {          
                              foreach (var activity in activities) {
                                  if (activity.Key == x.Key) return true;
                              }   return false;
                          }).Key;
                          //.First(x => x.Key == "Reading" || //Alternative
                          //            x.Key == "Exercising" ||
                          //            x.Key == "Working" ||
                          //            x.Key == "Hobbies").Key;
            return highest;
        }
        public int GetTotalPages() => Readings.Count > 0 ? Readings.Sum(x => x.Pages) : 0;
        public double GetTotalReadingTime() => Readings.Count > 0 ? Math.Round(Readings.Sum(x => x.GetHours())) : 0;
        public decimal GetAvgReadingTime() => Readings.Count > 0 ? Readings.Sum(x => x.GetMinutes()) / Readings.Count : 0;
        public string GetFavoriteReadingType() => Readings.Count > 0 ? Readings.Max(x => x.Type).ToString() : "None";

        public double GetTotalExercisingTime() => Exercises.Count > 0 ? Math.Round(Exercises.Sum(x => x.GetHours())) : 0;
        public decimal GetAvgExercisingTime() => Exercises.Count > 0 ? Exercises.Sum(x => x.GetMinutes()) / Exercises.Count : 0;
        public string GetFavoriteExercisingType() => Exercises.Count > 0 ? Exercises.Max(x => x.Type).ToString() : "None";

        public double GetTotalWorkingTime() => Workings.Count > 0 ? Math.Round(Workings.Sum(x => x.GetHours())) : 0;
        public decimal GetAvgWorkingTime() => Workings.Count > 0 ? Workings.Sum(x => x.GetMinutes()) / Workings.Count : 0;
        public string GetFavoriteWorkingType() => Workings.Count > 0 ? Workings.Max(x => x.Type).ToString() : "None";
        public string OfficeVsHomeTime()
        {
            if (Workings.Count > 0) 
            {
                var officeTime = Workings.Where(x => x.Type == "At the office").Sum(x => x.GetHours());
                var homeTime = Workings.Where(x => x.Type == "From home").Sum(x => x.GetHours());
                return $"Home time: {homeTime} hours\nOffice time: {officeTime} hours";
            }
            return "No activities found from working!";
        }
        public double TotalHobbyTime() => Hobbies.Count > 0 ? Math.Round(Hobbies.Sum(x => x.GetHours())) : 0;
        public string GetHobbyNames()
        {
            if(Hobbies.Count > 0) 
            {
                List<string> result = new();
                Hobbies.ForEach(x => { 
             if(!result.Contains(x.Name)) result.Add(x.Name); });

                return string.Join("\n", result);
            }
            return "No hobbies yet";
        }
        
    }
}
