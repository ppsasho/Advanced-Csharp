namespace Models
{
    public class Square : Shape
    {
        public Square(string name, float a) : base(name, a)
        {

        }

        public override float GetArea()
        {
            return A * A;
        }
    }
}
