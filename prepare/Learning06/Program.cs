using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square(3, "Red");
        shapes.Add(s1);

        Rectangle s2 = new Rectangle(4, 5, "White");
        shapes.Add(s2);

        Circle s3 = new Circle(6, "Green");
        shapes.Add(s3);

        foreach(Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}."); 
            Console.WriteLine();
        }
    }
}