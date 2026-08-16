namespace EqualitySample003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            int j = 10;
            Console.WriteLine($"i.Equals(j) is {i.Equals(j)}");
            MyRectangle r1 = new MyRectangle { Width = 5, Height = 5 };
            MyRectangle r2 = new MyRectangle { Width = 5, Height = 5 };
            MyRectangle r3 = r2;
            Console.WriteLine($"r1.Equals(r2) is {r1.Equals(r2)}");
            object o = r2;
            Console.WriteLine($"r1.Equals(o) is {r1.Equals(o)}");
            Console.WriteLine($"r1.Equals(r3) is {r2.Equals(r3)}");
        }
    }
    internal class MyRectangle : IEquatable<MyRectangle>
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as MyRectangle);
        }

        public bool Equals(MyRectangle other)
        {
            return other is not null &&
                   Width == other.Width &&
                   Height == other.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height);
        }

        public static bool operator ==(MyRectangle left, MyRectangle right)
        {
            return EqualityComparer<MyRectangle>.Default.Equals(left, right);
        }

        public static bool operator !=(MyRectangle left, MyRectangle right)
        {
            return !(left == right);
        }
    }
}
