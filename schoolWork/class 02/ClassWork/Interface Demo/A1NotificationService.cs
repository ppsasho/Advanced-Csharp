namespace Interface_Demo
{
    public class A1NotificationService : NotificationService, IInterface
    {
        public A1NotificationService() 
        {
            Name = "A1";
        }

        public string SendSmsNotification(string phoneNumber, string message)
        {
            return $"Thank you for using our service, the message is sent. Your A1!";
        }
    }

}
