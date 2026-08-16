namespace MethodOverloadSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static double CalculateArea(double height, double width)
        {
            return height * width;
        }

        static double CalculateArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

    }
}
