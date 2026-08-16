namespace CustomSkipTakeExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var skipped = list.MySkip(3);
            Console.WriteLine(string.Join(", ", skipped));
            var taken = list.MyTake(4);
            Console.WriteLine(string.Join(", ", taken));
        }
    }


    public static class MyExtensions
    {
        public static IEnumerable<T> MySkip<T>(this IEnumerable<T> source, int count)
        {
           throw new NotImplementedException();
        }
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source, int count)
        {
           throw new NotImplementedException();
        }
    }
}
