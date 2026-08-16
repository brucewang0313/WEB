namespace DelegateSample002
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // 建立來源資料
            List<string> source = new List<string> { "Bill", "John", "David", "Tom", "David" };

            // 具名委派
            MyPredicate predicate = SearchDavid;

            /* 原來的正式寫法
            MyPredicate predicate = new MyPredicate(SearchDavid);
            */

            var result = MyClass.DoWhere(source, predicate);            
            Console.WriteLine(string.Join(", ", result));
            Console.ReadLine();
        }

        static bool SearchDavid(string value)
        {
            return (value == "David");
        }
    }
}
