namespace Employees
{
    public class Manager : Employee
    {
        public Manager(string name, int salary) : base(name, salary) { }

        public override int CalculateSalary()
        {
            return (int)(Salary * 2.8);
        }

        public override string DiplayInfo()
        {
            return $"{Name} the manager makes a salary of: {CalculateSalary()}$.";
        }
    }
}
