namespace Interface_Demo
{
    public class TMobileService : NotificationService, IInterface
    {
        public TMobileService() 
        {
            Name = "TMobile";
        }
        public string SendSmsNotification(string phoneNumber, string message)
        {
            return $"Thank you for using our service, the message is sent. Your TM!";
        }
    }
}
