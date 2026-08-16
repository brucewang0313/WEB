using System;

namespace DelegateSample003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 建立來源資料
            List<string> source
                = new List<string> { "Bill", "John", "David", "Tom", "David" };


            var result = MyClass.DoWhere(source,
                               delegate (string x) { return x == "David"; });

            
            Console.WriteLine(string.Join(", ", result));
            Console.ReadLine();
        }
    }
}
