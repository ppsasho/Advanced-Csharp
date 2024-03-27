using Models;

namespace Abstract_Classes_And_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape();
            Square square = new Square("Big", 14);
            Console.WriteLine(square.GetInfo());

            Rectangle rectangle = new Rectangle("Bob", 12, 16);
            Circle circle = new Circle("coolCircle", 20);
            List<Shape> shapes = new List<Shape>() {square, rectangle, circle };
            foreach (Shape shape in shapes) Console.WriteLine(shape.GetInfo());

            List<Square> squares = new List<Square>();
            List<Rectangle> rectangles = new List<Rectangle>();
            List<Circle> circles = new List<Circle>();

            foreach (Shape shape in shapes)
            {
                if (shape is Square) 
                {
                    //squares.Add((Square)shape);
                    squares.Add(shape as Square);
                }
                if (shape is Rectangle)
                {
                    //rectangles.Add((Rectangle)shape);
                    rectangles.Add(shape as Rectangle);
                }
                if (shape is Circle)
                {
                    circles.Add((Circle)shape);
                    circles.Add(circle as Circle);
                }
            }
            foreach (Square sq in squares) Console.WriteLine($"Square: {sq.Name}");
            foreach (Rectangle re in rectangles) Console.WriteLine($"Rectangle: {re.Name}");
            foreach (Circle ci in circles) Console.WriteLine($"Circle: {ci.Name}");

        }
    }
}
