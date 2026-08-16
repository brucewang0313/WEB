namespace DoWhereSample001
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

    public static class MyClass
    {
        public static IEnumerable<T> DoWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            //List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;//提升記憶體效率
                }
            }
            //return result;
        }
    }
}
