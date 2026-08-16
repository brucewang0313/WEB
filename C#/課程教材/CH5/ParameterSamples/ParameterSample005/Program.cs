namespace ParameterSample005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass y = new TestClass();
            TestClass r1 = ChangeByVal(y);
            Console.WriteLine($"r1 和 y 指向同實體 : {object.ReferenceEquals(r1,y)}");
            TestClass r2 = ChangeByRef(ref y);
            Console.WriteLine($"r2 和 y 指向同實體 : {object.ReferenceEquals(r2,y)}");
            Console.ReadLine();
        }

        private static TestClass ChangeByVal(TestClass y)
        {
            y = new TestClass();
            return y;
        }

        private static TestClass ChangeByRef(ref TestClass y)
        {
            y = new TestClass();
            return y;
        }
    }

    public class TestClass
    {
        public int x = 0;
    }
}
