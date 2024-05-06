using Services;

namespace Time_Tracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI ui = new();
            while (!ui.Welcome());
        }
    }
}
