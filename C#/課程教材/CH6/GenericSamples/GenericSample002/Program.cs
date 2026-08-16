namespace GenericSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source
                     = new List<string> { "Bill", "John", "David", "Tom", "David" };
            var result = source.DoWhere<string>((x) => x == "David");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // 現在甚麼型別都可以來一下了
            List<int> source2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var result2 = source2.DoWhere((x) => x > 3);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
