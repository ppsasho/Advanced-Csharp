namespace Models
{
    public abstract class Activity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
        public Activity(DateTime start, DateTime end, string name, string type)
        {
            Start = start;
            End = end;
            Name = name;
            Type = type;
        }
        public string GetInfo()
        {
            return $"Name: {Name} | Type: ({Type})\nTime spent: [{GetMinutes()} minutes]";
        }
        public double GetHours()
        {
            return (End - Start).TotalHours;
        }
        public int GetMinutes()
        {
            return (End - Start).Minutes;
        }
    }
}
