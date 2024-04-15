using DataAcess;
using Services.Implementations;
using Services.Interfaces;

namespace Taxi_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUIService uiService = new UIService();

            uiService.Login();

            var loggedInUser = CurrentSession.User;
        }
    }
}
