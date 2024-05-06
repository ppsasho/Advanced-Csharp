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
        public double GetGlobalReadingTime() => Math.Round(TotalReadingTime() + TotalExercisingTime() + TotalWorkingTime() + TotalHobbyTime());
        //public string FavoriteActivity()
        //{
        //    var readings = Readings.Count;
        //    var exercises = Exercises.Count;
        //    var workings = Workings.Count;
        //    var hobbies = Hobbies.Count;

        //    var activities = new List<int>
        //    {
        //        readings, exercises, workings, hobbies
        //    };
        //}

        public int GetTotalPages() => Readings.Count > 0 ? Readings.Sum(x => x.Pages) : 0;
        public double TotalReadingTime() => Readings.Count > 0 ? Math.Round(Readings.Sum(x => x.GetHours())) : 0;
        public decimal AvgReadingTime() => Readings.Count > 0 ? Readings.Sum(x => x.GetMinutes()) / Readings.Count : 0;
        public string FavoriteReadingType() => Readings.Count > 0 ? Readings.Max(x => x.Type).ToString() : "None";

        public double TotalExercisingTime() => Exercises.Count > 0 ? Math.Round(Exercises.Sum(x => x.GetHours())) : 0;
        public decimal AvgExercisingTime() => Exercises.Count > 0 ? Exercises.Sum(x => x.GetMinutes()) / Exercises.Count : 0;
        public string FavoriteExercisingType() => Exercises.Count > 0 ? Exercises.Max(x => x.Type).ToString() : "None";

        public double TotalWorkingTime() => Workings.Count > 0 ? Math.Round(Workings.Sum(x => x.GetHours())) : 0;
        public decimal AvgWorkingTime() => Workings.Count > 0 ? Workings.Sum(x => x.GetMinutes()) / Workings.Count : 0;
        public string FavoriteWorkingType() => Workings.Count > 0 ? Workings.Max(x => x.Type).ToString() : "None";
        public string OfficeVsHomeTime()
        {
            if (Workings.Count > 0) 
            {
                var officeTime = Workings.Where(x => x.Type == "At the office").Sum(x => x.GetHours());
                var homeTime = Workings.Where(x => x.Type == "From home").Sum(x => x.GetHours());
                return $"Home time: {homeTime}\nOffice time: {officeTime}";
            }
            return "No activities found from working!";
        }

        public double TotalHobbyTime() => Hobbies.Count > 0 ? Math.Round(Hobbies.Sum(x => x.GetHours())) : 0;
        public string GetHobbyNames()
        {
            if(Hobbies.Count > 0) 
            {
                List<string> result = new();
                Hobbies.ForEach(x => { if(!result.Contains(x.Name)) result.Add(x.Name); });
                return string.Join("\n", result);
            }
            return "No hobbies yet";
        }
        
    }
}
