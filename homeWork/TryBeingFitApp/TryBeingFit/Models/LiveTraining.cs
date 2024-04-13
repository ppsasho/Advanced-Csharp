namespace Models
{
    public class LiveTraining : Training
    {
        public User Trainer { get; set; }
        public DateTime Schedule {  get; set; }

        public List<User> Participants = new(){ };

        public LiveTraining(string link, string title, DateTime schedule, User trainer) : base(link, title, 0)
        {
            Schedule = schedule;
            Trainer = trainer;
        }
        public void ReSchedule(DateTime newSchedule) 
        {
            if(newSchedule > DateTime.Now)
            {
                Schedule = newSchedule;
            }
        }
        public string GetRemainingTime()
        {
            double remainingHours = Math.Round((Schedule - DateTime.Now).TotalHours);
            return $"{remainingHours} hours left";
        }
    }
}
