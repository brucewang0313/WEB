namespace DoWhereSample006
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source = ["Bill", "John", "David", "Tom", "David"];
            var result = source.DoWhere(new Length4Predicate());
            Console.WriteLine(string.Join(",", result));

            int[] source2 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            var result2 = source2.DoWhere(new EvenPredicate());
            Console.WriteLine(string.Join(",", result2));
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 偶數篩選條件
    /// </summary>
    public class EvenPredicate : IPredicte<int>
    {
        public bool Invoke(int item)
        {
            return item % 2 == 0;
        }
    }
    /// <summary>
    /// 字串長度為 4 的篩選條件
    /// </summary>
    public class Length4Predicate : IPredicte<string>
    {
        public bool Invoke(string item)
        {
            return item.Length == 4;
        }
    }
}
