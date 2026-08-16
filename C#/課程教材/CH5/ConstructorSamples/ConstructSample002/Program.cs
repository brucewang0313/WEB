using ConstructSample001;

namespace ConstructSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseClass o1 = new BaseClass();
            Display("o1", o1.X);

            BaseClass o2 = new BaseClass(99);
            Display("o2", o2.X);

            Class1 o3 = new Class1(55, 77);
            Display("o3", o3.X, o3.K);

            Console.ReadLine();
        }

        static void Display(string name, int value)
        {
            Console.WriteLine($"{name} 的 X 是 {value}");
        }

        static void Display(string name, int v1, int v2)
        {
            Console.WriteLine($"{name} 的 X 是 {v1} , K 是 {v2}");
        }
    }
}
