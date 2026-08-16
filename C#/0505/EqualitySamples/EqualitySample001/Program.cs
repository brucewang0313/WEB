namespace EqualitySample001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            int j = 10;
            Console.WriteLine($"object.Equals(i,j) is {object.Equals(i, j)}");

            MyRectangle r1 = new MyRectangle { Width = 5, Height = 5 };
            MyRectangle r2 = new MyRectangle { Width = 5, Height = 5 };
            MyRectangle r3 = r2;
            //因為不同物件答案是False
            Console.WriteLine($"object.Equals(r1,r2) is {object.Equals(r1, r2)}");
            //指向同一個物件答案是True
            Console.WriteLine($"object.Equals(r2,r3) is {object.Equals(r2, r3)}");
            Console.ReadLine();
        }
    }
    internal class MyRectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
