namespace DelegateSample002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> source
            = new List<string> { "Bill", "John", "David", "Tom", "David" };

            ////MyPredicate predicate = new MyPredicate(SearchDavid);
            //MyPredicate predicate = SearchDavid;// 具名委派 因為有new一個有具名的方法
            //var result = MyClass.DoWhere(source, predicate);

            //// 匿名委派
            //var result = MyClass.DoWhere(source,delegate (string x) { return x == "David"; });

            //Lambda
            var result = MyClass.DoWhere(source, (x) => { return x == "David"; });
            Console.WriteLine(string.Join(", ", result));

            Console.ReadLine();
        }
        static bool SearchDavid(string value)
        {
            return (value == "David");
        }
    }
}
