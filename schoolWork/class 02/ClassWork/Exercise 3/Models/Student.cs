
using Exercise_3;

namespace Models
{
    public class Student : User, IStudent
    {
        //public List<int> Grades { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<int> Grades { get; set; }

        public Student (List<int> grades, string username, string name, string password) : base(username, name, password)
        {
            Grades = grades;
        }
        public override string GetUser()
        {
            var result = base.GetUser() + "\nGrades:\n" + string.Join(", ", Grades);
            return result;
        }
    }
}
