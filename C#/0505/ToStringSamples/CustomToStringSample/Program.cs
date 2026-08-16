namespace CustomToStringSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rect = new MyRectangle { Width = 100, Height = 50 };
            Console.WriteLine(rect.ToString());
            Console.ReadLine();
        }
    }
    internal class MyRectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $"Width={Width}, Height{Height}";
        }
    }

}
