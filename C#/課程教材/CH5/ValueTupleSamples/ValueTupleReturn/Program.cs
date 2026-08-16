namespace ValueTupleReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (w, h) = (11, 19);
            Console.WriteLine(CalculateRectangle(w, h));
        }

        static (double area, double perimeter) CalculateRectangle(double width, double height)
        {
            double area = width * height;
            double perimeter = (width + height) * 2;
            return (area, perimeter);

        }
    }
}
