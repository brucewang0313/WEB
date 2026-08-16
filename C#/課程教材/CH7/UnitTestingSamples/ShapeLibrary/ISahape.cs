namespace ShapeLibrary
{
    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }

    public class MyRectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public MyRectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double GetArea() => Width * Height;
        public double GetPerimeter() => 2 * (Width + Height);
    }

    public class MyCircle : IShape
    {
        public double Radius { get; set; }
        public MyCircle(double radius)
        {
            Radius = radius;
        }
        public double GetArea() => System.Math.PI * Radius * Radius;
        public double GetPerimeter() => 2 * System.Math.PI * Radius;
    }
}
