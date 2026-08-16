using MyLibrary;
namespace DLLSample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyRectangle rect = new MyRectangle() { Width = 25, Height = 7 };
            Console.WriteLine($"矩形面積為: {rect.GetArea()}");
            Console.ReadLine();
        }
    }
}
