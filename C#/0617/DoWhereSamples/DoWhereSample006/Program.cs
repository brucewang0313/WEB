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
    public interface IPredicate<T>
    {
        bool Invoke(T item);
    }
    public static class MyClass
    {
        public static IEnumerable<T> DoWhere<T>(this IEnumerable<T> source, IPredicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class EvenPredicate : IPredicate<int>
    {
        public bool Invoke(int item)
        {
            return item % 2 == 0;
        }
    }

    public class Length4Predicate : IPredicate<string>
    {
        public bool Invoke(string item)
        {
            return item.Length == 4;
        }
    }

}
