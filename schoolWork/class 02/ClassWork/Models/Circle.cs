namespace Models
{
    public class Circle : Shape
    {
        public Circle(string name, float a) : base(name, a) { }

        public override float GetArea()
        {
            return (float)(Math.PI * Math.Pow(A, 2));
        }
    }
}
