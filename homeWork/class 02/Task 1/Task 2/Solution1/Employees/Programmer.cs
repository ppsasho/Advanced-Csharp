namespace Employees
{
    public class Programmer : Employee
    {
        public Programmer(string name, int salary) : base(name, salary) { } 
        public override int CalculateSalary()
        {
            return Salary * 2;
        }

        public override string DiplayInfo()
        {
            return $"{Name} the programmer makes a salary of {CalculateSalary()}$.";
        }
    }
}
