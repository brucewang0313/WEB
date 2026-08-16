namespace DoWhereSample004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source = ["Bill", "John", "David", "Tom", "David"];
            var result = source.DoWhere(x => x.Length == 4);
            Console.WriteLine(string.Join(",", result));

            int[] source2 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var result2 = source2.DoWhere(x => x % 2 == 0);
            Console.WriteLine(string.Join(",", result2));
            Console.ReadLine();
        }
    }
}
