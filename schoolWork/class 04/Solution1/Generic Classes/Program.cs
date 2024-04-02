using Models;

namespace Generic_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User u1 = new("Sasho", "ppsasho", "Admin", DateTime.Now);
            
            Loan loan = new(u1, 15000, "Admin", DateTime.Now);
            
            loan.Amount -= 7500;

        }
    }
}
