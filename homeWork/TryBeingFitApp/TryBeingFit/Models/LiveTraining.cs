namespace Models
{
    public class LiveTraining : Training
    {
        public DateTime Schedule {  get; set; }

        public LiveTraining(string link, string title, DateTime schedule) : base(link, title)
        {
            Schedule = schedule;
        }
        public void ReSchedule(DateTime newSchedule) 
        {
            Schedule = newSchedule;
        }
        public string GetRemainingTime()
        {
            double remainingHours = (Schedule - DateTime.Now).TotalHours;
            return $"{remainingHours} hours left";
        }
    }
}
