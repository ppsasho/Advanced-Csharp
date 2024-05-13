using Models;

namespace TryBeingFit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new CMD();
            while (!ui.UI());
        }
    }
}
