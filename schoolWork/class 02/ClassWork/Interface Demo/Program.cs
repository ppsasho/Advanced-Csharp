namespace Interface_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A1NotificationService a1Service = new A1NotificationService();
            TMobileService tMobileService = new TMobileService();

            //NotificationService notificationService = new A1NotificationService();
            //NotificationService notificationService1 = new TMobileService();

            Console.WriteLine("Choose:\n1) A1\n2) TMobile");
            string input = Console.ReadLine();
            IInterface notificationService;
            switch(input)
            {
                case "1":
                    notificationService = new A1NotificationService();
                    break;
                case "2":
                    notificationService = new TMobileService();
                    break;
                default: 
                    notificationService = new A1NotificationService();
                    break;
            }
            string result = notificationService.SendSmsNotification("235235235", "Hello from provider");
            Console.WriteLine(result);

            NotificationService a1 = new A1NotificationService();
            NotificationService tM = new TMobileService();

            //A1NotificationService a1_1 = new (A1NotificationService)a1;
            //A1NotificationService tm_1 = new (TMobileService)tM;

            int t = 10;
            object o = t;
            object a1_2 = a1;
            int t2 = (int)o;

        }
    }
}
