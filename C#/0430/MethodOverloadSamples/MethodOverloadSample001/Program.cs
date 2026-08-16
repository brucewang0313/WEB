namespace MethodOverloadSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Add(1, 1));
            Console.WriteLine(Add(1, 1, 3));
            Console.WriteLine(Add(1.5, 3.2));
            Console.WriteLine(Add(9.8, 7));
            Console.WriteLine(Add(1.2, 3.4, 5.6));
            Console.WriteLine(CalculateArea(3, 3));
            Console.WriteLine(CalculateArea(3));
        }
        static int Add(int x,int y)//用多載呼叫另一個多載
        { return Add(x, y, 0); }
        static int Add(int x,int y,int z)
        {return x + y + z; }
        static double Add(double x, double y) 
        { return x + y; }
        static double Add(double x, double y,double z)
        { return x + y + z; }

        static double CalculateArea(double x,double y)
        {
            return x * y;
        }
        static double CalculateArea(double x)
        {
            return Math.Pow(x, 2) * Math.PI;
        }
    }
}
