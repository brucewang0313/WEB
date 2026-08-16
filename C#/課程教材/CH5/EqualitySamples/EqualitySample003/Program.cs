namespace EqualitySample003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            int j = 10;

            Console.WriteLine($"i.Equls(j) os {i.Equals(j)}");
            MyRectangle r1 = new MyRectangle { Width = 5, Height = 5 };
            MyRectangle r2 = new MyRectangle { Width = 5, Height = 5 };
            MyRectangle r3 = r2;
            Console.WriteLine($"r1.Equals(r2) is {r1.Equals(r2)}");
            Console.WriteLine($"r2.Equals(r3) is {r2.Equals(r3)}");

            Console.ReadLine();
        }
    }
}
