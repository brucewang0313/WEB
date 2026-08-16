namespace DelegateSample004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source
              = new List<string> { "Bill", "John", "David", "Tom", "David" };
           
            var result = MyClass.DoWhere(source, (x) => { return x == "David"; });

            Console.WriteLine(string.Join(", ", result));
            Console.ReadLine();
        }
    }
}
